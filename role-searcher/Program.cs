using System;
using System.Linq;

namespace role_searcher
{
    class Program
    {
        static void Main(string[] args)
        {
            var email = args.FirstOrDefault() ?? "felipe.oliveira@gmail.com";

            var app = new Application();
            var wroteToFile = app.ProcessUserPermissions(email);

            Console.WriteLine($"Wrote file: {wroteToFile}");

            Console.ReadLine();
        }
    }
}
