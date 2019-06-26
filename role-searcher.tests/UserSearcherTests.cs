using NUnit.Framework;
using role_searcher.Databases;
using role_searcher.Domains;
using role_searcher.Searchers;
using System.Linq;

namespace role_searcher.tests
{
    [TestFixture]
    public class UserSearcherTests
    {
        private PermissionSearcher _searcher;

        [SetUp]
        protected void SetUp()
        {
            var filePath = "csv-test.txt";

            var database = new CsvDatabase(filePath);
            _searcher = new PermissionSearcher(database);
        }

        [Test]
        public void UserSearcher_Must_Find_MatchingUser()
        {
            var email = "joao.silva@gmail.com";

            var user = _searcher.Search(email);

            Assert.AreEqual(email, user.Email);            
        }
    }
}
