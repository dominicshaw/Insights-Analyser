using System;
using System.IO;
using System.Windows;
using log4net;

namespace InsightsAnalyser.ViewModels
{
    public class FileFinder : IDisposable
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(FileFinder));

        private readonly FileSystemWatcher _watcher;

        public delegate void FileFoundEventHandler(string path);
        public event FileFoundEventHandler FileFound;

        public FileFinder()
        {
            var watchPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

            _watcher = new FileSystemWatcher(watchPath)
            {
                Filter = "*.csv",
                NotifyFilter = NotifyFilters.FileName,
                EnableRaisingEvents = true
            };

            _watcher.Created += (s, e) => _watcher_Created(e);
            _watcher.Changed += (s, e) => _watcher_Created(e);
            _watcher.Renamed += (s, e) => _watcher_Created(e);

            _watcher.Error += _watcher_Error;
        }

        private static void _watcher_Error(object sender, ErrorEventArgs e)
        {
            _log.Error(e.GetException());
        }

        private void _watcher_Created(FileSystemEventArgs e)
        {
            if (e.Name.ToUpper().StartsWith("QUERY_DATA"))
            {
                _log.Info("File found via file '" + e.ChangeType + "; importing.");
                Application.Current.Dispatcher.BeginInvoke(new Action(() => { FileFound?.Invoke(e.FullPath); }));
            }
        }

        public void Dispose()
        {
            _watcher?.Dispose();
        }
    }
}