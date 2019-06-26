using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace role_searcher
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", true, true)
              .Build();

            var app = new Application(config);

            Console.WriteLine($"Search an user permissions- plese inform the email:");
            
            while (true)
            {
                var email = Console.ReadLine();
                var wroteToFile = app.ProcessUserPermissions(email);

                if (wroteToFile)
                {
                    Console.WriteLine($"Wrote file: {wroteToFile}");
                    break;
                }
                
                Console.WriteLine($"Coudn't find user, please  inform a new one:");
            }
        }
    }
}
