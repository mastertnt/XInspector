using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using XInspector.ViewModels;

namespace XInspector.Converters
{
    /// <summary>
    /// Default property info view model converter.
    /// </summary>
    public class NativePropertyDescriptorViewModelConverter : IViewModelConverter
    {
        /// <summary>
        /// Checks if the convert support the conversion.
        /// </summary>
        /// <param name="pObject">The object to convert.</param>
        /// <returns>-1 if the conversion is not supported, the greatest priority is kept to select the converter.</returns>
        public int CanConvert(object pObject)
        {
            PropertyDescriptor lPropertyDescriptor = pObject as PropertyDescriptor;
            if (lPropertyDescriptor != null)
            {
                if (lPropertyDescriptor.PropertyType == typeof(int))
                {
                    return 1;
                }
                if (lPropertyDescriptor.PropertyType == typeof(double))
                {
                    return 1;
                }
                if (lPropertyDescriptor.PropertyType == typeof(Single))
                {
                    return 1;
                }
                if (lPropertyDescriptor.PropertyType == typeof(long))
                {
                    return 1;
                }
                return 0;
            }

            return -1;
        }

        /// <summary>
        /// Converts the type to 
        /// </summary>
        /// <param name="pObject">The object to convert.</param>
        /// <returns>The list of retrieved property view model.</returns>
        public List<IPropertyViewModel> Convert(object pObject)
        {
            List<IPropertyViewModel> lResult = new List<IPropertyViewModel>();
            lResult.Add(new NativePropertyDescriptorViewModel(pObject as PropertyDescriptor));
            return lResult;
        }
    }
}
