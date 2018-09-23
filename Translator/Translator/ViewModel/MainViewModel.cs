using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Globalization;
using Translator.Model;
using Translator.Service;
using Xamarin.Forms;

namespace Translator.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ITranslatorService _translatorService;
        private ISuggestionService _suggestionProvider;
        public MainViewModel(ITranslatorService translatorService, ISuggestionService suggestionProvider)
        {
            _translatorService = translatorService;
            _suggestionProvider = suggestionProvider;
        }

        private string _inputWord = string.Empty;
        public string InputWord
        {
            get => _inputWord;
            set
            {
                if (_inputWord == value)
                    return;
                _inputWord = value;
                RaisePropertyChanged(nameof(OutputWords));
            }
        }

        public List<string> Sugestions => _suggestionProvider.GetSuggestions();

        public List<Word> OutputWords
        {
            get
            {
                var translationResult = _translatorService.Translate(_inputWord);
                if (translationResult == null)
                {
                    Language = null;
                    InputBackground = Color.Red;
                    return new List<Word> { new Word { Text = "Word not found" } };
                }

                Language = translationResult.Language;
                InputBackground = Color.Green;
                return translationResult.Links;
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


        private Color _inputBackgorund = Color.White;
        public Color InputBackground
        {
            get => _inputBackgorund;
            set
            {
                if (_inputBackgorund == value)
                    return;
                _inputBackgorund = value;
                RaisePropertyChanged(nameof(InputBackground));
            }
        }
    }
}
