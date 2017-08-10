using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BowlingAppMVVM.View
{
    public sealed class ScoreConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo info)
        {
            if (value == null)
                { return false; }

            int score = (int)value;

            return score.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo info)
        {
            if (value == null)
                { return false; }

            string display = value.ToString();
            if (display == String.Empty)
                { return 0; }

            return Int32.Parse(display);
        }
    }
}
