using CsvHelper.Configuration;
using role_searcher.Converters;
using role_searcher.Domains;

namespace role_searcher.Mappers
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Map(m => m.Email).Index(1);            
            Map(m => m.Groups).Index(2).TypeConverter<GroupConverter>();
        }
    }
}
