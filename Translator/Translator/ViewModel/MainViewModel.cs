using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using Translator.Model;
using Translator.Service;

namespace Translator.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ITranslator _translatorService;
        public MainViewModel(ITranslator translatorService)
        {
            _translatorService = translatorService;
            _translatorService.DictionarySource = "Intelligent_translator.xml";
            _translatorService.Init();

            _words = new ObservableCollection<Word>();
        }

        private string _input;
        private string _output;

        private ObservableCollection<Word> _words;

        public ObservableCollection<Word> Words
        {
            get => _words;
            set
            {
                if (_words == value)
                    return;
                _words = value;
                RaisePropertyChanged(nameof(Words));
            }
        }


        public string Input
        {
            get => _input;
            set
            {
                if (_input == value)
                    return;
                _input = value;
                RaisePropertyChanged(nameof(Input));
            }
        }

        public string Output
        {
            get => _output;
            set
            {
                if (_output == value)
                    return;
                _output = value;
                RaisePropertyChanged(nameof(Output));
            }
        }

    }
}
