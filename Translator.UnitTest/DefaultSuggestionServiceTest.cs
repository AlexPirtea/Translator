using GalaSoft.MvvmLight.Ioc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Translator.Service;

namespace Translator.UnitTest
{
    [TestClass]
    public class DefaultSuggestionServiceTest
    {
        static ISuggestionService _suggestionService;
        static WordsProviderService _dict;

        [ClassInitialize]
        public static void InitDict(TestContext tc)
        {
            _suggestionService = SimpleIoc.Default.GetInstance<ISuggestionService>();
            _dict = SimpleIoc.Default.GetInstance<WordsProviderService>();
        }

        [TestMethod]
        public void SuggestionServiceReturnsCorrectValues()
        {
            // Arrange
            var expectedValues = _dict.Values.SelectMany(w => w.Links)
                        .Select(w => w.Text)
                        .Union(_dict.Keys)
                        .Distinct()
                        .ToList();
            // Act
            var actualValues = _suggestionService.GetSuggestions();

            // Assert
            CollectionAssert.AreEqual(expectedValues, actualValues);
        }
    }
}
