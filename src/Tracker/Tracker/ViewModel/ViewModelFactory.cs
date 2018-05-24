using System;
using Tracker.WpfToolkit.Core;

namespace Tracker.ViewModel
{
    class ViewModelFactory : IViewModelFactory
    {
        public ViewModelBase Create(Type viewModelType)
        {
            return Activator.CreateInstance(viewModelType) as ViewModelBase;
        }
    }
}
