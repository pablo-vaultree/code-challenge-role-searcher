using role_searcher.Databases;
using role_searcher.Searchers;
using role_searcher.Writers;

namespace role_searcher
{
    public class Application
    {
        private static readonly string FilePathRead = "code-test-Back-End.txt";
        private static readonly string FilePathWrite = "code-test-Back-End-result.txt";

        private readonly CsvDatabase _database;
        private readonly UserCondoPermissionsSearcher _searcher;
        private readonly CondoPermissionsWritter _writter;

        public Application()
        {
            _database = new CsvDatabase(FilePathRead);
            _searcher = new UserCondoPermissionsSearcher(_database);
            _writter = new CondoPermissionsWritter(FilePathWrite);
        }

        public bool ProcessUserPermissions(string email)
        {
            var condoPermissions = _searcher.Search(email);
            return _writter.Write(condoPermissions);   
        }
    }
}
