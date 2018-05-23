using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Tracker.ViewModel;
using Tracker.WpfToolkit.Core;

namespace Tracker
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ViewModelLocator.Instance.Registry = new ViewModelRegistry(new ViewModelFactory());
            ViewModelLocator.Instance.Registry.Register<MainWindow, MainWindowViewModel>();

            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
