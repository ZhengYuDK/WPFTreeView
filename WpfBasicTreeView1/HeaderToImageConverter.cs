using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WpfBasicTreeView1
{
    [ValueConversion(typeof(string),typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var path = (string)value;

            if (path == null)
                return null;

            var image = "IconImages/file.png";

            if (string.IsNullOrEmpty(path))
            {
                image = "IconImages/drive.png";
            }else if ( new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
            {
                image = "IconImages/folder.png";
            }

            return new BitmapImage(new Uri($"pack://Application:,,,/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
