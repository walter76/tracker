using System.Collections.ObjectModel;
using System.Windows.Input;
using Tracker.WpfToolkit.Core;

namespace Tracker.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        private string _newChoreText;

        public string NewChoreText
        {
            get { return _newChoreText; }
            set
            {
                _newChoreText = value;
                InvokePropertyChanged();
            }
        }

        public ICommand StartChoreCommand
        {
            get;
            private set;
        }

        public ObservableCollection<string> Chores
        {
            get;
            private set;
        }

        public MainWindowViewModel()
        {
            StartChoreCommand = new RelayCommand(StartChore);

            Chores = new ObservableCollection<string>();
        }

        private void StartChore(object param)
        {
            Chores.Add(NewChoreText);

            NewChoreText = "";
        }
    }
}
