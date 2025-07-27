using Microsoft.Data.SqlClient;
using Soft.Generator.DesktopApp.Extensions;
using Soft.Generator.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Generator.DesktopApp.Services
{
    /// <summary>
    /// TODO FT: Put this into library
    /// </summary>
    public class BusinessServiceBase
    {
        private readonly ISqlConnection _connection;

        public BusinessServiceBase(ISqlConnection connection)
        {
            _connection = connection;
        }

        public void DeleteEntity<TEntity, ID>(ID id)
            where TEntity : class
            where ID : struct
        {
            string query = @$"
DELETE
FROM {typeof(TEntity).Name}
WHERE Id = @id
";

            _connection.WithTransaction(() =>
            {
                using (SqlCommand cmd = new SqlCommand(query, _connection.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                        throw new Exception("U sistemu nismo pronašli objekat koji želite da obrišete.");
                }
            });
        }

        public void DeleteEntities<TEntity, ID>(List<ID> ids)
            where TEntity : class
            where ID : struct
        {
            if (ids == null)
                throw new ArgumentNullException("Morate da prosledite listu.");

            if (ids.Count == 0)
                return;

            List<string> parameters = new();
            for (int i = 0; i < ids.Count; i++)
            {
                parameters.Add($"@id{i}");
            }

            string query = @$"
DELETE FROM {typeof(TEntity).Name}
WHERE Id IN ({string.Join(", ", parameters)});";

            _connection.WithTransaction(() =>
            {
                using (SqlCommand cmd = new SqlCommand(query, _connection.GetConnection()))
                {
                    for (int i = 0; i < ids.Count; i++)
                    {
                        cmd.Parameters.AddWithValue($"@id{i}", ids[i]);
                    }

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                        throw new Exception("U sistemu nismo pronašli objekat koji želite da obrišete.");
                }
            });

        }
    }
}
