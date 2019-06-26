using CsvHelper.Configuration.Attributes;

namespace role_searcher.Domains
{
    public class Group
    {
        [Index(1)]
        public GroupType GroupType { get; set; }

        [Index(2)]
        public int Condo { get; set; }
    }
}
