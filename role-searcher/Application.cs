using Microsoft.Extensions.Configuration;
using role_searcher.Databases;
using role_searcher.Searchers;
using role_searcher.Writers;

namespace role_searcher
{
    public class Application
    {
        private static readonly string FileToReadPath = "fileToReadPath";
        private static readonly string FileToWritePath = "fileToWritePath";

        private readonly CsvDatabase _database;
        private readonly UserCondoPermissionsSearcher _searcher;
        private readonly CondoPermissionsWritter _writter;

        public Application(IConfiguration configuration)
        {
            var fileToReadPath = configuration[FileToReadPath];
            var fileToWritePath = configuration[FileToWritePath];

            _database = new CsvDatabase(fileToReadPath);
            _searcher = new UserCondoPermissionsSearcher(_database);
            _writter = new CondoPermissionsWritter(fileToWritePath);
        }    

        public bool ProcessUserPermissions(string email)
        {
            var condoPermissions = _searcher.Search(email);
            if (condoPermissions == null)
                return false;

            return _writter.Write(condoPermissions);
        }
    }
}
