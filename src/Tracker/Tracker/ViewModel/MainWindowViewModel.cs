using System.Windows.Input;
using Tracker.WpfToolkit.Core;

namespace Tracker.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        public string NewChoreText
        {
            get;
            set;
        }

        public ICommand StartChoreCommand
        {
            get;
            private set;
        }

        public MainWindowViewModel()
        {
            StartChoreCommand = new RelayCommand(StartChore);
        }

        private void StartChore(object param)
        {
            System.Console.WriteLine(NewChoreText);
        }
    }
}
