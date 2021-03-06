﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using XInspector.ViewModels;
using XSystem;

namespace XInspector.Editors
{
    /// <summary>
    /// Class used to retrieve an editor.
    /// </summary>
    public class PropertyEditorTemplateSelector : DataTemplateSelector
    {

        /// <summary>
        /// The list of template selector plugins
        /// </summary>
        private readonly List<IPropertyTemplateSelector> mTemplateSelectors;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public PropertyEditorTemplateSelector()
        {
            this.mTemplateSelectors = typeof(IPropertyTemplateSelector).CreateAll<IPropertyTemplateSelector>().ToList();
        }
        
        /// <summary>
        /// Selects the template according to passed PropertyInfoModel.
        /// </summary>
        /// <param name="pItem"></param>
        /// <param name="pContainer"></param>
        /// <returns></returns>
        public override DataTemplate SelectTemplate(object pItem, DependencyObject pContainer)
        {
            FrameworkElement lElement = pContainer as FrameworkElement;
            IPropertyViewModel lPropertyViewModel = pItem as IPropertyViewModel;
            DataTemplate lResult;

            foreach (IPropertyTemplateSelector lPlugin in this.mTemplateSelectors)
            {
                lResult = lPlugin.FindDataTemplate(lPropertyViewModel);
                if (lResult != null)
                {
                    return lResult;
                }
            }

            if (lPropertyViewModel.Value is Enum)
            {
                lResult = TryToFindDataTemplate(lElement, "ComboBoxEnumTemplate");
                if (lResult != null)
                {
                    return lResult;
                }
            }

            // Try to find a template for the given type
            lResult = TryToFindDataTemplate(lElement, lPropertyViewModel.PropertyType);
            if (lResult != null)
            {
                return lResult;
            }

            lResult = TryToFindDataTemplate(lElement, "DefaultTemplate");
            return lResult;
        }

        /// <summary>
        /// This method tries to find a data template
        /// </summary>
        /// <param name="pElement">The framework element used to select the data template.</param>
        /// <param name="pKey">The key of the element</param>
        /// <returns>The data template if exists, null otherwise.</returns>
        private static DataTemplate TryToFindDataTemplate(FrameworkElement pElement, String pKey)
        {
            DataTemplate lResource = pElement.TryFindResource(pKey) as DataTemplate;
            return lResource;
        }

        /// <summary>
        /// This method tries to find a data template
        /// </summary>
        /// <param name="pElement">The framework element used to select the data template.</param>
        /// <param name="pType">The type of the element</param>
        /// <returns>The data template if exists, null otherwise.</returns>
        private static DataTemplate TryToFindDataTemplate(FrameworkElement pElement, Type pType)
        {
            ComponentResourceKey lKey = new ComponentResourceKey(typeof(PropertyInspector), pType);
            return pElement.TryFindResource(lKey) as DataTemplate;
        }
    }
}
