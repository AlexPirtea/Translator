using System.Collections.Generic;
using Translator.Model;

namespace Translator.Service
{
    public interface ITranslator
    {
        Word Translate(string input);
    }
}
