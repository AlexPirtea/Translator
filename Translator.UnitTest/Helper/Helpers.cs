using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Translator.Model;
using Translator.Service;

namespace Translator.UnitTest
{
    public static class Helpers
    {
        public static string GetRandomWordKey(this WordsProviderService wd)
        {
            Random rand = new Random();
            List<Word> values = wd.Values.ToList();
            int size = wd.Count;
            return values[rand.Next(wd.Count)].Text;
        }

        public static string MixStringCase(this string input)
        {
            char[] chars = input.ToCharArray();
            Random rand = new Random();
            for (int i = 0; i < chars.Length; i++)
            {
                if (rand.Next() % 2 == 0)
                {
                    chars[i] = chars[i].ToString().ToUpper()[0];
                }
                else
                {
                    chars[i] = chars[i].ToString().ToLower()[0];
                }
            }
            return new string(chars);
        }
    }
}
