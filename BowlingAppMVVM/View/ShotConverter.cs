using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using BowlingAppMVVM.ViewModel;
using System.Windows.Controls;

namespace BowlingAppMVVM.View
{
    public sealed class ShotConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                { return false; }

            Utility.SHOT_VALUE shot = (Utility.SHOT_VALUE)value;
            if (shot == Utility.SHOT_VALUE.Strike)
                { return "X"; }
            if (shot == Utility.SHOT_VALUE.Spare)
                { return "/"; }
            if (shot == Utility.SHOT_VALUE.Undefined)
                { return String.Empty; }

            return ((int)shot).ToString();
        }
        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                { return false; }

            string display = ((ComboBoxItem)value).Content.ToString();
            if (display == String.Empty)
            { return Utility.SHOT_VALUE.Undefined; }
            if (display == "X")
            { return Utility.SHOT_VALUE.Strike; }
            if (display == "/")
            { return Utility.SHOT_VALUE.Spare; }

            return Enum.ToObject(typeof(Utility.SHOT_VALUE), Int32.Parse(display));

        }
    }
}
