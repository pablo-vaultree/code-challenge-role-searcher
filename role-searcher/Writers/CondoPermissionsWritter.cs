using CsvHelper;
using role_searcher.Domains;
using role_searcher.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace role_searcher.Writers
{
    public class CondoPermissionsWritter
    {
        private readonly List<CondoPermission> _condoPermissions;

        public CondoPermissionsWritter(List<CondoPermission> condoPermissions)
        {
            _condoPermissions = condoPermissions;
        }

        public bool Write(string pathToFile)
        {
            var records = GetRecordsToWrite();

            try
            {
                using (var writer = new StreamWriter(pathToFile))
                using (var csvWriter = new CsvWriter(writer))
                {
                    csvWriter.Configuration.HasHeaderRecord = false;
                    csvWriter.WriteRecords(records);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private List<object> GetRecordsToWrite()
        {
            var records = new List<object>(_condoPermissions.Count);

            foreach (var condoPermission in _condoPermissions)
            {
                records.Add(new
                {
                    id = condoPermission.Condo,
                    permissions = condoPermission.Permissions.ConvertToParsedString()
                });
            }

            return records;
        }
    }
}
