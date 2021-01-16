using System;
using System.Windows.Data;

namespace XInspector.Converters
{
    /// <summary>
    /// This converter allows to convert from Enum to String[] type.
    /// </summary>
    /// <!-- Adapted by NBY -->
    [ValueConversion(typeof(Enum), typeof(Array))]
    public class EnumToEnumArrayConverter : IValueConverter
    {
        #region Methods

        /// <summary>
        /// Convert from Array to Enum.
        /// </summary>
        /// <param name="pValue">The value to convert.</param>
        /// <param name="pTargetType">The target type.</param>
        /// <param name="pExtraParameter">The extra parameter to use (not used by the converter).</param>
        /// <param name="pCulture">The culture to use (not used by the converter).</param>
        /// <returns>The value converted.</returns>
        public Object ConvertBack(Object pValue, Type pTargetType, Object pExtraParameter, System.Globalization.CultureInfo pCulture)
        {
            return Binding.DoNothing;
        }

        /// <summary>
        /// Convert from Enum to Array.
        /// </summary>
        /// <param name="pValue">The value to convert.</param>
        /// <param name="pTargetType">The target type.</param>
        /// <param name="pExtraParameter">The extra parameter to use (not used by the converter).</param>
        /// <param name="pCulture">The culture to use (not used by the converter).</param>
        /// <returns>The value converted.</returns>
        public Object Convert(Object pValue, Type pTargetType, Object pExtraParameter, System.Globalization.CultureInfo pCulture)
        {
            if (pValue != null)
            {
                if (pValue.GetType().IsEnum)
                {
                    return Enum.GetValues(pValue.GetType());
                }
            }

            return Binding.DoNothing;
        }

        #endregion // Methods.
    }
}
