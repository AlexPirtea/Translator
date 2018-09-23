
using Android.App;
using Android.Content.PM;
using Android.OS;
using Translator.Model;
using System.Xml.Serialization;
using System.IO;

namespace Translator.Droid
{
    [Activity(Label = "Translator", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            TRANSLATIONS translations = null;

            XmlSerializer serializer = new XmlSerializer(typeof(TRANSLATIONS));

            using (StreamReader streamReader = new StreamReader(Assets.Open("Intelligent_translator.xml")))
            {
                translations = (TRANSLATIONS)serializer.Deserialize(streamReader);
            }

            Bootstrapper.InitWordsProviderService(translations);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
    }
}