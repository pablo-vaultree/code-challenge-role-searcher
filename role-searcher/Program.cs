using role_searcher.Databases;
using role_searcher.Domains;
using role_searcher.Searchers;
using role_searcher.Writers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace role_searcher
{
    class Program
    {
        static void Main(string[] args)
        {
            var email = args.FirstOrDefault() ?? "felipe.oliveira@gmail.com";

            var filePathRead = "code-test-Back-End.txt";
            var filePathWrite = "code-test-Back-End-result.txt";

            var database = new CsvDatabase(filePathRead);
            var searcher = new UserCondoPermissionsSearcher(database);
            
            var condoPermissions = searcher.Search(email);

            foreach (var condoPermission in condoPermissions)
            {
                Console.WriteLine($"Condo: {condoPermission.Condo}");

                foreach (var permission in condoPermission.Permissions)
                    Console.WriteLine($"Functionality: {permission.Functionality} - Role: {permission.Role.ToString()}");
            }

            var wroteFile = new CondoPermissionsWritter(condoPermissions).Write(filePathWrite);
            Console.WriteLine($"Wrote file {filePathWrite}: {wroteFile}");

            Console.ReadLine();
        }
    }
}
