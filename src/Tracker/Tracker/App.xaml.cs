using System.Windows;
using Tracker.View;
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
            ViewModelLocator.Instance.Registry.Register<ChoresView, ChoresViewModel>();

            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
