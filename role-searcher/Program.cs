using System;
using System.Linq;

namespace role_searcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Search an user permissions- plese inform the email:");
            var email = Console.ReadLine();

            var app = new Application();
            var wroteToFile = app.ProcessUserPermissions(email);

            Console.WriteLine($"Wrote file: {wroteToFile}");

            Console.ReadLine();
        }
    }
}
