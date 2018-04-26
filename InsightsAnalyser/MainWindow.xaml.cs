using System;
using System.IO;
using InsightsAnalyser.ViewModels;
using Jot;
using Jot.Storage;
using Jot.Triggers;
using log4net;

namespace InsightsAnalyser
{
    public partial class MainWindow
    {
        private readonly StateTracker _tracker = new StateTracker(new JsonFileStoreFactory(), new DesktopPersistTrigger());
        
        private static readonly ILog _log = LogManager.GetLogger(typeof(MainWindow));

        public MainWindow(MainViewModel model)
        {
            InitializeComponent();

            DataContext = model;

            _tracker.Configure(this)
                .IdentifyAs(GetType().ToString())
                .AddProperties<MainWindow>(w => w.Height, w => w.Width, w => w.Left, w => w.Top, w => w.WindowState)
                .RegisterPersistTrigger(nameof(Closed))
                .Apply();
            
            Loaded += MainWindow_Loaded;
            Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                dataGrid.SaveLayoutToXml(GetGridLayoutPath());
                layout.SaveLayoutToXml(GetLayoutPath());
            }
            catch (Exception ex)
            {
                ErrorReporter.Report(_log, ex);
            }
        }

        private void MainWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                var path = GetGridLayoutPath();

                if (File.Exists(path))
                    dataGrid.RestoreLayoutFromXml(path);

                path = GetLayoutPath();

                if (File.Exists(path))
                    layout.RestoreLayoutFromXml(path);
            }
            catch (Exception ex)
            {
                ErrorReporter.Report(_log, ex);
            }
        }

        private static string GetGridLayoutPath() => Path.Combine(GetLayoutDir(), "DataGridLayout.xml");
        private static string GetLayoutPath() => Path.Combine(GetLayoutDir(), "Layout.xml");

        private static string GetLayoutDir()
        {
            var dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Layouts", "InsightsAnalyser");

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            return dir;
        }
    }
}
