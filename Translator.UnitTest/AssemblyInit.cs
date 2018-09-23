using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Translator.Service;
using Translator.UnitTest.Mock;

namespace Translator.UnitTest
{
    [TestClass]
    class AssemblyInit
    {
        [AssemblyInitialize]
        public static void Init(TestContext tc)
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<WordsProviderService>(() => new WordsProviderMock());
            SimpleIoc.Default.Register<ITranslatorService, DefaultTranslatorService>();
            SimpleIoc.Default.Register<ISuggestionService, DefaultSuggestionService>();
        }

        [AssemblyCleanup]
        public static void Deinit()
        {
            SimpleIoc.Default.Reset();
        }
    }
}
