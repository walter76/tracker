using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace Tracker.WpfToolkit.Core
{
    class ViewModelRegistry
    {
        private readonly IViewModelFactory _viewModelFactory;
        private readonly Dictionary<Type, Type> _viewModelAssociations = new Dictionary<Type, Type>();
        private readonly Dictionary<Type, ViewModelBase> _resolvedViewModels = new Dictionary<Type, ViewModelBase>();

        public ViewModelRegistry(IViewModelFactory viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public void Register<View, ViewModel>()
            where View : FrameworkElement
            where ViewModel : ViewModelBase
        {
            Register(typeof(View), typeof(ViewModel));
        }

        public void RegisterAndAddDataTemplate<View, ViewModel>()
            where View : FrameworkElement
            where ViewModel : ViewModelBase
        {
            RegisterAndAddDataTemplate(typeof(View), typeof(ViewModel));
        }

        public ViewModelBase ResolveViewModel<View>()
            where View : FrameworkElement
        {
            return ResolveViewModel(typeof(View));
        }

        public ViewModelBase ResolveViewModel(Type viewType)
        {
            var viewModelType = _viewModelAssociations[viewType];
            if (!_resolvedViewModels.TryGetValue(viewModelType, out ViewModelBase resolvedViewModel))
            {
                resolvedViewModel = _viewModelFactory.Create(viewModelType);
                _resolvedViewModels.Add(viewModelType, resolvedViewModel);
            }

            return resolvedViewModel;
        }

        private void Register(Type viewType, Type viewModelType)
        {
            _viewModelAssociations[viewType] = viewModelType;
        }

        private void RegisterAndAddDataTemplate(Type viewType, Type viewModelType)
        {
            Register(viewType, viewModelType);

            var template = CreateTemplate(viewType, viewModelType);
            var key = template.DataTemplateKey;
            if (!Application.Current.Resources.Contains(key))
            {
                Application.Current.Resources.Add(key, template);
            }
        }

        private DataTemplate CreateTemplate(Type viewType, Type viewModelType)
        {
            const string xamlTemplate = "<DataTemplate DataType=\"{{x:Type vm:{0}}\"><v:{1} /></DataTemplate>";
            var xaml = String.Format(xamlTemplate, viewModelType.Name, viewType.Name);
            var context = new ParserContext();
            context.XamlTypeMapper = new XamlTypeMapper(new string[0]);
            context.XamlTypeMapper.AddMappingProcessingInstruction("vm", viewModelType.Namespace, viewModelType.Assembly.FullName);
            context.XamlTypeMapper.AddMappingProcessingInstruction("v", viewType.Namespace, viewType.Assembly.FullName);

            context.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            context.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
            context.XmlnsDictionary.Add("vm", "vm");
            context.XmlnsDictionary.Add("v", "v");

            return (DataTemplate)XamlReader.Parse(xaml, context);
        }
    }
}
