//-----------------------------------------------------------------------
// <copyright file="RectConverter.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Globalization;
using System.Windows;
using System.Windows.Data;

using Foundation.Common;

namespace Foundation.Views.Converters
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.Data.IMultiValueConverter" />
    public class RectConverter : IMultiValueConverter
    {
        /// <summary>
        /// Converts source values to a value for the binding target. The data binding engine calls this method when it propagates the values from source bindings to the binding target.
        /// </summary>
        /// <param name="values">The array of values that the source bindings in the <see cref="T:System.Windows.Data.MultiBinding" /> produces. The value <see cref="F:System.Windows.DependencyProperty.UnsetValue" /> indicates that the source binding has no value to provide for conversion.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value.If the method returns <see langword="null" />, the valid <see langword="null" /> value is used.A return value of <see cref="T:System.Windows.DependencyProperty" />.<see cref="F:System.Windows.DependencyProperty.UnsetValue" /> indicates that the converter did not produce a value, and that the binding will use the <see cref="P:System.Windows.Data.BindingBase.FallbackValue" /> if it is available, or else will use the default value.A return value of <see cref="T:System.Windows.Data.Binding" />.<see cref="F:System.Windows.Data.Binding.DoNothing" /> indicates that the binding does not transfer the value or use the <see cref="P:System.Windows.Data.BindingBase.FallbackValue" /> or the default value.
        /// </returns>
        public Object Convert(Object[] values, Type targetType, Object parameter, CultureInfo culture)
        {
            Rect retVal = new Rect();

            if (values.HasItems() &&
                values.Length == 2)
            {
                String v1Temp = values[0].ToString() ?? "0";
                String v2Temp = values[1].ToString() ?? "0";

                if (Double.TryParse(v1Temp, out Double width) &&
                    Double.TryParse(v2Temp, out Double height))
                {
                    retVal = new Rect(0, 0, width, height);
                }
            }

            return retVal;
        }

        /// <summary>
        /// Converts a binding target value to the source binding values.
        /// </summary>
        /// <param name="value">The value that the binding target produces.</param>
        /// <param name="targetTypes">The array of types to convert to. The array length indicates the number and types of values that are suggested for the method to return.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// An array of values that have been converted from the target value back to the source values.
        /// </returns>
        public Object[]? ConvertBack(Object? value, Type[] targetTypes, Object parameter, CultureInfo culture)
        {
            Object[]? retVal = null;

            if (value is Rect rect)
            {
                Rect rectangle = rect;

                retVal = [ rectangle.Width, rectangle.Height ];
            }

            return retVal;
        }
    }
}
