using System.Globalization;
using System.Windows.Data;

namespace TextProcess.Wpf.Converters
{
    /// <summary>
    /// A value converter that converts input text to uppercase.
    /// </summary>
    public class ToUpperCaseConverter : IValueConverter
    {
        /// <summary>
        /// Converts the input value (text) to uppercase.
        /// </summary>
        /// <param name="value">The input value to convert.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">An optional parameter for the conversion (not used).</param>
        /// <param name="culture">The culture information (not used).</param>
        /// <returns>The input text converted to uppercase.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string text)
            {
                return text.ToUpper();
            }

            return value;
        }

        /// <summary>
        /// This method is not supported and always throws a <see cref="NotSupportedException"/>.
        /// </summary>
        /// <param name="value">The value to convert back (not supported).</param>
        /// <param name="targetType">The target type for conversion (not supported).</param>
        /// <param name="parameter">An optional parameter for the conversion (not supported).</param>
        /// <param name="culture">The culture information (not supported).</param>
        /// <returns>It always throws a <see cref="NotSupportedException"/>.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
