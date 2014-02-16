ServiceRunner
=============

Easiest way to turn a console app into a Windows Service but still debug as a console app.

Get the [NuGet package here][].

### Using the library is easy. 

If you want a service installer, you must declare one like this:

```
    public class MyInstaller : ServiceRunnerInstaller
    {
        protected override string ServiceName { get { return "MyServiceRunnerDemo"; } }
        protected override string ServiceDescription { get { return "My Service Runner Demo description"; } }
        protected override string ServiceDisplayName { get { return "My Service Runner Demo"; } }
        protected override ServiceRunnerStartMode StartMode { get { return ServiceRunnerStartMode.Manual; } }
        protected override ServiceRunnerAccount Account { get { return ServiceRunnerAccount.LocalSystem; } }
    }
```

And then you just write your start and stop actions like this in your cosole app:

```
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
```
	
	
  [NuGet package here]: http://www.nuget.org/packages/ServiceRunner/
