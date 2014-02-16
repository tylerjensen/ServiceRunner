using ServiceRunner;

namespace ServiceRunnerDemo
{
    public class MyInstaller : ServiceRunnerInstaller
    {
        protected override string ServiceName { get { return "MyServiceRunnerDemo"; } }
        protected override string ServiceDescription { get { return "My Service Runner Demo description"; } }
        protected override string ServiceDisplayName { get { return "My Service Runner Demo"; } }
        protected override ServiceRunnerStartMode StartMode { get { return ServiceRunnerStartMode.Manual; } }
        protected override ServiceRunnerAccount Account { get { return ServiceRunnerAccount.LocalSystem; } }
    }
}