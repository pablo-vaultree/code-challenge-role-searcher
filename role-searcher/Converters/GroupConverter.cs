using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using role_searcher.Domains;
using System;
using System.Collections.Generic;

namespace role_searcher.Converters
{
    public class GroupConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            var gruposParsed = text
                .Replace('[', ' ')
                .Replace(']', ' ')
                .Split('(', ')');

            var grupos = new List<Group>(gruposParsed.Length);

            for (var index = 0; index < gruposParsed.Length; index++)
            {
                var parsedRow = gruposParsed[index];
                if (string.IsNullOrWhiteSpace(parsedRow) || parsedRow == ",")
                    continue;

                var groupProperties = parsedRow.Split(',');

                grupos.Add(new Group
                {
                    GroupType = Enum.Parse<GroupType>(groupProperties[0]),
                    Condo = int.Parse(groupProperties[1])
                });
            }

            return grupos;
        }

        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            throw new NotImplementedException();
        }
    }
}
