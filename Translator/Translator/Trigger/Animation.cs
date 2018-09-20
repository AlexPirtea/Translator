using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Translator.Trigger
{
    public class ShakeEntry : TriggerAction<Entry>
    {
        async protected override void Invoke(Entry entry)
        {
            uint timeout = 50;

            await entry.TranslateTo(-15, 0, timeout);
            await entry.TranslateTo(15, 0, timeout);
            await entry.TranslateTo(-10, 0, timeout);
            await entry.TranslateTo(10, 0, timeout);
            await entry.TranslateTo(-5, 0, timeout);
            await entry.TranslateTo(5, 0, timeout);
            entry.TranslationX = 0;
        }
    }
}
