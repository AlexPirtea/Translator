using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translator.Model;

namespace Translator.Service
{
    public class DefaultSuggestionService : ISuggestionService
    {
        WordsProviderService _dict;
        public DefaultSuggestionService(WordsProviderService dict)
        {
            _dict = dict;
        }

        public List<string> GetSuggestions()
        {
            return _dict.Values.SelectMany(w => w.Links)
                        .Select(w => w.Text)
                        .Union(_dict.Keys)
                        .Distinct()
                        .ToList();
        }
    }
}
