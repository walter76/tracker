using System;
using System.Windows.Input;
using Tracker.Model;
using Tracker.WpfToolkit.Core;

namespace Tracker.ViewModel
{
    class ChoreViewModel : ViewModelBase
    {
        private readonly Chore _chore;

        public string Description
        {
            get { return _chore.Description; }
            set
            {
                _chore.Description = value;
                InvokePropertyChanged();
            }
        }

        private string _elapsed;

        public string Elapsed
        {
            get { return _elapsed; }
            set
            {
                _elapsed = value;
                InvokePropertyChanged();
            }
        }

        public ICommand StartStopCommand
        {
            get;
            private set;
        }

        public ChoreViewModel(Chore chore)
        {
            _chore = chore;
            _elapsed = _chore.ElapsedTime;
            _chore.Elapsed += OnElapsed;

            StartStopCommand = new RelayCommand(StartStop);
        }

        private void OnElapsed(object sender, EventArgs e)
        {
            Elapsed = _chore.ElapsedTime;
        }

        private void StartStop(object obj)
        {
            _chore.StartStop();
        }
    }
}
