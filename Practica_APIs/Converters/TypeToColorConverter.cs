using System.Globalization;
using Practica_APIs.Services;

namespace Practica_APIs.Converters;

public class TypeToColorConverter: IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string type = value as string;
        return PokeColor.GetColor(type);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}