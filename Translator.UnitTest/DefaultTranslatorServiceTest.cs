using GalaSoft.MvvmLight.Ioc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Translator.Model;
using Translator.Service;

namespace Translator.UnitTest
{
    [TestClass]
    public class DefaultTranslatorServiceTest
    {
        static ITranslatorService _translator;
        static WordsProviderService _dict;

        [ClassInitialize]
        public static void InitDict(TestContext tc)
        {
            _translator = SimpleIoc.Default.GetInstance<ITranslatorService>();
            _dict = SimpleIoc.Default.GetInstance<WordsProviderService>();
        }

        [TestMethod]
        public void TranslatorReturnsCorrectText()
        {
            // Arrange
            string word = _dict.GetRandomWordKey();

            // Act
            Word translation = _translator.Translate(word);

            // Assert
            Assert.AreEqual(_dict[word].Text, translation.Text);
        }

        [TestMethod]
        public void TranslatorReturnsCorrectLanguage()
        {
            // Arrange
            string word = _dict.GetRandomWordKey();

            // Act
            Word translation = _translator.Translate(word);

            // Assert
            Assert.AreEqual(_dict[word].Language, translation.Language);
        }

        [TestMethod]
        public void TranslatorReturnsCorrectLinks()
        {
            // Arrange
            string word = _dict.GetRandomWordKey();

            // Act
            Word translation = _translator.Translate(word);

            // Assert
            CollectionAssert.AreEqual(_dict[word].Links, translation.Links);
        }

        [TestMethod]
        public void TranslatorReturnsCorrectText_WhenInputInvolvesWhitespaces()
        {
            // Arrange
            string word = "    \n  " + _dict.GetRandomWordKey() + "  \r\t  ";

            // Act
            Word translation = _translator.Translate(word);

            // Assert
            word = word.Trim();
            Assert.AreEqual(_dict[word].Text, translation.Text);
        }

        [TestMethod]
        public void TranslatorReturnsCorrectLanguage_WhenInputInvolvesWhitespaces()
        {
            // Arrange
            string word = "    \n  " + _dict.GetRandomWordKey() + "  \r\t  ";

            // Act
            Word translation = _translator.Translate(word);

            // Assert
            word = word.Trim();
            Assert.AreEqual(_dict[word].Language, translation.Language);
        }

        [TestMethod]
        public void TranslatorReturnsCorrectLinks_WhenInputInvolvesWhitespaces()
        {
            // Arrange
            string word = "    \n  " + _dict.GetRandomWordKey() + "  \r\t  ";

            // Act
            Word translation = _translator.Translate(word);

            // Assert
            word = word.Trim();
            CollectionAssert.AreEqual(_dict[word].Links, translation.Links);
        }

        [TestMethod]
        public void TranslatorReturnsCorrectText_AndIgnoresCase()
        {
            // Arrange
            string word = _dict.GetRandomWordKey();
            string mixedCaseWord = word.MixStringCase();

            // Act
            Word translation = _translator.Translate(mixedCaseWord);

            // Assert
            Assert.AreEqual(_dict[word].Text, translation.Text);
        }

        [TestMethod]
        public void TranslatorReturnsCorrectLanguage_AndIgnoresCase()
        {
            // Arrange
            string word = _dict.GetRandomWordKey();
            string mixedCaseWord = word.MixStringCase();

            // Act
            Word translation = _translator.Translate(mixedCaseWord);

            // Assert
            Assert.AreEqual(_dict[word].Language, translation.Language);
        }

        [TestMethod]
        public void TranslatorReturnsCorrectLinks_AndIgnoresCase()
        {
            // Arrange
            string word = _dict.GetRandomWordKey();
            string mixedCaseWord = word.MixStringCase();

            // Act
            Word translation = _translator.Translate(mixedCaseWord);

            // Assert
            CollectionAssert.AreEqual(_dict[word].Links, translation.Links);
        }

        [TestMethod]
        public void TranslatorReturnsNull_WhenWordKeyIsNotInDictionary()
        {
            // Arrange
            string word = Guid.NewGuid().ToString();

            // Act
            Word translation = _translator.Translate(word);

            // Assert
            Assert.IsNull(translation);
        }

        [TestMethod]
        public void TranslatorReturnsNull_WhenWordWordKeyIsPartOfExistingKey()
        {
            // Arrange
            string word = _dict.GetRandomWordKey();
            string partOfWordKey1 = word.Substring(0, word.Length - 3);
            string partOfWordKey2 = word.Substring(2, word.Length - 2);
            string partOfWordKey3 = word.Substring(2, word.Length - 3);

            // Act
            Word translation1 = _translator.Translate(partOfWordKey1);
            Word translation2 = _translator.Translate(partOfWordKey2);
            Word translation3 = _translator.Translate(partOfWordKey3);

            // Assert
            Assert.IsNull(translation1);
            Assert.IsNull(translation2);
            Assert.IsNull(translation3);
        }
    }
}
