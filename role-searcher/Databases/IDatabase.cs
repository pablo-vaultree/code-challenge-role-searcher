using role_searcher.Domains;
using System.Collections.Generic;

namespace role_searcher.Databases
{
    public interface IDatabase
    {               
        List<User> Users { get; set; }

        List<Group> Groups { get; set; }
    }
}
