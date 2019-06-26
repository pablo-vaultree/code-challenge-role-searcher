using role_searcher.Databases;
using role_searcher.Domains;
using System;
using System.Collections.Generic;
using System.Linq;

namespace role_searcher
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = "code-test-Back-End.txt";
            var database = new CsvDatabase(filePath);

            foreach (var user in database.Users)
            {
                var userPermissions = new List<Permission>();
                Console.WriteLine($"Usuario {user.Email}");

                foreach (var userGroup in user.Groups)
                {
                    var grupo = database.Groups.FirstOrDefault(g =>
                        g.GroupType == userGroup.GroupType && g.Condo == userGroup.Condo);

                    Console.WriteLine($"Grupo {grupo.GroupType.ToString()} - Condominio {grupo.Condo}");

                    userPermissions = grupo.Permissions;

                    foreach (var permission in userPermissions)
                        Console.WriteLine($"Permission {permission.Functionality} - {permission.Role}");
                }

                Console.WriteLine($"--------");
            }
        }
    }
}
