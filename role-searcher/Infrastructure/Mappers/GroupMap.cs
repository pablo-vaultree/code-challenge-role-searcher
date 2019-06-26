using CsvHelper.Configuration;
using role_searcher.Converters;
using role_searcher.Domains;

namespace role_searcher.Mappers
{
    public class GroupMap : ClassMap<Group>
    {
        public GroupMap()
        {
            Map(m => m.GroupType).Index(1);
            Map(m => m.Condo).Index(2);
            Map(m => m.Permissions).Index(3).TypeConverter<PermissionConverter>();
        }
    }
}
