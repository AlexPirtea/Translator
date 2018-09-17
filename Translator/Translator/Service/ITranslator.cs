using System;
using System.Collections.Generic;
using System.Text;

namespace Translator.Service
{
    public interface ITranslator
    {
        string Translate(string input);
        string DictionarySource { get; set; }
        void Init();
    }
}
