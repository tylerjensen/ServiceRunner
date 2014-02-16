using System.ServiceProcess;

namespace ServiceRunner
{
    internal class ServiceRunnerService : ServiceBase
    {
        private readonly string name;
        private readonly Runner runner;

        public ServiceRunnerService(string serviceName, Runner runner)
        {
            this.name = serviceName;
            this.runner = runner;
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            runner.Start(args);
        }

        protected override void OnStop()
        {
            runner.Stop();
        }


        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.ServiceName = this.name;
        }

        #endregion

    }
}
