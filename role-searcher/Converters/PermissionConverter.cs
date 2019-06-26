using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using role_searcher.Domains;
using System;
using System.Collections.Generic;

namespace role_searcher.Converters
{
    public class PermissionConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            var rolesParsed = text
                .Replace('[', ' ')
                .Replace(']', ' ')
                .Split('(', ')');

            var permissions = new List<Permission>(rolesParsed.Length);

            for (var index = 0; index < rolesParsed.Length; index++)
            {
                var parsedRow = rolesParsed[index];

                if (string.IsNullOrWhiteSpace(parsedRow) || parsedRow == ",")
                    continue;

                var roleProperties = parsedRow.Split(',');

                var functionality = roleProperties[0];
                var role = Enum.Parse<Role>(roleProperties[1]);

                permissions.Add(new Permission
                {
                    Functionality = functionality,
                    Role = role
                });
            }

            return permissions;
        }

        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            throw new NotImplementedException();
        }
    }
}
