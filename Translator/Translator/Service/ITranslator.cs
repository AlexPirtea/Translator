using System.Collections.Generic;
using Translator.Model;

namespace Translator.Service
{
    public interface ITranslator
    {
        Word Translate(string input);
        string DictionarySource { get; set; }
        void Init();
    }
}
