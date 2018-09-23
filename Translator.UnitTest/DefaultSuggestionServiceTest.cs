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
        public void SuggestionServiceReturnsCorrectSuggestions()
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
        [TestMethod]
        public void SuggestionServiceReturnsCorrectSimilarWords()
        {
            // Arrange
            string input = _dict.GetRandomWordKey();
            var expectedValues = _dict.Values.Where(w => w.Links.Any(wl => string.Equals(wl.Text, input)))
                .SelectMany(w => w.Links)
                .Select(w => w.Text)
                .Where(wt => !string.Equals(wt, input))
                .GroupBy(w => w)
                .OrderByDescending(w => w.Count())
                .Select(w => w.Key)
                .ToList();
            // Act
            var actualValues = _suggestionService.GetSimilarWords(input);

            // Assert
            CollectionAssert.AreEqual(expectedValues, actualValues);
        }

        [TestMethod]
        public void SuggestionServiceGetSimilarWords_DoesntReturnInputWord()
        {
            // Arrange
            string input = _dict.GetRandomWordKey();

            // Act
            var actualValues = _suggestionService.GetSimilarWords(input);

            // Assert
            Assert.IsFalse(actualValues.Any(w => string.Equals(w, input)));
        }

        [TestMethod]
        public void SuggestionServiceGetSimilarWords_ReturnsEmptyList_WhenInputIsEmpty()
        {
            // Arrange
            string input = string.Empty;

            // Act
            var actualValues = _suggestionService.GetSimilarWords(input);

            // Assert
            CollectionAssert.AreEqual(Enumerable.Empty<string>().ToList(), actualValues);
            Assert.IsFalse(actualValues.Any());
        }
    }
}
