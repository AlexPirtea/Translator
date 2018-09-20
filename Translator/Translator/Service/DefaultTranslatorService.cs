using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using Translator.Model;

namespace Translator.Service
{
    public class DefaultTranslatorService : ITranslator
    {
        Dictionary<string, Word> _dict;
        public DefaultTranslatorService(Dictionary<string, Word> dict )
        {
            _dict = dict;
        }

        public string DictionarySource { get; set; }
        public Dictionary<string, Word> Dict => _dict;

        public void Init()
        {
        }

        public (IEnumerable<Word> output, string language) Translate(IEnumerable<string> input)
        {
            if(!input.Any())
            {
                return (new List<Word>(), string.Empty);
            }

            Dictionary<string, uint> languageMetric = new Dictionary<string, uint>();

            List<Word> rawWords = new List<Word>();
            foreach (string word in input)
            {
                if (Dict.ContainsKey(word.ToLowerInvariant()))
                {
                    Word aux = Dict[word];
                    rawWords.Add(aux);
                }
                else
                {
                    rawWords.Add(new Word { Text = word });
                }
            }

            var language = rawWords.Where( w => !string.IsNullOrWhiteSpace(w.Language))
                                 .GroupBy(w => w)
                                 .OrderByDescending(w => w.Count())
                                 .FirstOrDefault()
                                 .Key?
                                 .Language;

            // If language is not detected return words in raw form
            if (string.IsNullOrWhiteSpace(language))
            {
                return (rawWords, language);
            }

            // Update words with translation
            for (int wordIndex = 0; wordIndex < rawWords.Count; wordIndex++)
            {
                Word word = rawWords[wordIndex];
                if (!string.IsNullOrWhiteSpace(word.Language))
                {
                    string wordKey = word.Text.ToLowerInvariant();
                    rawWords[wordIndex] = Dict[wordKey].Links.First(); // w => string.Equals(w.Language, language) what language
                }
            }

            return (rawWords, language);
        }
    }
}
