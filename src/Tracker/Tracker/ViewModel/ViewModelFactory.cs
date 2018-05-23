using System;
using Tracker.WpfToolkit.Core;

namespace Tracker.ViewModel
{
    class ViewModelFactory : IViewModelFactory
    {
        public ViewModelBase Create(Type viewModelType)
        {
            if (viewModelType == typeof(MainWindowViewModel))
            {
                return new MainWindowViewModel();
            }

            return null;
        }
    }
}
