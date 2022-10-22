using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048Game.Converters
{
    public class IntToColumnDefinitionsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => new ColumnDefinitionCollection(GetColumnDefinitions((int)value).ToArray());

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

        private static IEnumerable<ColumnDefinition> GetColumnDefinitions(int numerOfColumnDefinitions) => Enumerable.Repeat(new ColumnDefinition(GridLength.Auto), numerOfColumnDefinitions);
    }
}
