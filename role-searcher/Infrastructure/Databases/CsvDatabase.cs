using CsvHelper;
using role_searcher.Domains;
using role_searcher.Mappers;
using System.Collections.Generic;
using System.IO;

namespace role_searcher.Databases
{
    public class CsvDatabase : IDatabase
    {       
        public CsvDatabase(string filePath)
        {           
            Users = new List<User>();
            Groups = new List<Group>();

            Init(filePath);
        }

        private void Init(string filePath)
        {          
            using (var reader = new StreamReader(filePath))
            using (var csvReader = new CsvReader(reader))
            {
                while (csvReader.Read())
                {
                    csvReader.Configuration.HasHeaderRecord = false;
                    csvReader.Configuration.RegisterClassMap<UserMap>();
                    csvReader.Configuration.RegisterClassMap<GroupMap>();

                    var recordType = csvReader.GetField<RecordType>(0);

                    switch (recordType)
                    {
                        case RecordType.Usuario:
                            Users.Add(csvReader.GetRecord<User>());
                            break;
                        case RecordType.Grupo:
                            Groups.Add(csvReader.GetRecord<Group>());
                            break;
                        default:
                            break;
                    }
                }
                
            }           
        }

        public List<User> Users { get; set; }

        public List<Group> Groups { get; set; }
    }
}
