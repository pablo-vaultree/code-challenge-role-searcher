using NUnit.Framework;

namespace role_searcher.tests
{
    [TestFixture]
    public class CsvDatabaseTests
    {

        [SetUp]
        protected void SetUp()
        {          
        }

        [Test]
        public void CsvDatabase_Must_Seed_Users_and_Groups_from_Text()
        {
            var filePath = "csv-test.txt";
            
            var databaseSeeder = new CsvDatabase(filePath);

            Assert.IsTrue(databaseSeeder.Users.Count > 0);
            Assert.IsTrue(databaseSeeder.Groups.Count > 0);
        }
    }
}
