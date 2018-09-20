using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Translator.Model;
using System.Xml.Serialization;
using System.IO;
using GalaSoft.MvvmLight.Ioc;
using Translator.Service;
using System.Collections.Generic;
using System.Linq;

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

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            SimpleIoc.Default.Register<ITranslator>(() => new DefaultTranslatorService(dict));
            LoadApplication(new App());
        }
    }
}