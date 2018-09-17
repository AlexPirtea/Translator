using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translator.ViewModel;
using Xamarin.Forms;

namespace Translator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = ((ViewModelLocator)Application.Current.Resources["Locator"]).Main;
        }
    }
}
