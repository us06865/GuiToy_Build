using System;
using System.Reflection;
using NUnit.ConsoleRunner;

namespace Tests
{
    class Program
    {

        private static void Main(string[] args)
        {
            string[] myArgs = { Assembly.GetExecutingAssembly().Location };
            var returnCode = Runner.Main(myArgs);
            if (returnCode != 0)
                Console.Beep();
        }

    }
}