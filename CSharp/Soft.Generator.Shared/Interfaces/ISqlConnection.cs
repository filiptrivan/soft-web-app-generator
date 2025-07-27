using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Generator.Shared.Interfaces
{
    public interface ISqlConnection 
    {
        void Open();
        void Close();
        SqlTransaction BeginTransaction();
        void Dispose();
        SqlConnection GetConnection();
        T WithTransaction<T>(Func<T> action);
        void WithTransaction(Action action);
    }
}
