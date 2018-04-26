using System;
using System.Windows;
using DevExpress.Xpf.Core;
using log4net;

namespace InsightsAnalyser.ViewModels
{
    public static class ErrorReporter
    {
        public static void Report(ILog logger, Exception ex)
        {
            logger.Error(ex);
            DXMessageBox.Show("An error has occurred.\n\n" + ex.Message + "\n\nPlease restart the application and try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}