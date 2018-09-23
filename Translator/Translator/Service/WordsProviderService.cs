using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Translator.Model;

namespace Translator.Service
{
    public class WordsProviderService : Dictionary<string, Word>
    {
        public WordsProviderService()
        {
        }
        public WordsProviderService(Dictionary<string, Word> dict) : base (dict)
        {
        }


    }
}
