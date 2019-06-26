using CsvHelper.Configuration.Attributes;
using System.Collections.Generic;

namespace role_searcher.Domains
{
    public class User
    {
        [Index(1)]
        public string Email { get; set; }

        [Index(2)]
        public List<Group> Groups { get; set; }
    }
}
