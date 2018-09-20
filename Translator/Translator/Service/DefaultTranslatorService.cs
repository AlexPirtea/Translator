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
        public DefaultTranslatorService(Dictionary<string, Word> dict)
        {
            _dict = dict;
        }

        public string DictionarySource { get; set; }
        public Dictionary<string, Word> Dict => _dict;

        public void Init()
        {
        }

        public Word Translate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            string wordKey = input.ToLowerInvariant();
            Dict.TryGetValue(wordKey, out var output);
            return output;
        }
    }
}
