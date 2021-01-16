using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using XInspector.ViewModels;

namespace XInspector.Converters
{
    /// <summary>
    /// Default property info view model converter.
    /// </summary>
    public class PropertyDescriptorViewModelConverter : IViewModelConverter
    {
        /// <summary>
        /// Checks if the convert support the conversion.
        /// </summary>
        /// <param name="pObject">The object to convert.</param>
        /// <returns>-1 if the conversion is not supported, the greatest priority is kept to select the converter.</returns>
        public int CanConvert(object pObject)
        {
            if (pObject is PropertyDescriptor)
            {
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
            lResult.Add(new PropertyDescriptorViewModel(pObject as PropertyDescriptor));
            return lResult;
        }
    }
}
