using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System.Diagnostics.CodeAnalysis;
using Translator.Service;

namespace Translator.ViewModel
{
    class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ITranslator, DefaultTranslatorService>();
        }

        [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        
    }
}
