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

        public List<string> GetSimilarWords(string input)
        {
            if(string.IsNullOrWhiteSpace(input))
            {
                return Enumerable.Empty<string>().ToList();
            }
            return _dict.Values.Where(w => w.Links.Any(wl => string.Equals(wl.Text, input)))
                .SelectMany(w => w.Links)
                .Select(w => w.Text)
                .Where(wt => !string.Equals(wt, input))
                .GroupBy(w => w)
                .OrderByDescending(w => w.Count())
                .Select(w => w.Key)
                .ToList();
        }
    }
}
