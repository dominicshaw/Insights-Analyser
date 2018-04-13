using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using InsightsAnalyser.Annotations;
using InsightsAnalyser.Models;
using log4net;
using Microsoft.Win32;

namespace InsightsAnalyser.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _fileLocation;
        private bool _working;

        private static readonly ILog _log = LogManager.GetLogger(typeof(MainViewModel));

        public ICommand SelectFileCommand => new AsyncCommand(SelectFile);

        public string FileLocation
        {
            get { return _fileLocation; }
            set
            {
                if (value == _fileLocation) return;
                _fileLocation = value;
                OnPropertyChanged();
            }
        }

        public bool Working
        {
            get { return _working; }
            set
            {
                if (value == _working) return;
                _working = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<QueryDataViewModel> RawData { get; } = new ObservableCollection<QueryDataViewModel>();

        private async Task SelectFile()
        {
            try
            {
                var browser = new OpenFileDialog
                {
                    Title = "Select a CSV",
                    CheckPathExists = true,
                    CheckFileExists = true,
                    Multiselect = false,
                    Filter = "Comma Separated Values|*.csv",
                    DefaultExt = ".csv",
                    AddExtension = true
                };

                var result = browser.ShowDialog();

                if (result.HasValue && result.Value)
                {
                    FileLocation = browser.FileName;

                    Working = true;
                    await ImportFile();
                }
            }
            catch (IOException ioex) when (ioex.Message.StartsWith("The process cannot access the file"))
            {
                _log.Warn(ioex.Message);
                DXMessageBox.Show("Sorry, that file was locked and could not be opened. Please close the file and try again. If the problem persists, contact IT.", "Invalid File Format", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            catch (NotSupportedException nsex)
            {
                _log.Warn(nsex.Message);
                DXMessageBox.Show("Sorry, that file was not recognised as an acceptable Excel file. Please try again and if the problem persists, contact IT.", "Invalid File Format", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
            finally
            {
                Working = false;
            }
        }

        private async Task ImportFile()
        {
            var factory = new QueryDataFactory(FileLocation);

            var data = await Task.Run(new Func<List<QueryData>>(factory.Get));

            RawData.Clear();

            foreach (var d in data)
                RawData.Add(new QueryDataViewModel(d));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}