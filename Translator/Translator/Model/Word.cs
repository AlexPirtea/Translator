﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Translator.Model
{
    public class Word
    {
        public string Text { get; set; }
        public string Language { get; set; }

        public List<Word> Links { get; set; }
    }
}
