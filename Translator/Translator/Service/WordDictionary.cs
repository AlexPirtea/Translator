using System;
using System.Collections.Generic;
using System.Text;
using Translator.Model;

namespace Translator.Service
{
    public class WordDictionary : Dictionary<string, Word>
    {
        public WordDictionary()
        {

        }
        public WordDictionary(Dictionary<string, Word> dict) : base (dict)
        {
        }
    }
}
