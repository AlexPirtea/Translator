using System.Collections.Generic;
using Translator.Model;

namespace Translator.Service
{
    public interface ITranslatorService
    {
        Word Translate(string input);
    }
}
