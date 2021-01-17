using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using XInspector.Editors;
using XInspector.ViewModels;

namespace XInspector.Demo
{
    class DemoTemplateSelector : IPropertyTemplateSelector
    {
        /// <summary>
        /// This field stores the loaded resource dictionary.
        /// </summary>
        private ResourceDictionary mResourceDictionnary;

        /// <summary>
        /// Initializes a new instance of the <see cref="DemoTemplateSelector"/> class.
        /// </summary>
        public DemoTemplateSelector()
        {
            this.mResourceDictionnary = new ResourceDictionary();
            this.mResourceDictionnary.Source = new Uri("/XInspector.Demo;component/DemoTemplates.xaml", UriKind.RelativeOrAbsolute);
        }

        /// <summary>
        /// This method finds the data template.
        /// </summary>
        /// <param name="pViewModel">The view model.</param>
        /// <returns>The retrieved data template, null otherwise.</returns>
        public DataTemplate FindDataTemplate(IPropertyViewModel pViewModel)
        {
            //if (pViewModel.PropertyType == typeof(XInspector.SampleModels.Point))
            //{
            //    return this.mResourceDictionnary["PointTemplate"] as DataTemplate;
            //}

            return null;
        }
    }
}
