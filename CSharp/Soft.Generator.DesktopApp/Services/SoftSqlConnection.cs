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
    public class SoftSqlConnection : ISqlConnection
    {
        SqlConnection _connection;

        public SoftSqlConnection(SqlConnection connection) 
        {
            _connection = connection;
        }

        public SqlTransaction BeginTransaction()
        {
            return _connection.BeginTransaction();
        }

        public void Close()
        {
            _connection.Close();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }

        public SqlConnection GetConnection()
        {
            return _connection;
        }

        public void Open()
        {
            _connection.Open();
        }

        public T WithTransaction<T>(Func<T> action)
        {
            return _connection.WithTransaction(action);
        }

        public void WithTransaction(Action action)
        {
            _connection.WithTransaction(action);
        }
    }
}
