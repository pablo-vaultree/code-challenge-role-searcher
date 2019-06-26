using NUnit.Framework;
using role_searcher.Domains;
using System.Linq;

namespace role_searcher.tests
{
    [TestFixture]
    public class CsvDatabaseTests
    {
        private CsvDatabase _database;

        [SetUp]
        protected void SetUp()
        {
            var filePath = "csv-test.txt";

            _database = new CsvDatabase(filePath);
        }

        [Test]
        public void CsvDatabase_Must_Seed_Users_and_Groups_from_Text()
        {
            Assert.IsTrue(_database.Users.Count > 0);
            Assert.IsTrue(_database.Groups.Count > 0);
        }

        [Test]
        public void CsvDatabase_Must_Seed_Users_With_Email()
        {          
            var user = _database.Users.First();

            Assert.IsNotEmpty(user.Email);            
        }

        [Test]
        public void CsvDatabase_Must_Seed_Users_With_Groups()
        {
            var user = _database.Users.First();

            Assert.IsTrue(user.Groups.Count > 0);            
        }

        [Test]
        public void CsvDatabase_Must_Seed_Group_With_GroupType_and_CondoId()
        {
            var group = _database.Groups.First();

            Assert.IsInstanceOf(typeof(GroupType), group.GroupType);
            Assert.Greater(group.Condo, 0);
        }

        [Test]
        public void CsvDatabase_Must_Seed_Group_With_Permissions()
        {
            var group = _database.Groups.First();

            Assert.IsTrue(group.Permissions.Count > 0);
        }
    }
}
