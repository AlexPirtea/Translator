using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Text;
using Translator.Model;
using Translator.Service;

namespace Translator
{
    public static class Bootstrapper
    {
        public static void InitWordsProviderService(TRANSLATIONS translations)
        {
            Dictionary<string, Word> dict = new Dictionary<string, Word>();

            var records = translations.RECORD;

            foreach (var r in records)
            {
                var item = new Word { Language = r.culture, Text = r.word };
                item.Links = new List<Word>();
                foreach (var l in r.LINK)
                {
                    item.Links.Add(new Word { Text = l.word, Language = l.culture });
                }
                dict.Add(item.Text.ToLowerInvariant(), item);

            }
            SimpleIoc.Default.Register<WordsProviderService>(() => new WordsProviderService(dict));
        }
    }
}
