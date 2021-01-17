using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using XInspector.ViewModels;

namespace XInspector.Editors
{
    /// <summary>
    /// This interface defines a template selector plugin for property editor.
    /// </summary>
    public interface IPropertyTemplateSelector
    {
        /// <summary>
        /// This method finds the data template.
        /// </summary>
        /// <param name="pViewModel">The view model.</param>
        /// <returns>The retrieved data template, null otherwise.</returns>
        DataTemplate FindDataTemplate(IPropertyViewModel pViewModel);
    }
}
