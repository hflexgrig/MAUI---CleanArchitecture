using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;

namespace MAUI.CleanArchitecture.Converters;
using Microsoft.Maui.Controls;


public class ImageSourceConverter : IValueConverter
{
    static readonly HttpClient Client = new();
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null)
            return null;

        var byteArray = Client.GetByteArrayAsync(value.ToString()!).GetAwaiter().GetResult();
        
        return ImageSource.FromStream(() => new MemoryStream(byteArray));
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}