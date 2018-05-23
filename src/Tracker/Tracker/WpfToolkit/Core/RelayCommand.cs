using System;
using System.Windows.Input;

namespace Tracker.WpfToolkit.Core
{
    class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <see cref="ICommand.CanExecuteChanged" />
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <see cref="ICommand.Execute(object)" />
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        /// <see cref="ICommand.CanExecute(object)" />
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }
    }
}
