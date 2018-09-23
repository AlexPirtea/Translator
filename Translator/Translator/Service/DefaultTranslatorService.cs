using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using Translator.Model;

namespace Translator.Service
{
    public class DefaultTranslatorService : ITranslatorService
    {
        WordsProviderService _dict;
        public DefaultTranslatorService(WordsProviderService dict)
        {
            _dict = dict;
        }

        public Word Translate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            input = input.Trim();

            string wordKey = input.ToLowerInvariant();
            _dict.TryGetValue(wordKey, out var output);
            return output;
        }
    }
}
