using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace FormsIcons
{
    public class SoloNumerosBehaivor : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += SoloNumerosChanged;
            base.OnAttachedTo(entry);
        }

        private void SoloNumerosChanged(object sender, TextChangedEventArgs e)
        {
            Entry entry = (Entry)sender;
            if (!string.IsNullOrEmpty(entry.Text)) {
                string validaciones = "^[0-9]*$";
                bool esCorrecto = Regex.IsMatch(entry.Text, validaciones);
                if (esCorrecto)
                    entry.TextColor = Color.Black;
                else
                    entry.TextColor = Color.Red;
            }
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= SoloNumerosChanged;
            base.OnDetachingFrom(entry);
        }
    }
}
