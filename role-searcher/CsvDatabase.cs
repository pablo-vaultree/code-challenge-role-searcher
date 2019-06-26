using role_searcher.Domains;
using System.Collections.Generic;
using System.Linq;

namespace role_searcher
{
    public class CsvDatabase
    {       

        public CsvDatabase(string filePath)
        {           
            Users = new List<User>();
            Groups = new List<Group>();

            Init(filePath);
        }

        private void Init(string filePath)
        {
            Users.Add(new User());
            Groups.Add(new Group());
        }

        public List<User> Users { get; set; }

        public List<Group> Groups { get; set; }
    }
}
