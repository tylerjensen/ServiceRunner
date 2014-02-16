using System;
using System.ServiceProcess;

namespace ServiceRunner
{
    public class Runner
    {
        private readonly string serviceName;
        private readonly bool runAsConsole;
        private Action<string[]> start = null;
        private Action stop = null;

        public Runner(string serviceName, bool runAsConsole)
        {
            this.serviceName = serviceName;
            this.runAsConsole = runAsConsole;
        }

        internal Action<string[]> Start { get { return start; } }
        internal Action Stop { get { return stop; } }

        public void Run(string[] args, Action<string[]> start, Action stop)
        {
            if (null == start) throw new ArgumentNullException("start");
            if (null == stop) throw new ArgumentNullException("stop");
            this.start = start;
            this.stop = stop;

            if (runAsConsole)
            {
                this.Start(args);
                Console.WriteLine("{0} console started... Hit enter to stop...", this.serviceName);
                Console.ReadLine();
                this.Stop();
                Console.WriteLine("{0} console stopped.", this.serviceName);
            }
            else
            {
                //Run it as a service
                var svc = new ServiceRunnerService(this.serviceName, this);
                var servicesToRun = new ServiceBase[] { svc };
                ServiceBase.Run(servicesToRun);
            }
        }
    }
}
