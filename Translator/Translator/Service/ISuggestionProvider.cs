using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Translator.Service
{
    public interface ISuggestionProvider
    {
        Task<IEnumerable<string>> GetSugestions(string input);
        List<string> GetFlatDict();
    }
}
