using role_searcher.Databases;
using role_searcher.Domains;

namespace role_searcher.Searchers
{
    public class UserSearcher
    {
        private readonly IDatabase _database;

        public UserSearcher(IDatabase database)
        {
            _database = database;
        }

        public User Search(string email)
        {
            return null;
        }
    }
}
