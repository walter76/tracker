using System.Windows;

namespace Tracker.WpfToolkit.Core
{
    class ViewModelLocator
    {
        private static ViewModelLocator _instance;

        public static ViewModelLocator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ViewModelLocator();
                }

                return _instance;
            }
        }

        public ViewModelRegistry Registry { get; set; }

        private ViewModelLocator()
        {
        }

        public ViewModelBase FindViewModel(FrameworkElement view)
        {
            return Registry.ResolveViewModel(view.GetType());
        }

        public static readonly DependencyProperty AutoWireViewModelProperty =
            DependencyProperty.RegisterAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), new PropertyMetadata(new PropertyChangedCallback(AutoWireViewModelChanged)));

        public static void SetAutoWireViewModel(DependencyObject obj, bool value)
        {
            // does nothing
            // needs to be there, because otherwise the dependency property won't work
        }

        private static void AutoWireViewModelChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var view = (FrameworkElement)obj;
            if ((bool)e.NewValue)
            {
                view.DataContext = Instance.FindViewModel(view);
            }
        }
    }
}
