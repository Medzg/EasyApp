using Autofac;
using EasyApp.Startup;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EasyApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var bootstrapper = new BootStrapper();
            var container = bootstrapper.Bootstrap();
            var minWindow = container.Resolve<MainWindow>();
            minWindow.Show();
        }
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Unexpected Error.Please Check errors exception." + Environment.NewLine + e.Exception.Message, " Unexpected error");

            e.Handled = true;
        }
    }
}
