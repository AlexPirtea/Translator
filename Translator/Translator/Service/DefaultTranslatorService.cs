using System;
using System.Collections.Generic;
using System.Text;

namespace Translator.Service
{
    class DefaultTranslatorService : ITranslator
    {
        public string DictionarySource { get; set; }
        

        public void Init()
        {
            if (string.IsNullOrWhiteSpace(DictionarySource))
            {
                throw new Exception($"{nameof(DictionarySource)} not set");
            }



        }

        public string Translate(string input)
        {
            return string.Empty;
        }


    }
}
