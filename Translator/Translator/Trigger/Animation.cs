using Syncfusion.SfAutoComplete.XForms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Translator.Trigger
{
    public class ShakeEntry : TriggerAction<SfAutoComplete>
    {
        async protected override void Invoke(SfAutoComplete entry)
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
