using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Translator.Model
{
    public class Link
    {
        public Word Word { get; set; }
        public CultureInfo Culture { get; set; }
    }
}
