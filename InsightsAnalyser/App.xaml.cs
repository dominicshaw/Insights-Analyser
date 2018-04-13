using System;
using System.Deployment.Application;
using System.Reflection;
using System.Windows;
using InsightsAnalyser.ViewModels;
using log4net;

namespace InsightsAnalyser
{
    public partial class App
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(App));

        protected override void OnStartup(StartupEventArgs e)
        {
            InitialiseLogs();

            base.OnStartup(e);

            MainWindow = new MainWindow(new MainViewModel());
            MainWindow.Show();
            MainWindow.Focus();

            _log.Info("Successful start of insights analyser.");
        }

        private static void InitialiseLogs()
        {
            GlobalContext.Properties["username"] = Environment.UserName;
            GlobalContext.Properties["version"] = ApplicationDeployment.IsNetworkDeployed ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() : Assembly.GetExecutingAssembly().GetName().Version + "d";

            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
