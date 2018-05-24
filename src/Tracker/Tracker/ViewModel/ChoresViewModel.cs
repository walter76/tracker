using System.Collections.ObjectModel;
using System.Windows.Input;
using Tracker.Model;
using Tracker.WpfToolkit.Core;

namespace Tracker.ViewModel
{
    class ChoresViewModel : ViewModelBase
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

        public ObservableCollection<Chore> Chores
        {
            get;
            private set;
        }

        public ChoresViewModel()
        {
            StartChoreCommand = new RelayCommand(StartChore);

            Chores = new ObservableCollection<Chore>();
        }

        private void StartChore(object param)
        {
            var chore = new Chore { Description = NewChoreText };
            Chores.Add(chore);

            chore.Start();

            NewChoreText = "";
        }
    }
}
