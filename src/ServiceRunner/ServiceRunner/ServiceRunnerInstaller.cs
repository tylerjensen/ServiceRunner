using System;
using System.ComponentModel;
using System.ServiceProcess;

namespace ServiceRunner
{
    [RunInstaller(true)]
    public class ServiceRunnerInstaller : System.Configuration.Install.Installer
    {
        protected ServiceRunnerInstaller()
        {
            InitializeComponent();
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

            //
            // create installer and process installer
            //
            this.serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();
            this.serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();

            // 
            // serviceInstaller1
            // 
            this.serviceInstaller1.Description = this.ServiceDescription;
            this.serviceInstaller1.DisplayName = this.ServiceDisplayName;
            this.serviceInstaller1.ServiceName = this.ServiceName;
            this.serviceInstaller1.StartType = (ServiceStartMode)Enum.Parse(typeof(ServiceStartMode), 
                this.StartMode.ToString());
            // 
            // serviceProcessInstaller1
            // 
            this.serviceProcessInstaller1.Account = (ServiceAccount)Enum.Parse(typeof(ServiceAccount), 
                this.Account.ToString());
            if (ServiceRunnerAccount.User == this.Account)
            {
                this.serviceProcessInstaller1.Password = null;
                this.serviceProcessInstaller1.Username = null;
            }
            // 
            // ServiceHostInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[]
            {
                this.serviceInstaller1, 
                this.serviceProcessInstaller1
            });

        }

        protected virtual string ServiceName { get { return "ServiceRunner"; } }
        protected virtual string ServiceDescription { get { return "Service Runner description"; } }
        protected virtual string ServiceDisplayName { get { return "Service Runner"; } }
        protected virtual ServiceRunnerStartMode StartMode { get { return ServiceRunnerStartMode.Manual; } }
        protected virtual ServiceRunnerAccount Account { get { return ServiceRunnerAccount.LocalSystem; } }


        private System.ServiceProcess.ServiceInstaller serviceInstaller1;
        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller1;

        #endregion
    }
}
