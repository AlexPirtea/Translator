using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Translator.Service
{
    public interface ISuggestionService
    {
        List<string> GetSuggestions();
        List<string> GetSimilarWords(string input);
    }
}
