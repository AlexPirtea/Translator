using System.Collections.Generic;
using Translator.Model;

namespace Translator.Service
{
    public interface ITranslator
    {
        (IEnumerable<Word> output, string language) Translate(IEnumerable<string> input);
        string DictionarySource { get; set; }
        void Init();
    }
}
