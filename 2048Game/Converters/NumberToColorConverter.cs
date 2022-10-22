using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048Game.Converters
{
    internal class NumberToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((int)value)
            {
                case 0: return Colors.WhiteSmoke;
                case 2: return Colors.Goldenrod;
                case 4: return Colors.YellowGreen;
                case 8: return Colors.OliveDrab;
                case 16: return Colors.Green;
                case 32: return Colors.SkyBlue;
                case 64: return Colors.SteelBlue;
                case 128: return Colors.DarkSlateBlue; 
                case 256: return Colors.MediumPurple;
                case 512: return Colors.PaleVioletRed;
                case 1024: return Colors.Tomato;
                case 2048: return Colors.DarkRed;
                default: throw new NotImplementedException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
