using System;
using System.Collections.Generic;
using System.Text;

namespace Translator.Model
{
    public class TranslationResult
    {
        public List<Translation> Output { get; set; }
        public string TranslationLanguage { get; set; }
    }
}
