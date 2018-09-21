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
        WordDictionary _dict;
        public DefaultTranslatorService(WordDictionary dict)
        {
            _dict = dict;
        }

        public Word Translate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            string wordKey = input.ToLowerInvariant();
            _dict.TryGetValue(wordKey, out var output);
            return output;
        }
    }
}
