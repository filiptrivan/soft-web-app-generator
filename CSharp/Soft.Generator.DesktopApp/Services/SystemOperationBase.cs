using Microsoft.Data.SqlClient;
using Soft.Generator.DesktopApp.Interfaces;
using Soft.Generator.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Generator.DesktopApp.Services
{
    public class SystemOperationBase<T> 
        where T : class
    {
        public ISqlConnection _connection;

        public SystemOperationBase(ISqlConnection connection) 
        { 
            _connection = connection;
        }
        
        public virtual T Execute()
        {
            return null;
        }

        public virtual T Execute(T entity)
        {
            return null;
        }
    }
}
