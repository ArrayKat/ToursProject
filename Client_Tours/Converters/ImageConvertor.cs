﻿using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Tours.Converters
{
    public class ImageConvertor : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            try
            {
                return value == null ? new Bitmap(AssetLoader.Open(new Uri("avares://Client_Tours/Assets/picture.png"))) : new Bitmap(AssetLoader.Open(new Uri($"avares://Client_Tours/Assets/{value}")));
            }
            catch
            {
                return new Bitmap(AssetLoader.Open(new Uri("avares://Client_Tours/Assets/picture.png")));
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
