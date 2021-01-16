using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using XSystem;

namespace XInspector.ViewModels
{
    public class PropertyDescriptorViewModel : BasePropertyViewModel
    {
        /// <summary>
        /// This field stores the corresponding property info.
        /// </summary>
        protected readonly PropertyDescriptor mPropertyDescriptor;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="pPropertyDescriptor">The property info.</param>
        public PropertyDescriptorViewModel(PropertyDescriptor pPropertyDescriptor)
        {
            this.mPropertyDescriptor = pPropertyDescriptor;
        }

        /// <summary>
        /// Gets the property name.
        /// </summary>
        public override string PropertyName
        {
            get
            {
                return this.mPropertyDescriptor.Name;
            }
        }

        /// <summary>
        /// Gets the property type.
        /// </summary>
        public override Type PropertyType
        {
            get
            {
                return this.mPropertyDescriptor.PropertyType;
            }
        }

        /// <summary>
        /// Gets or sets the display string.
        /// </summary>
        public override string DisplayString
        {
            get
            {
                return this.mPropertyDescriptor.Name;
            }
            set
            {
                // Nothing to do.
            }
        }

        /// <summary>
        /// Flag to know if the property is enabled in the property inspector.
        /// </summary>
        public override bool IsEnabled
        {
            get
            {
                ReadOnlyAttribute lReadOnlyAttribute = this.mPropertyDescriptor.GetFirstAttributeOfType<ReadOnlyAttribute>();
                if (lReadOnlyAttribute != null)
                {
                    return lReadOnlyAttribute.IsReadOnly == false;
                }
                
                return this.mPropertyDescriptor.IsReadOnly == false;
            }
            set
            {

            }
        }

        /// <summary>
        /// Flag to know if the property is visible in the property inspector.
        /// </summary>
        public override Visibility Visibility
        {
            get
            {
                BrowsableAttribute lBrowsableAttribute = this.mPropertyDescriptor.GetFirstAttributeOfType<BrowsableAttribute>();
                if (lBrowsableAttribute != null)
                {
                    return  lBrowsableAttribute.Browsable ? Visibility.Visible : Visibility.Collapsed;
                }

                return Visibility.Visible;
            }
            set
            {

            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public override object Value
        {
            get
            {
                return this.mPropertyDescriptor.GetValue(this.Instances.FirstOrDefault());
            }
            set
            {
                if (this.Instances.FirstOrDefault() != null)
                {
                    this.mPropertyDescriptor.SetValue(this.Instances.FirstOrDefault(), value);
                }
            }
        }
    }
}
