using System;
using System.Collections.Generic;
using System.Text;
using Translator.Model;
using Translator.Service;

namespace Translator.UnitTest.Mock
{
    public class WordsProviderMock : WordsProviderService
    {
        public WordsProviderMock()
        {
            Seed();
        }

        private void Seed()
        {
            this.Add("word1", new Word { Text = "word1", Language = "l1", Links = new List<Word> { new Word { Text = "word3", Language = "l2" } } });
            this.Add("word2", new Word { Text = "word2", Language = "l3", Links = new List<Word> { new Word { Text = "word4", Language = "l1" } } });
            this.Add("word3", new Word { Text = "word3", Language = "l1", Links = new List<Word> { new Word { Text = "word1", Language = "l3" } } });
            this.Add("word4", new Word { Text = "word4", Language = "l2", Links = new List<Word> { new Word { Text = "word1", Language = "l1" } } });
        }
    }
}
