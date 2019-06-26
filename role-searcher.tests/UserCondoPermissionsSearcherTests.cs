using NUnit.Framework;
using role_searcher.Databases;
using role_searcher.Domains;
using role_searcher.Searchers;
using System.Linq;

namespace role_searcher.tests
{
    [TestFixture]
    public class UserCondoPermissionsSearcherTests
    {
        private UserCondoPermissionsSearcher _searcher;

        [SetUp]
        protected void SetUp()
        {
            var filePath = "csv-test.txt";

            var database = new CsvDatabase(filePath);
            _searcher = new UserCondoPermissionsSearcher(database);
        }

        [Test]
        public void UserCondoPermissionsSearcher_Must_Find_MatchingUser()
        {
            var email = "joao.silva@gmail.com";

            var condoPermissions = _searcher.Search(email);

            Assert.IsNotNull(condoPermissions);
            Assert.IsTrue(condoPermissions.Count > 0);
        }
        
        [Test]
        public void UserCondoPermissionsSearcher_Must_Find_One_CondoPermisson_Per_Condo_For_Each_User()
        {
            var email = "felipe.oliveira@gmail.com";

            var condoPermissions = _searcher.Search(email);
            var condoCount = condoPermissions.Count(c => c.Condo == 1);

            Assert.IsTrue(condoCount == 1);
        }

        [Test]
        public void UserCondoPermissionsSearcher_Must_Find_Permissons()
        {
            var email = "felipe.oliveira@gmail.com";

            var condoPermissions = _searcher.Search(email);
            var condoPermission = condoPermissions.FirstOrDefault(c => c.Condo == 1);

            Assert.IsTrue(condoPermission.Permissions.Count > 0);
        }

        [Test]
        public void UserCondoPermissionsSearcher_Must_Not_Repeat_Permissons_Functionality()
        {
            var email = "felipe.oliveira@gmail.com";
            var condo = 1;
            var functionality = "Reservas";

            var condoPermissions = _searcher.Search(email);

            var hasDuplicateFunctionality = condoPermissions
                .FirstOrDefault(c => c.Condo == condo)
                .Permissions
                .Count(p => p.Functionality == functionality) > 1;

            Assert.IsFalse(hasDuplicateFunctionality);
        }

        [Test]
        public void UserCondoPermissionsSearcher_Must_Keep_Greater_Permissions()
        {
            var email = "felipe.oliveira@gmail.com";
            var condo = 1;

            var permission = new Permission
            {
                Functionality = "Usuarios",
                Role = Role.Escrita
            };

            var condoPermissions = _searcher.Search(email);

            var hasPermisson = condoPermissions
                .FirstOrDefault(c => c.Condo == condo)
                .Permissions
                .Exists(p => p.Functionality == permission.Functionality && p.Role == permission.Role);

            Assert.IsTrue(hasPermisson);
        }
    }
}
