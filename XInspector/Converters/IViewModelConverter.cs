using System.Collections.Generic;
using XInspector.ViewModels;

namespace XInspector.Converters
{
    /// <summary>
    /// This interface transforms an object to the corresponding view model.
    /// </summary>
    public interface IViewModelConverter
    {
        /// <summary>
        /// Checks if the convert support the conversion.
        /// </summary>
        /// <param name="pObject">The object to convert.</param>
        /// <returns>-1 if the conversion is not supported, the greatest priority is kept to select the converter.</returns>
        int CanConvert(object pObject);

        /// <summary>
        /// Converts the type to 
        /// </summary>
        /// <param name="pObject">The object to convert.</param>
        /// <returns>The list of retrieved property view model.</returns>
        List<IPropertyViewModel> Convert(object pObject);

    }
}
