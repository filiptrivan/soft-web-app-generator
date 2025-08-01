using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Soft.SourceGenerator.NgTable.Helpers;
using Soft.SourceGenerators.Helpers;
using Soft.SourceGenerators.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace Soft.SourceGenerator.NgTable.Net
{
    [Generator]
    public class PSNetServicesGenerator : IIncrementalGenerator
    {

        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            //#if DEBUG
            //            if (!Debugger.IsAttached)
            //            {
            //                Debugger.Launch();
            //            }
            //#endif
            IncrementalValuesProvider<ClassDeclarationSyntax> classDeclarations = context.SyntaxProvider
                .CreateSyntaxProvider(
                    predicate: static (s, _) => Helper.IsSyntaxTargetForGenerationEntities(s),
                    transform: static (ctx, _) => Helper.GetSemanticTargetForGenerationEntities(ctx))
                .Where(static c => c is not null);

            IncrementalValueProvider<IEnumerable<INamedTypeSymbol>> referencedProjectClasses = Helper.GetReferencedProjectsSymbolsEntities(context);

            var allClasses = classDeclarations.Collect()
                .Combine(referencedProjectClasses);

            context.RegisterImplementationSourceOutput(allClasses, static (spc, source) => Execute(source.Left, source.Right, spc));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classes">Only EF classes</param>
        /// <param name="context"></param>
        private static void Execute(IList<ClassDeclarationSyntax> classes, IEnumerable<INamedTypeSymbol> referencedClassesEntities, SourceProductionContext context)
        {
            if (classes.Count == 0) return; // We don't need config
            List<ClassDeclarationSyntax> entityClasses = Helper.GetEntityClasses(classes);

            StringBuilder sb = new StringBuilder();

            string[] namespacePartsWithoutLastElement = Helper.GetNamespacePartsWithoutLastElement(entityClasses[0]);

            string basePartOfNamespace = string.Join(".", namespacePartsWithoutLastElement); // eg. Spider.Security
            string projectName = namespacePartsWithoutLastElement[namespacePartsWithoutLastElement.Length - 1]; // eg. Security

            bool generateAuthorizationMethods = projectName != "Security";

            sb.AppendLine($$"""
using Microsoft.Data.SqlClient;
using {{basePartOfNamespace}}.Entities;
using {{basePartOfNamespace}}.Extensions;
using {{basePartOfNamespace}}.Services;
using Soft.Generator.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace {{basePartOfNamespace}}.Services
{
    ///// <summary>
    ///// Every get method is returning only flat data without any related data, because of performance
    ///// When inserting data with a foreign key, only the Id field in related data is mandatory. Additionally, the Id must correspond to an existing record in the database.
    ///// </summary>
    //public class {{projectName}}BusinessServiceGenerated : BusinessServiceBase
    //{
    //    private readonly ISqlConnection _connection;

    //    public {{projectName}}BusinessServiceGenerated(ISqlConnection connection)
    //    : base(connection)
    //    {
    //        _connection = connection;
    //    }

""");
            foreach (ClassDeclarationSyntax entityClass in entityClasses)
            {
                string nameOfTheEntityClass = entityClass.Identifier.Text;
                string nameOfTheEntityClassFirstLower = entityClass.Identifier.Text.FirstCharToLower();
                SoftProperty idPropertyOfTheEntityClass = GetIdentifierProperty(entityClass, entityClasses);
                string idTypeOfTheEntityClass = idPropertyOfTheEntityClass.Type;

                List<SoftProperty> entityPropertiesWithoutEnumerable = Helper.GetAllPropertiesOfTheClass(entityClass, entityClasses, false);

                List<SoftProperty> entityPropertiesWithoutEnumerableAndId = entityPropertiesWithoutEnumerable
                    .Where(x => x.Attributes.Any(x => x.Name == "Identifier") == false)
                    .ToList();

                List<string> entityPropertiesForInsertAndUpdate = entityPropertiesWithoutEnumerableAndId
                    .Select(x => x.Type.PropTypeIsManyToOne() ? $"{x.IdentifierText}Id" : $"{x.IdentifierText}")
                    .ToList();

                string insertColumnNames = string.Join(", ", entityPropertiesForInsertAndUpdate.Select(x => $"[{x}]"));
                string insertParameterNames = string.Join(", ", entityPropertiesForInsertAndUpdate.Select(x => $"@{x}"));

                string updateParameterNames = string.Join(", ", entityPropertiesForInsertAndUpdate.Select(x => $"[{x}] = @{x}"));

                if (Helper.GetAllAttributesOfTheClass(entityClass, entityClasses).Any(x => x.Name == "ManyToMany"))
                {
                    ClassDeclarationSyntax firstPrimaryKeyClass = Helper.GetClass(entityPropertiesWithoutEnumerableAndId[0].Type, classes);
                    ClassDeclarationSyntax secondPrimaryKeyClass = Helper.GetClass(entityPropertiesWithoutEnumerableAndId[1].Type, classes);

                    SoftProperty firstPrimaryKeyClassIdProp = GetIdentifierProperty(firstPrimaryKeyClass, classes);
                    SoftProperty secondPrimaryKeyClassIdProp = GetIdentifierProperty(secondPrimaryKeyClass, classes);

                    sb.AppendLine($$"""
        #region {{nameOfTheEntityClass}}

        public class Insert{{nameOfTheEntityClass}}SO : SystemOperationBase<{{nameOfTheEntityClass}}>
        {
            private readonly {{nameOfTheEntityClass}} _entity;

            public Insert{{nameOfTheEntityClass}}SO(ISqlConnection connection, {{nameOfTheEntityClass}} entity)
                : base(connection)
            {
                _entity = entity;
            }

            public override {{nameOfTheEntityClass}} Execute()
            {
                if (_entity == null)
                    throw new Exception("Ne možete da ubacite prazan objekat.");

                // TODO FT: Server validation before a database.

                string query = $"INSERT INTO [{{nameOfTheEntityClass}}] ({{insertColumnNames}}) VALUES ({{insertParameterNames}});";

                _connection.WithTransaction(() =>
                {
                    using (SqlCommand cmd = new SqlCommand(query, _connection.GetConnection()))
                    {
                        {{string.Join("\n\t\t\t\t\t", entityPropertiesWithoutEnumerableAndId
                            .Select(x => x.Type.PropTypeIsManyToOne() ?
                                $"cmd.Parameters.AddWithValue(\"@{x.IdentifierText}Id\", _entity.{x.IdentifierText}?.{GetIdentifierProperty(x.Type, entityClasses).IdentifierText});" :
                                $"cmd.Parameters.AddWithValue(\"@{x.IdentifierText}\", _entity.{x.IdentifierText});"))}}

                        cmd.ExecuteNonQuery();
                    }
                });

                return _entity;
            }
        }

        /// <summary>
        /// TODO FT: Made for M2M with additional attributes, we should remove primary key updates from the code
        /// </summary>
        public class Update{{nameOfTheEntityClass}}SO : SystemOperationBase<{{nameOfTheEntityClass}}>
        {
            private readonly {{nameOfTheEntityClass}} _entity;

            public Update{{nameOfTheEntityClass}}SO(ISqlConnection connection, {{nameOfTheEntityClass}} entity)
                : base(connection)
            {
                _entity = entity;
            }

            public override {{nameOfTheEntityClass}} Execute()
            {
                if (_entity == null)
                    throw new Exception("Ne možete da ažurirate prazan objekat.");

                // TODO FT: Server validation before a database.

                string query = @$"
UPDATE [{{nameOfTheEntityClass}}] SET {{updateParameterNames}} 
WHERE {{entityPropertiesWithoutEnumerableAndId[0].IdentifierText}}Id = @{{entityPropertiesWithoutEnumerableAndId[0].IdentifierText.FirstCharToLower()}}Id AND {{entityPropertiesWithoutEnumerableAndId[1].IdentifierText}}Id = @{{entityPropertiesWithoutEnumerableAndId[1].IdentifierText.FirstCharToLower()}}Id
";

                _connection.WithTransaction(() =>
                {
                    using (SqlCommand cmd = new SqlCommand(query, _connection.GetConnection()))
                    {
                        {{string.Join("\n\t\t\t\t\t", entityPropertiesWithoutEnumerableAndId
                            .Select(x => x.Type.PropTypeIsManyToOne() ?
                                $"cmd.Parameters.AddWithValue(\"@{x.IdentifierText}Id\", _entity.{x.IdentifierText}?.{GetIdentifierProperty(x.Type, entityClasses).IdentifierText});" :
                                $"cmd.Parameters.AddWithValue(\"@{x.IdentifierText}\", _entity.{x.IdentifierText});"))}}

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                            throw new Exception("U sistemu nismo pronašli objekat koji želite da ažurirate.");
                    }
                });

                return _entity;
            }
        }

        public class Delete{{nameOfTheEntityClass}}SO : SystemOperationBase<{{nameOfTheEntityClass}}>
        {
            private readonly {{firstPrimaryKeyClassIdProp.Type}} _{{entityPropertiesWithoutEnumerableAndId[0].IdentifierText.FirstCharToLower()}}Id;
            private readonly {{secondPrimaryKeyClassIdProp.Type}} _{{entityPropertiesWithoutEnumerableAndId[1].IdentifierText.FirstCharToLower()}}Id;

            public Delete{{nameOfTheEntityClass}}SO(ISqlConnection connection, {{firstPrimaryKeyClassIdProp.Type}} {{entityPropertiesWithoutEnumerableAndId[0].IdentifierText.FirstCharToLower()}}Id, {{secondPrimaryKeyClassIdProp.Type}} {{entityPropertiesWithoutEnumerableAndId[1].IdentifierText.FirstCharToLower()}}Id)
                : base(connection)
            {
                _{{entityPropertiesWithoutEnumerableAndId[0].IdentifierText.FirstCharToLower()}}Id = {{entityPropertiesWithoutEnumerableAndId[0].IdentifierText.FirstCharToLower()}}Id;
                _{{entityPropertiesWithoutEnumerableAndId[1].IdentifierText.FirstCharToLower()}}Id = {{entityPropertiesWithoutEnumerableAndId[1].IdentifierText.FirstCharToLower()}}Id;
            }

            public override {{nameOfTheEntityClass}} Execute()
            {
                string query = @$"
DELETE
FROM {{nameOfTheEntityClass}}
WHERE {{entityPropertiesWithoutEnumerableAndId[0].IdentifierText}}Id = @{{entityPropertiesWithoutEnumerableAndId[0].IdentifierText.FirstCharToLower()}}Id AND {{entityPropertiesWithoutEnumerableAndId[1].IdentifierText}}Id = @{{entityPropertiesWithoutEnumerableAndId[1].IdentifierText.FirstCharToLower()}}Id
";

                _connection.WithTransaction(() =>
                {
                    using (SqlCommand cmd = new SqlCommand(query, _connection.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@{{entityPropertiesWithoutEnumerableAndId[0].IdentifierText.FirstCharToLower()}}Id", _{{entityPropertiesWithoutEnumerableAndId[0].IdentifierText.FirstCharToLower()}}Id);
                        cmd.Parameters.AddWithValue("@{{entityPropertiesWithoutEnumerableAndId[1].IdentifierText.FirstCharToLower()}}Id", _{{entityPropertiesWithoutEnumerableAndId[1].IdentifierText.FirstCharToLower()}}Id);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                            throw new Exception("U sistemu nismo pronašli objekat koji želite da obrišete.");
                    }
                });

                return null;
            }
        }

        #endregion

""");
                    
                    continue;
                }

                sb.AppendLine($$"""
        #region {{nameOfTheEntityClass}}

        public class Get{{nameOfTheEntityClass}}SO : SystemOperationBase<{{nameOfTheEntityClass}}>
        {
            {{idTypeOfTheEntityClass}} _id;

            public Get{{nameOfTheEntityClass}}SO(ISqlConnection connection, {{idTypeOfTheEntityClass}} id)
                : base(connection)
            {
                _id = id;
            }

            public override {{nameOfTheEntityClass}} Execute()
            {
                List<{{nameOfTheEntityClass}}> {{nameOfTheEntityClassFirstLower}}List = new List<{{nameOfTheEntityClass}}>();
                Dictionary<{{idTypeOfTheEntityClass}}, {{nameOfTheEntityClass}}> {{nameOfTheEntityClassFirstLower}}Dict = new Dictionary<{{idTypeOfTheEntityClass}}, {{nameOfTheEntityClass}}>();

                string query = @$"
    SELECT 
    {{string.Join(", ", GetAllPropertiesForSqlSelect(entityClass, entityClasses))}}
    FROM [{{nameOfTheEntityClass}}] AS [{{nameOfTheEntityClassFirstLower}}]
    {{string.Join("\n", GetManyToOneFirstLevelSqlJoins(entityClass, entityClasses))}}
    WHERE [{{nameOfTheEntityClassFirstLower}}].[{{idPropertyOfTheEntityClass.IdentifierText}}] = @id
    ";

                _connection.WithTransaction(() =>
                {
                    using (SqlCommand cmd = new SqlCommand(query, _connection.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@id", _id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
    {{FillData(entityClass, entityClasses)}}
                            }
                        }
                    }
                });

                {{nameOfTheEntityClass}} {{nameOfTheEntityClassFirstLower}} = {{nameOfTheEntityClassFirstLower}}List.SingleOrDefault();

                if ({{nameOfTheEntityClassFirstLower}} == null)
                    throw new Exception("Objekat ne postoji u bazi podataka.");

                return {{nameOfTheEntityClassFirstLower}};
            }
        }

        public class Get{{nameOfTheEntityClass}}ListSO : SystemOperationBase<List<{{nameOfTheEntityClass}}>>
        {
            public Get{{nameOfTheEntityClass}}ListSO(ISqlConnection connection)
                : base(connection)
            {

            }

            public override List<{{nameOfTheEntityClass}}> Execute()
            {
                List<{{nameOfTheEntityClass}}> {{nameOfTheEntityClassFirstLower}}List = new List<{{nameOfTheEntityClass}}>();
                Dictionary<{{idTypeOfTheEntityClass}}, {{nameOfTheEntityClass}}> {{nameOfTheEntityClassFirstLower}}Dict = new Dictionary<{{idTypeOfTheEntityClass}}, {{nameOfTheEntityClass}}>();

                string query = @$"
SELECT 
{{string.Join(", ", GetAllPropertiesForSqlSelect(entityClass, entityClasses))}}
FROM [{{nameOfTheEntityClass}}] AS [{{nameOfTheEntityClassFirstLower}}]
{{string.Join("\n", GetManyToOneFirstLevelSqlJoins(entityClass, entityClasses))}}
";

                _connection.WithTransaction(() =>
                {
                    using (SqlCommand cmd = new SqlCommand(query, _connection.GetConnection()))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
{{FillData(entityClass, entityClasses)}}
                            }
                        }
                    }
                });

                return {{nameOfTheEntityClassFirstLower}}List;
            }
        }

{{string.Join("\n\n", GetListMethodsWithFilters(entityClass, entityClasses))}}

        public class Insert{{nameOfTheEntityClass}}SO : SystemOperationBase<{{nameOfTheEntityClass}}>
        {
            private readonly {{nameOfTheEntityClass}} _entity;

            public Insert{{nameOfTheEntityClass}}SO(ISqlConnection connection, {{nameOfTheEntityClass}} entity)
                : base(connection)
            {
                _entity = entity;
            }

            public override {{nameOfTheEntityClass}} Execute()
            {
                if (_entity == null)
                    throw new Exception("Ne možete da ubacite prazan objekat.");

                // TODO FT: Server validation before a database.

                string query = $"INSERT INTO [{{nameOfTheEntityClass}}] ({{insertColumnNames}}) OUTPUT INSERTED.[{{idPropertyOfTheEntityClass.IdentifierText}}] VALUES ({{insertParameterNames}});";

                _connection.WithTransaction(() =>
                {
                    using (SqlCommand cmd = new SqlCommand(query, _connection.GetConnection()))
                    {
                        {{string.Join("\n\t\t\t\t\t", entityPropertiesWithoutEnumerableAndId
                            .Select(x => x.Type.PropTypeIsManyToOne() ?
                                $"cmd.Parameters.AddWithValue(\"@{x.IdentifierText}Id\", _entity.{x.IdentifierText}?.{GetIdentifierProperty(x.Type, entityClasses).IdentifierText});" :
                                $"cmd.Parameters.AddWithValue(\"@{x.IdentifierText}\", _entity.{x.IdentifierText});"))}}

                        {{idTypeOfTheEntityClass}} newId = ({{idTypeOfTheEntityClass}})cmd.ExecuteScalar();
                        _entity.{{idPropertyOfTheEntityClass.IdentifierText}} = newId;
                    }
                });

                return _entity;
            }
        }

        public class Update{{nameOfTheEntityClass}}SO : SystemOperationBase<{{nameOfTheEntityClass}}>
        {
            private readonly {{nameOfTheEntityClass}} _entity;

            public Update{{nameOfTheEntityClass}}SO(ISqlConnection connection, {{nameOfTheEntityClass}} entity)
                : base(connection)
            {
                _entity = entity;
            }

            public override {{nameOfTheEntityClass}} Execute()
            {
                if (_entity == null)
                    throw new Exception("Ne možete da ažurirate prazan objekat.");

                // TODO FT: Server validation before a database.

                string query = $"UPDATE [{{nameOfTheEntityClass}}] SET {{updateParameterNames}} WHERE [{{idPropertyOfTheEntityClass.IdentifierText}}] = @{{idPropertyOfTheEntityClass.IdentifierText}};";

                _connection.WithTransaction(() =>
                {
                    using (SqlCommand cmd = new SqlCommand(query, _connection.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@{{idPropertyOfTheEntityClass.IdentifierText}}", _entity.{{idPropertyOfTheEntityClass.IdentifierText}});
                        {{string.Join("\n\t\t\t\t\t", entityPropertiesWithoutEnumerableAndId.Select(x => x.Type.PropTypeIsManyToOne() ? $"cmd.Parameters.AddWithValue(\"@{x.IdentifierText}Id\", _entity.{x.IdentifierText}?.{GetIdentifierProperty(x.Type, entityClasses).IdentifierText});" : $"cmd.Parameters.AddWithValue(\"@{x.IdentifierText}\", _entity.{x.IdentifierText});"))}}

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                            throw new Exception("U sistemu nismo pronašli objekat koji želite da ažurirate.");
                    }
                });

                return _entity;
            }
        }

        public class Save{{nameOfTheEntityClass}}SO : SystemOperationBase<{{nameOfTheEntityClass}}>
        {
            private readonly {{nameOfTheEntityClass}} _entity;

            public Save{{nameOfTheEntityClass}}SO(ISqlConnection connection, {{nameOfTheEntityClass}} entity)
                : base(connection)
            {
                _entity = entity;
            }

            public override {{nameOfTheEntityClass}} Execute()
            {
                if (_entity == null)
                    throw new Exception("Ne možete da sačuvate prazan objekat.");

                if (_entity.Id > 0)
                {
                    var updateOperation = new Update{{nameOfTheEntityClass}}SO(_connection, _entity);
                    return updateOperation.Execute();
                }
                else if (_entity.Id == 0)
                {
                    var insertOperation = new Insert{{nameOfTheEntityClass}}SO(_connection, _entity);
                    return insertOperation.Execute();
                }
                else
                {
                    throw new InvalidOperationException("Vrednost identifikatora ne sme biti negativna.");
                }
            }
        }

        public class Delete{{nameOfTheEntityClass}}SO : SystemOperationBase<{{nameOfTheEntityClass}}>
        {
            private readonly {{idTypeOfTheEntityClass}} _id;

            public Delete{{nameOfTheEntityClass}}SO(ISqlConnection connection, {{idTypeOfTheEntityClass}} id)
                : base(connection)
            {
                _id = id;
            }

            public override {{nameOfTheEntityClass}} Execute()
            {
                _connection.WithTransaction(() =>
                {
{{string.Join("\n", GetManyToOneDeleteQueries(entityClass, entityClasses, null, 0))}}

                    new BusinessServiceBase(_connection).DeleteEntity<{{nameOfTheEntityClass}}, {{idTypeOfTheEntityClass}}>(_id);
                });

                return null;
            }
        }

        #endregion

""");
            }

            sb.Append($$"""
    //}
}
""");

            context.AddSource($"{projectName}BusinessService.generated", SourceText.From(sb.ToString(), Encoding.UTF8));
        }

        private static List<string> GetListMethodsWithFilters(ClassDeclarationSyntax entityClass, IList<ClassDeclarationSyntax> entityClasses)
        {
            List<string> result = new();

            string nameOfTheEntityClass = entityClass.Identifier.Text;
            string nameOfTheEntityClassFirstLower = entityClass.Identifier.Text.FirstCharToLower();
            string idTypeOfTheEntityClass = GetIdType(entityClass, entityClasses);

            List<SoftProperty> entityProperties = Helper.GetAllPropertiesOfTheClass(entityClass, entityClasses, true);

            foreach (SoftProperty entityProperty in entityProperties)
            {
                if (entityProperty.Type.IsEnumerable())
                {
                    ClassDeclarationSyntax extractedEntityClass = Helper.ExtractEntityFromList(entityProperty.Type, entityClasses);
                    SoftProperty extractedEntityIdProperty = GetIdentifierProperty(extractedEntityClass, entityClasses);

                    if (entityProperty.Attributes.Any(x => x.Name == "ManyToMany"))
                    {
                        string manyToManyName = entityProperty.Attributes.Where(x => x.Name == "ManyToMany").Select(x => x.Value).SingleOrDefault();

                        result.Add($$"""
        public class Update{{manyToManyName}}ListFor{{nameOfTheEntityClass}}SO : SystemOperationBase<{{nameOfTheEntityClass}}>
        {
            private readonly {{nameOfTheEntityClass}} _{{nameOfTheEntityClassFirstLower}};
            private readonly List<{{extractedEntityIdProperty.Type}}> _selected{{extractedEntityClass.Identifier.Text}}Ids;

            public Update{{manyToManyName}}ListFor{{nameOfTheEntityClass}}SO(ISqlConnection connection, {{nameOfTheEntityClass}} {{nameOfTheEntityClassFirstLower}}, List<{{extractedEntityIdProperty.Type}}> selected{{extractedEntityClass.Identifier.Text}}Ids)
                : base(connection)
            {
                _{{nameOfTheEntityClassFirstLower}} = {{nameOfTheEntityClassFirstLower}};
                _selected{{extractedEntityClass.Identifier.Text}}Ids = selected{{extractedEntityClass.Identifier.Text}}Ids;
            }

            public override {{nameOfTheEntityClass}} Execute()
            {
                if (_selected{{extractedEntityClass.Identifier.Text}}Ids == null)
                    return null;

                List<{{extractedEntityIdProperty.Type}}> selectedIdsHelper = _selected{{extractedEntityClass.Identifier.Text}}Ids.ToList();

                _connection.WithTransaction(() =>
                {
                    // FT: Not doing authorization here, because we can not figure out here if we are updating while inserting object (eg. User), or updating object, we will always get the id which is not 0 here.

                    List<{{extractedEntityClass.Identifier.Text}}> {{extractedEntityClass.Identifier.Text.FirstCharToLower()}}List = new Get{{extractedEntityClass.Identifier.Text}}ListFor{{nameOfTheEntityClass}}ListSO(_connection, new List<{{extractedEntityIdProperty.Type}}> { _{{nameOfTheEntityClassFirstLower}}.Id }).Execute();

                    foreach ({{extractedEntityClass.Identifier.Text}} {{extractedEntityClass.Identifier.Text.FirstCharToLower()}} in {{extractedEntityClass.Identifier.Text.FirstCharToLower()}}List.ToList())
                    {
                        if (selectedIdsHelper.Contains({{extractedEntityClass.Identifier.Text.FirstCharToLower()}}.Id))
                            selectedIdsHelper.Remove({{extractedEntityClass.Identifier.Text.FirstCharToLower()}}.Id);
                        else
                            new Delete{{manyToManyName}}SO(_connection, _{{nameOfTheEntityClassFirstLower}}.Id, {{extractedEntityClass.Identifier.Text.FirstCharToLower()}}.Id).Execute();
                    }

                    List<{{extractedEntityClass.Identifier.Text}}> {{extractedEntityClass.Identifier.Text.FirstCharToLower()}}ListToInsert = new Get{{extractedEntityClass.Identifier.Text}}ListSO(_connection)
                        .Execute()
                        .Where(x => selectedIdsHelper.Contains(x.Id))
                        .ToList(); // TODO FT: Add this to the generator so it is working in the SQL

                    foreach ({{extractedEntityClass.Identifier.Text}} {{extractedEntityClass.Identifier.Text.FirstCharToLower()}}ToInsert in {{extractedEntityClass.Identifier.Text.FirstCharToLower()}}ListToInsert)
                    {
                        new Insert{{manyToManyName}}SO(_connection, new {{manyToManyName}}
                        {
                            {{nameOfTheEntityClass}} = _{{nameOfTheEntityClassFirstLower}},
                            {{extractedEntityClass.Identifier.Text}} = {{extractedEntityClass.Identifier.Text.FirstCharToLower()}}ToInsert
                        }).Execute();
                    }
                });

                return null;
            }
        }
""");
                    }

                    result.Add($$"""
        public class Get{{nameOfTheEntityClass}}ListFor{{extractedEntityClass.Identifier.Text}}ListSO : SystemOperationBase<List<{{nameOfTheEntityClass}}>>
        {
            private readonly List<{{extractedEntityIdProperty.Type}}> _ids;

            public Get{{nameOfTheEntityClass}}ListFor{{extractedEntityClass.Identifier.Text}}ListSO(ISqlConnection connection, List<{{extractedEntityIdProperty.Type}}> ids)
                : base(connection)
            {
                _ids = ids;
            }

            public override List<{{nameOfTheEntityClass}}> Execute()
            {
                List<{{nameOfTheEntityClass}}> {{nameOfTheEntityClassFirstLower}}List = new List<{{nameOfTheEntityClass}}>();
                Dictionary<{{idTypeOfTheEntityClass}}, {{nameOfTheEntityClass}}> {{nameOfTheEntityClassFirstLower}}Dict = new Dictionary<{{idTypeOfTheEntityClass}}, {{nameOfTheEntityClass}}>();

                if (_ids == null || _ids.Count == 0)
                    throw new ArgumentException("Lista po kojoj želite da filtrirate ne može da bude prazna.");

                List<string> parameters = new List<string>();
                for (int i = 0; i < _ids.Count; i++)
                {
                    parameters.Add($"@id{i}");
                }

                string query = @$"
SELECT DISTINCT
{{string.Join(", ", GetAllPropertiesForSqlSelect(entityClass, entityClasses))}}
FROM [{{nameOfTheEntityClass}}] AS [{{nameOfTheEntityClassFirstLower}}]
{{GetJoinBasedOnPropertyListType(entityProperty, entityClass, entityClasses)}}
WHERE [{{extractedEntityClass.Identifier.Text.FirstCharToLower()}}].[{{extractedEntityIdProperty.IdentifierText}}] IN ({string.Join(", ", parameters)});
";

                _connection.WithTransaction(() =>
                {
                    using (SqlCommand cmd = new SqlCommand(query, _connection.GetConnection()))
                    {
                        for (int i = 0; i < _ids.Count; i++)
                        {
                            cmd.Parameters.AddWithValue($"@id{i}", _ids[i]);
                        }

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
{{FillData(entityClass, entityClasses)}}
                            }
                        }
                    }
                });

                return {{nameOfTheEntityClassFirstLower}}List;
            }
        }
""");
                }
                else if (entityProperty.Type.PropTypeIsManyToOne())
                {
                    ClassDeclarationSyntax extractedEntityClass = Helper.GetClass(entityProperty.Type, entityClasses);
                    string extractedEntityIdType = GetIdType(extractedEntityClass, entityClasses);

                    result.Add($$"""
        public class Get{{nameOfTheEntityClass}}ListFor{{extractedEntityClass.Identifier.Text}}SO : SystemOperationBase<List<{{nameOfTheEntityClass}}>>
        {
            private readonly {{extractedEntityIdType}} _id;

            public Get{{nameOfTheEntityClass}}ListFor{{extractedEntityClass.Identifier.Text}}SO(ISqlConnection connection, {{extractedEntityIdType}} id)
                : base(connection)
            {
                _id = id;
            }

            public override List<{{nameOfTheEntityClass}}> Execute()
            {
                List<{{nameOfTheEntityClass}}> {{nameOfTheEntityClassFirstLower}}List = new List<{{nameOfTheEntityClass}}>();
                Dictionary<{{idTypeOfTheEntityClass}}, {{nameOfTheEntityClass}}> {{nameOfTheEntityClassFirstLower}}Dict = new Dictionary<{{idTypeOfTheEntityClass}}, {{nameOfTheEntityClass}}>();

                string query = @$"
SELECT
{{string.Join(", ", GetAllPropertiesForSqlSelect(entityClass, entityClasses))}}
FROM [{{nameOfTheEntityClass}}] AS [{{nameOfTheEntityClassFirstLower}}]
{{string.Join("\n", GetManyToOneFirstLevelSqlJoins(entityClass, entityClasses))}}
WHERE [{{nameOfTheEntityClassFirstLower}}].[{{extractedEntityClass.Identifier.Text}}Id] = @id;
";

                _connection.WithTransaction(() =>
                {
                    using (SqlCommand cmd = new SqlCommand(query, _connection.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@id", _id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
{{FillData(entityClass, entityClasses)}}
                            }
                        }
                    }
                });

                return {{nameOfTheEntityClassFirstLower}}List;
            }
        }
""");
                }
            }

            return result;
        }

        private static string FillData(ClassDeclarationSyntax entityClass, IList<ClassDeclarationSyntax> entityClasses)
        {
            string nameOfTheEntityClass = entityClass.Identifier.Text;
            string nameOfTheEntityClassFirstLower = entityClass.Identifier.Text.FirstCharToLower();
            string idTypeOfTheEntityClass = GetIdType(entityClass, entityClasses);

            StringBuilder sb = new StringBuilder();

            sb.Append($$"""
                            {{idTypeOfTheEntityClass}} {{nameOfTheEntityClassFirstLower}}Id = reader.{{GetReaderParseMethodForType(idTypeOfTheEntityClass)}}(reader.GetOrdinal("{{nameOfTheEntityClass}}Id"));
                            bool {{nameOfTheEntityClassFirstLower}}AlreadyAdded = {{nameOfTheEntityClassFirstLower}}Dict.TryGetValue({{nameOfTheEntityClassFirstLower}}Id, out {{nameOfTheEntityClass}} {{nameOfTheEntityClassFirstLower}});
                            if (!{{nameOfTheEntityClassFirstLower}}AlreadyAdded)
                            {
                                {{nameOfTheEntityClassFirstLower}} = new {{nameOfTheEntityClass}}
                                {
                                    {{string.Join(",\n\t\t\t\t\t\t\t\t\t", GetClassInitialization(entityClass, entityClasses, null, null))}}
                                };

                                {{nameOfTheEntityClassFirstLower}}Dict[{{nameOfTheEntityClassFirstLower}}Id] = {{nameOfTheEntityClassFirstLower}};

{{string.Join("\n\n", FillManyToOneFirstLevelData(entityClass, entityClasses))}}

                                {{nameOfTheEntityClassFirstLower}}List.Add({{nameOfTheEntityClassFirstLower}});
                            }
""");

            return sb.ToString();
        }

        private static List<string> FillManyToOneFirstLevelData(ClassDeclarationSyntax entityClass, IList<ClassDeclarationSyntax> entityClasses)
        {
            List<string> result = new List<string>();

            string nameOfTheEntityClass = entityClass.Identifier.Text;
            string nameOfTheEntityClassFirstLower = entityClass.Identifier.Text.FirstCharToLower();

            List<SoftProperty> entityPropertiesForTheJoin = Helper.GetAllPropertiesOfTheClass(entityClass, entityClasses, true).Where(x => x.Type.PropTypeIsManyToOne()).ToList();

            foreach (SoftProperty property in entityPropertiesForTheJoin)
            {
                ClassDeclarationSyntax manyToOneEntity = Helper.GetClass(property.Type, entityClasses);

                result.Add($$"""
                            if (!reader.IsDBNull(reader.GetOrdinal("{{nameOfTheEntityClass}}{{property.IdentifierText}}Id")))
                            {
                                {{nameOfTheEntityClassFirstLower}}.{{property.IdentifierText}} = new {{property.Type}}
                                {
                                    {{string.Join(",\n\t\t\t\t\t\t\t\t\t", GetClassInitialization(manyToOneEntity, entityClasses, property, nameOfTheEntityClass))}}
                                };
                            }
""");
            }

            return result;
        }

        private static List<string> GetClassInitialization(ClassDeclarationSyntax entityClass, IList<ClassDeclarationSyntax> entityClasses, SoftProperty manyToOneProperty, string parentClassName)
        {
            List<string> result = new List<string>();

            string nameOfTheEntityClass = entityClass.Identifier.Text;
            string nameOfTheEntityClassFirstLower = entityClass.Identifier.Text.FirstCharToLower();
            string idTypeOfTheEntityClass = GetIdType(entityClass, entityClasses);

            List<SoftProperty> entityProperties = Helper.GetAllPropertiesOfTheClass(entityClass, entityClasses, false);

            foreach (SoftProperty entityProperty in entityProperties)
            {
                if (entityProperty.IsIdentifier())
                {
                    if (manyToOneProperty == null && parentClassName == null)
                        result.Add($"{entityProperty.IdentifierText} = {nameOfTheEntityClassFirstLower}Id");
                    else
                        result.Add($"{entityProperty.IdentifierText} = reader.{GetReaderParseMethodForType(idTypeOfTheEntityClass)}(reader.GetOrdinal(\"{parentClassName}{manyToOneProperty.IdentifierText}Id\"))");
                }
                else if (entityProperty.Type.IsEnumerable() || entityProperty.Type.PropTypeIsManyToOne())
                {
                    continue;
                    //result.Add($"{entityProperty.IdentifierText} = new {entityProperty.Type}()");
                }
                else
                {
                    if (manyToOneProperty == null && parentClassName == null)
                        result.Add($"{entityProperty.IdentifierText} = reader.{GetReaderParseMethodForType(entityProperty.Type)}(reader.GetOrdinal(\"{nameOfTheEntityClass}{entityProperty.IdentifierText}\"))");
                    else
                        result.Add($"{entityProperty.IdentifierText} = reader.{GetReaderParseMethodForType(entityProperty.Type)}(reader.GetOrdinal(\"{parentClassName}{manyToOneProperty.IdentifierText}{entityProperty.IdentifierText}\"))");
                }
            }

            return result;
        }

        private static List<string> GetAllPropertiesForSqlSelect(ClassDeclarationSyntax entityClass, IList<ClassDeclarationSyntax> entityClasses)
        {
            string nameOfTheEntityClass = entityClass.Identifier.Text;

            string nameOfTheEntityClassFirstLower = entityClass.Identifier.Text.FirstCharToLower();

            List<string> result = new List<string>();

            List<SoftProperty> entityProperties = Helper.GetAllPropertiesOfTheClass(entityClass, entityClasses, false);

            foreach (SoftProperty property in entityProperties)
            {
                if (property.Type.PropTypeIsManyToOne())
                {
                    ClassDeclarationSyntax manyToOneEntity = Helper.GetClass(property.Type, entityClasses);
                    List<SoftProperty> manyToOneEntityProperties = Helper.GetAllPropertiesOfTheClass(manyToOneEntity, entityClasses, false);

                    foreach (SoftProperty manyToOneProperty in manyToOneEntityProperties)
                    {
                        if (manyToOneProperty.IsIdentifier())
                        {
                            result.Add($"[{nameOfTheEntityClassFirstLower}].[{property.IdentifierText}Id] AS [{nameOfTheEntityClass}{property.IdentifierText}Id]");
                        }
                        else if (manyToOneProperty.Type.PropTypeIsManyToOne())
                        {
                            continue;
                        }
                        else
                        {
                            result.Add($"[{nameOfTheEntityClassFirstLower}{manyToOneEntity.Identifier.Text}].[{manyToOneProperty.IdentifierText}] AS [{nameOfTheEntityClass}{property.IdentifierText}{manyToOneProperty.IdentifierText}]");
                        }
                    }
                }
                else
                {
                    result.Add($"[{nameOfTheEntityClassFirstLower}].[{property.IdentifierText}] AS [{nameOfTheEntityClass}{property.IdentifierText}]");
                }
            }

            return result;
        }

        private static List<string> GetManyToOneFirstLevelSqlJoins(ClassDeclarationSyntax entityClass, IList<ClassDeclarationSyntax> entityClasses)
        {
            string nameOfTheEntityClass = entityClass.Identifier.Text;
            string nameOfTheEntityClassFirstLower = entityClass.Identifier.Text.FirstCharToLower();
            SoftProperty identifierPropertyOfTheEntityClass = GetIdentifierProperty(entityClass, entityClasses);

            List<string> result = new List<string>();

            List<SoftProperty> entityProperties = Helper.GetAllPropertiesOfTheClass(entityClass, entityClasses, true);

            foreach (SoftProperty property in entityProperties)
            {
                // TODO FT: Add the logic for the different names of the association
                if (property.Type.PropTypeIsManyToOne())
                {
                    ClassDeclarationSyntax manyToOneEntity = Helper.GetClass(property.Type, entityClasses);

                    result.Add($$"""
LEFT JOIN [{{manyToOneEntity.Identifier.Text}}] AS [{{nameOfTheEntityClassFirstLower}}{{property.IdentifierText}}] ON [{{nameOfTheEntityClassFirstLower}}{{property.IdentifierText}}].[{{identifierPropertyOfTheEntityClass.IdentifierText}}] = [{{nameOfTheEntityClass}}].[{{property.IdentifierText}}Id]
""");
                }
            }

            return result;
        }

        private static string GetJoinBasedOnPropertyListType(SoftProperty entityProperty, ClassDeclarationSyntax entityClass, IList<ClassDeclarationSyntax> entityClasses)
        {
            ClassDeclarationSyntax extractedEntityClass = Helper.ExtractEntityFromList(entityProperty.Type, entityClasses);
            string nameOfTheEntityClass = entityClass.Identifier.Text;
            string nameOfTheEntityClassFirstLower = entityClass.Identifier.Text.FirstCharToLower();
            SoftProperty identifierPropertyOfTheEntityClass = GetIdentifierProperty(entityClass, entityClasses);

            //string extractedEntityIdType = GetIdType(extractedEntityClass, entityClasses);
            SoftProperty extractedEntityIdentifierProperty = GetIdentifierProperty(extractedEntityClass, entityClasses);

            string manyToManyValue = entityProperty.Attributes.Where(x => x.Name == "ManyToMany").Select(x => x.Value).SingleOrDefault();

            if (manyToManyValue == null)
            {
                return $$"""
LEFT JOIN [{{extractedEntityClass.Identifier.Text}}] AS [{{extractedEntityClass.Identifier.Text.FirstCharToLower()}}] on [{{extractedEntityClass.Identifier.Text.FirstCharToLower()}}].[{{nameOfTheEntityClass}}Id] = [{{nameOfTheEntityClassFirstLower}}].[{{identifierPropertyOfTheEntityClass.IdentifierText}}]
""";
            }
            else
            {
                return $$"""
LEFT JOIN [{{manyToManyValue}}] AS [{{manyToManyValue.FirstCharToLower()}}] on [{{manyToManyValue.FirstCharToLower()}}].[{{nameOfTheEntityClass}}Id] = [{{nameOfTheEntityClassFirstLower}}].[{{identifierPropertyOfTheEntityClass.IdentifierText}}]
LEFT JOIN [{{extractedEntityClass.Identifier.Text}}] AS [{{extractedEntityClass.Identifier.Text.FirstCharToLower()}}] on [{{extractedEntityClass.Identifier.Text.FirstCharToLower()}}].[{{extractedEntityIdentifierProperty.IdentifierText}}] = [{{manyToManyValue.FirstCharToLower()}}].[{{extractedEntityClass.Identifier.Text}}Id]
""";
            }
        }

        private static List<string> GetManyToOneDeleteQueries(ClassDeclarationSyntax entityClass, IList<ClassDeclarationSyntax> entityClasses, string parentNameOfTheEntityClass, int recursiveIteration)
        {
            if (recursiveIteration > 5000)
            {
                GetManyToOneDeleteQueries(null, null, null, int.MaxValue);
                return new List<string> { "You made cascade delete infinite loop." };
            }

            List<string> result = new List<string>();

            string nameOfTheEntityClass = entityClass.Identifier.Text;
            string nameOfTheEntityClassFirstLower = nameOfTheEntityClass.FirstCharToLower();
            SoftProperty identifierPropertyOfTheEntityClass = GetIdentifierProperty(entityClass, entityClasses);

            List<SoftClass> softEntityClasses = Helper.GetSoftEntityClasses(entityClasses);

            List<SoftProperty> manyToOneRequiredProperties = Helper.GetManyToOneRequiredProperties(nameOfTheEntityClass, softEntityClasses);

            foreach (SoftProperty prop in manyToOneRequiredProperties)
            {
                ClassDeclarationSyntax nestedEntityClass = Helper.GetClass(prop.ClassIdentifierText, entityClasses);
                string nestedEntityClassName = nestedEntityClass.Identifier.Text;
                string nestedEntityClassNameLowerCase = nestedEntityClassName.FirstCharToLower();
                SoftProperty nestedEntityClassIdentifierProperty = GetIdentifierProperty(nestedEntityClass, entityClasses);

                if (recursiveIteration == 0)
                {
                    result.Add($$"""
                List<{{nestedEntityClassIdentifierProperty.Type}}> {{nameOfTheEntityClassFirstLower}}{{nestedEntityClassName}}ListToDelete = new Get{{nestedEntityClassName}}ListFor{{nameOfTheEntityClass}}SO(_connection, _id)
                    .Execute()
                    .Select(x => x.{{identifierPropertyOfTheEntityClass.IdentifierText}})
                    .ToList();
""");
                }
                else
                {
                    SoftProperty parentEntityClassIdentifierProperty = GetIdentifierProperty(parentNameOfTheEntityClass, entityClasses);

                    result.Add($$"""
                List<{{nestedEntityClassIdentifierProperty.Type}}> {{nameOfTheEntityClassFirstLower}}{{nestedEntityClassName}}ListToDelete = new Get{{nestedEntityClassName}}ListSO(_connection)
                    .Execute()
                    .Where(x => {{parentNameOfTheEntityClass.FirstCharToLower()}}{{nameOfTheEntityClass}}ListToDelete.Contains(x.{{prop.IdentifierText}}.{{nestedEntityClassIdentifierProperty.IdentifierText}})).Select(x => x.{{parentEntityClassIdentifierProperty.IdentifierText}}).ToList();
""");
                }

                result.AddRange(GetManyToOneDeleteQueries(nestedEntityClass, entityClasses, nameOfTheEntityClass, recursiveIteration + 1));

                result.Add($$"""
                new BusinessServiceBase(_connection).DeleteEntities<{{nestedEntityClassName}}, {{nestedEntityClassIdentifierProperty.Type}}>({{nameOfTheEntityClassFirstLower}}{{nestedEntityClassName}}ListToDelete);
""");
            }

            return result;
        }

        private static string GetReaderParseMethodForType(string type)
        {
            if (type == "byte" || type == "byte?")
                return "GetInt16";
            else if (type == "int" || type == "int?")
                return "GetInt32";
            else if (type == "long" || type == "long?")
                return "GetInt64";
            else if (type == "string")
                return "GetString";
            else if (type == "bool" || type == "bool?")
                return "GetBoolean";

            return "NotSupportedType";
        }

        public static string GetIdType(ClassDeclarationSyntax entityClass, IList<ClassDeclarationSyntax> entityClasses)
        {
            List<SoftProperty> entityProperties = Helper.GetAllPropertiesOfTheClass(entityClass, entityClasses, true);

            string idType = entityProperties.Where(x => x.IdentifierText == "Id").Select(x => x.Type).SingleOrDefault();

            if (idType == null)
                return "YouNeedToSpecifyIdInsideEntity";

            return idType;
        }

        public static SoftProperty GetIdentifierProperty(ClassDeclarationSyntax entityClass, IList<ClassDeclarationSyntax> entityClasses)
        {
            List<SoftProperty> entityProperties = Helper.GetAllPropertiesOfTheClass(entityClass, entityClasses, true);

            SoftProperty idProperty = entityProperties.Where(x => x.Attributes.Any(x => x.Name == "Identifier")).SingleOrDefault();

            if (idProperty == null)
            {
                return new SoftProperty
                {
                    IdentifierText = "YouNeedToSpecifyIdentifierInsideEntity",
                    Type = "NoType"
                };
            }

            return idProperty;
        }

        public static SoftProperty GetIdentifierProperty(string nameOfTheEntityClass, IList<ClassDeclarationSyntax> entityClasses)
        {
            ClassDeclarationSyntax entityClass = Helper.GetClass(nameOfTheEntityClass, entityClasses);
            List<SoftProperty> entityProperties = Helper.GetAllPropertiesOfTheClass(entityClass, entityClasses, true);

            SoftProperty idProperty = entityProperties.Where(x => x.Attributes.Any(x => x.Name == "Identifier")).SingleOrDefault();

            if (idProperty == null)
            {
                return new SoftProperty
                {
                    IdentifierText = "YouNeedToSpecifyIdentifierInsideEntity",
                    Type = "NoType"
                };
            }

            return idProperty;
        }
    }
}