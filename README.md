ServiceRunner
=============

Easiest way to turn a console app into a Windows Service but still debug as a console app.

Get the [NuGet package here][].

### Using the library is easy. 

Just write your start and stop actions like this in your console app:

```C#
    class Program
    {
        static void Main(string[] args)
        {
            var logFile = "c:\\temp\\logit.txt";
            var runner = new Runner("MyServiceRunnerDemo", runAsConsole: false);
            runner.Run(args, 
                arguments =>
                {
                    //write your start code here
                    // . . . 
                }, 
                () =>
                {
                    //write your stop code here
                    // . . . 
                });
        }
    }
```

The ServiceRunnerInstaller class must be inherited in your own project in order for the installutil installer to properly install your application as a Windows service. You can leave the implementation empty if you want the default values (shown). If you want different values, declare a class like the code below and change the values.

```C#
    /// <summary>
    /// This class (name unimportant) must exist in your console app
    /// for the installer to be recognized when you run installutil.exe
    /// from the Windows\Microsoft.NET\Framework64\v4.0.30319 directory.
    /// </summary>
    public class MyInstaller : ServiceRunnerInstaller
    {
        protected override string ServiceName
        {
            get { return "ServiceRunner"; }
        }

        protected override string ServiceDescription
        {
            get { return "Service Runner description"; }
        }

        protected override string ServiceDisplayName
        {
            get { return "Service Runner"; }
        }

        protected override ServiceRunnerStartMode StartMode
        {
            get { return ServiceRunnerStartMode.Manual; }
        }

        protected override ServiceRunnerAccount Account
        {
            get { return ServiceRunnerAccount.LocalSystem; }
        }
    }
```

	
  [NuGet package here]: http://www.nuget.org/packages/ServiceRunner/
