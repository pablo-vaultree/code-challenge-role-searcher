using NUnit.Framework;
using role_searcher.Databases;
using role_searcher.Domains;
using System.Linq;

namespace role_searcher.tests
{
    [TestFixture]
    public class CondoPermissionTests
    {
        private CsvDatabase _database;

        [SetUp]
        protected void SetUp()
        {
            var filePath = "csv-test.txt";

            _database = new CsvDatabase(filePath);
        }

        [Test]
        public void CondoPermission_Must_Add_New_Permission()
        {
            var condoPermission = new CondoPermission
            {
                Condo = 1
            };

            var permission = new Permission
            {
                Functionality = "Entregas",
                Role = Role.Escrita
            };

            condoPermission.AddPermisson(permission);

            Assert.IsTrue(condoPermission.Permissions.Count > 0);
            Assert.IsTrue(condoPermission.Permissions.Contains(permission));
        }

        [Test]
        public void CondoPermission_Must_Not_Add_RepeatedFunctionality_With_LowerRole()
        {
            var condoPermission = new CondoPermission
            {
                Condo = 1
            };

            var firstPermission = new Permission
            {
                Functionality = "Entregas",
                Role = Role.Escrita
            };

            var secondPermission = new Permission
            {
                Functionality = "Entregas",
                Role = Role.Leitura
            };

            condoPermission.AddPermisson(firstPermission);
            condoPermission.AddPermisson(secondPermission);

            Assert.IsTrue(condoPermission.Permissions.Count == 1);
            Assert.IsFalse(condoPermission.Permissions.Contains(secondPermission));
        }

        [Test]
        public void CondoPermission_Must_Not_Add_RepeatedPermission()
        {
            var condoPermission = new CondoPermission
            {
                Condo = 1
            };

            var firstPermission = new Permission
            {
                Functionality = "Entregas",
                Role = Role.Escrita
            };           

            condoPermission.AddPermisson(firstPermission);
            condoPermission.AddPermisson(firstPermission);

            Assert.IsTrue(condoPermission.Permissions.Count == 1);
        }
    }
}
