using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using BowlingAppMVVM.ViewModel;

namespace BowlingAppMVVM.View
{
    public sealed class ShotConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                { return false; }

            FrameViewModelBase.SHOT_VALUE shot = (FrameViewModelBase.SHOT_VALUE)value;
            if (shot == FrameViewModelBase.SHOT_VALUE.Strike)
                { return "X"; }
            if (shot == FrameViewModelBase.SHOT_VALUE.Spare)
                { return "/"; }
            if (shot == FrameViewModelBase.SHOT_VALUE.Undefined)
                { return String.Empty; }

            return ((int)shot).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                { return false; }

            string display = value.ToString();
            if (display == String.Empty)
                { return FrameViewModelBase.SHOT_VALUE.Undefined; }
            if (display == "X")
                { return FrameViewModelBase.SHOT_VALUE.Strike; }
            if (display == "/")
                { return FrameViewModelBase.SHOT_VALUE.Spare; }

            return Enum.ToObject(typeof(FrameViewModelBase.SHOT_VALUE), Int32.Parse(display));
        }
    }
}
