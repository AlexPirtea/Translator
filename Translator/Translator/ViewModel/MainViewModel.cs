using GalaSoft.MvvmLight;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Translator.Model;
using Translator.Service;
using Xamarin.Forms;

namespace Translator.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ITranslator _translatorService;
        public MainViewModel(ITranslator translatorService)
        {
            _translatorService = translatorService;
            

            _inputWords = new ConcurrentBag<Word>();
            _outputWords = new ConcurrentBag<Word>();

            //_language = CultureInfo.GetCultureInfo("ro-RO").EnglishName;
        }

        private ConcurrentBag<Word> _inputWords;

        public ConcurrentBag<Word> InputWords
        {
            get => _inputWords;
            set
            {
                if (_inputWords == value)
                    return;
                _inputWords = value;
                RaisePropertyChanged(nameof(OutputWords));
            }
        }

        private ConcurrentBag<Word> _outputWords;
        public ConcurrentBag<Word> OutputWords
        {
            get
            {
                var translationResult = _translatorService.Translate(InputWords.Select(w => w.Text));
                Language = translationResult.language;
                return new ConcurrentBag<Word>(translationResult.output);
            }

            set
            {
                if (_inputWords == value)
                    return;
                _inputWords = value;
            }
        }

        private string _language;

        public string Language
        {
            get => _language;
            set
            {
                if (_language == value)
                    return;
                _language = string.IsNullOrWhiteSpace(value) ? @"N\A" : CultureInfo.GetCultureInfo(value).EnglishName;
                RaisePropertyChanged(nameof(Language));
            }
        }
    }
}
