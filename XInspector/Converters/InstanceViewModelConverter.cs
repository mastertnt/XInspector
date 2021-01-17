using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using XInspector.ViewModels;

namespace XInspector.Converters
{
    /// <summary>
    /// Default instance view model converter.
    /// </summary>
    public class InstanceViewModelConverter : IViewModelConverter
    {
        /// <summary>
        /// Checks if the convert support the conversion.
        /// </summary>
        /// <param name="pObject">The object to convert.</param>
        /// <returns>-1 if the conversion is not supported, the greatest priority is kept to select the converter.</returns>
        public int CanConvert(object pObject)
        {
            if (pObject is PropertyInfo || pObject is PropertyDescriptor || pObject is Type)
            {
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// Converts the type to 
        /// </summary>
        /// <param name="pObject">The object to convert.</param>
        /// <returns>The list of retrieved property view model.</returns>
        public List<IPropertyViewModel> Convert(object pObject)
        {
            List<IPropertyViewModel> lResult = new List<IPropertyViewModel>();
            PropertyDescriptorCollection lProperties = TypeDescriptor.GetProperties(pObject);
            foreach (var lPropertyInfo in lProperties)
            {
                IViewModelConverter lConverter = ConverterViewModelRegistry.Instance.FindBestConverter(lPropertyInfo);
                if (lConverter != null)
                {
                    lResult.AddRange(lConverter.Convert(lPropertyInfo));
                }
            }
            return lResult;
        }
    }
}
