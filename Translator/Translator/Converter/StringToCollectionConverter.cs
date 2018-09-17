using System;
using System.Collections.ObjectModel;
using System.Globalization;
using Translator.Model;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;

namespace Translator.Converter
{
    class StringToCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IEnumerable<Word> enumerableValue = (IEnumerable<Word>)value;
            return string.Join(" ", enumerableValue.Select(w => w.Text));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return Enumerable.Empty<Word>();
            }

            string stringValue = value.ToString();
            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return Enumerable.Empty<Word>();
            }

            ObservableCollection<Word> result = new ObservableCollection<Word>();

            IEnumerable<Word> words = stringValue.Split(new char[] { ' ', ',' })
                                                 .Select((w) => new Word { Text = w });
            foreach (Word word in words)
            {
                result.Add(word);
            }
            return result;
        }
    }
}
