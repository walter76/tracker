using System;

namespace Tracker.WpfToolkit.Core
{
    interface IViewModelFactory
    {
        ViewModelBase Create(Type viewModelType);
    }
}
