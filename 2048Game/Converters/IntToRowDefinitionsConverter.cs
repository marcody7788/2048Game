using System.Globalization;

namespace _2048Game.Converters
{
    public class IntToRowDefinitionsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => new RowDefinitionCollection(GetRowDefinitions((int)value).ToArray());

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

        private static IEnumerable<RowDefinition> GetRowDefinitions(int numerOfRowDefinitions) => Enumerable.Repeat(new RowDefinition(GridLength.Auto), numerOfRowDefinitions);

    }
}
