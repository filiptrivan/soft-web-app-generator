using Microsoft.Data.SqlClient;
using Soft.Generator.DesktopApp.Entities;
using Soft.Generator.DesktopApp.Extensions;
using Soft.Generator.DesktopApp.Services;
using Soft.Generator.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Soft.Generator.Tests.Services
{
    public class DesktopAppBusinessServiceTests
    {
        [Fact]
        public void Login_WithValidCredentials()
        {
            TestDesktopAppBusinessService testService = new();

            Company login = new Company { Email = "test@mail.com", Password = "pass" };

            Company result = testService.Login(login);

            Assert.NotNull(result);
        }

        [Fact]
        public void Login_WithInvalidCredentials()
        {
            TestDesktopAppBusinessService testService = new();

            Company login = new Company { Email = "invalid@mail.com", Password = "pass" };

            Assert.Throws<Exception>(() => testService.Login(login));
        }

        [Fact]
        public void SavePermission_WithNullEntity_ThrowsException()
        {
            TestDesktopAppBusinessService testService = new();

            Assert.Throws<Exception>(() => testService.SavePermission(null)); // Because of the null entity
        }

        [Fact]
        public void SavePermission_WithNegativeId_ThrowsInvalidOperationException()
        {
            TestDesktopAppBusinessService testService = new();

            Permission entity = new Permission
            {
                Id = -1,
                Name = "Invalid",
                Code = "INV"
            };

            Assert.Throws<InvalidOperationException>(() => testService.SavePermission(entity)); // Because of the negative Id
        }
    }

    public class TestDesktopAppBusinessService : DesktopAppBusinessService
    {
        public TestDesktopAppBusinessService()
            : base(new TestSoftSqlConnection())
        {
        }

        public override List<Company> GetCompanyList()
        {
            return new List<Company>
            {
                new Company { Id = 1, Email = "test@mail.com", Password = "pass" }
            };
        }

        public override List<Permission> GetPermissionListForCompanyList(List<long> ids)
        {
            return new List<Permission>();
        }



    }

    public class TestSoftSqlConnection : ISqlConnection
    {
        public SqlTransaction BeginTransaction()
        {
            return null;
        }

        public void Close() { }

        public void Dispose() { }

        public SqlConnection GetConnection()
        {
            return null;
        }

        public void Open() { }

        public T WithTransaction<T>(Func<T> action)
        {
            return action();
        }

        public void WithTransaction(Action action) 
        { 
            action();
        }
    }

}
