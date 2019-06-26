using System.Collections.Generic;

namespace role_searcher.Domains
{
    public class User
    {
        public string Email { get; set; }

        public List<Group> Groups { get; set; }
    }
}
