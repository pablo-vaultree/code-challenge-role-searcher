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
        private readonly string _pathToFile;

        public CondoPermissionsWritter(string pathToFile)
        {
            _pathToFile = pathToFile;
        }

        public bool Write(List<CondoPermission> condoPermissions)
        {
            var records = GetRecordsToWrite(condoPermissions);

            try
            {
                using (var writer = new StreamWriter(_pathToFile))
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

        private List<object> GetRecordsToWrite(List<CondoPermission> condoPermissions)
        {
            var records = new List<object>(condoPermissions.Count);

            foreach (var condoPermission in condoPermissions)
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
