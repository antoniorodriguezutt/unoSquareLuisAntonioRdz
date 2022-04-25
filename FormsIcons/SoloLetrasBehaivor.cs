using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace FormsIcons
{
    public class SoloLetrasBehaivor : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += SoloLetrasChanged;
            base.OnAttachedTo(entry);
        }

        private void SoloLetrasChanged(object sender, TextChangedEventArgs e)
        {
            Entry entry = (Entry)sender;
            if (!string.IsNullOrEmpty(entry.Text))
            {
                string validaciones = "^[a-zA-Z]+$";
                bool esCorrecto = Regex.IsMatch(entry.Text, validaciones);
                if (esCorrecto)
                    entry.TextColor = Color.Black;
                else
                    entry.TextColor = Color.Red;
            }
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= SoloLetrasChanged;
            base.OnDetachingFrom(entry);
        }
    }
}
