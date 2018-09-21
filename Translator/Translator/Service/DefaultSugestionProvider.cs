using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translator.Model;

namespace Translator.Service
{
    public class DefaultSugestionProvider : ISuggestionProvider
    {
        WordDictionary _dict;
        public DefaultSugestionProvider(WordDictionary dict)
        {
            _dict = dict;
        }
        public async Task<IEnumerable<string>> GetSugestions(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            return await Task.Run(() => _dict.Values.SelectMany(w => w.Links)
                        .Select(w => w.Text)
                        .Union( _dict.Keys)
                        .Distinct()
                        .Where(w => w.StartsWith(input))
                        .Take(3));
        }

        public List<string> GetFlatDict()
        {
            return _dict.Values.SelectMany(w => w.Links)
                        .Select(w => w.Text)
                        .Union(_dict.Keys)
                        .Distinct()
                        .ToList();
        }
    }
}
