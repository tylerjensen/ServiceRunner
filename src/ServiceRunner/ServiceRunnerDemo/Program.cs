using System;
using System.IO;
using ServiceRunner;

namespace ServiceRunnerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var logFile = "c:\\temp\\logit.txt";
            var runner = new Runner("MyServiceRunnerDemo", runAsConsole: false);
            runner.Run(args, 
                arguments =>
                {
                    File.WriteAllLines(logFile, new string[]
                    {
                        string.Format("args count: {0}", arguments.Length)
                    });
                    Console.WriteLine("args count: {0}", arguments.Length);
                    File.WriteAllLines(logFile, new string[]
                    {
                        "start called"
                    });
                    Console.WriteLine("start called");
                }, 
                () =>
                {
                    File.WriteAllLines(logFile, new string[]
                    {
                        "stop called"
                    });
                    Console.WriteLine("stop called");
                });
            Console.ReadLine();
        }
    }
}
