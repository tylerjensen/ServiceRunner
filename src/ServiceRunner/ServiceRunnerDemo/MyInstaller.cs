using ServiceRunner;

namespace ServiceRunnerDemo
{
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
}