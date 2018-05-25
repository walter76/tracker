using System.Collections.ObjectModel;
using System.Windows.Input;
using Tracker.Model;
using Tracker.WpfToolkit.Core;

namespace Tracker.ViewModel
{
    class ChoresViewViewModel : ViewModelBase
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

        public ObservableCollection<ChoreViewModel> Chores
        {
            get;
            private set;
        }

        public ChoresViewViewModel()
        {
            StartChoreCommand = new RelayCommand(StartChore);

            Chores = new ObservableCollection<ChoreViewModel>();
        }

        private void StartChore(object param)
        {
            var chore = new Chore { Description = NewChoreText };
            Chores.Add(new ChoreViewModel(chore));

            chore.StartStop();

            NewChoreText = "";
        }
    }
}
