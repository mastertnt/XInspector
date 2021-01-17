using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XInspector.Attributes;
using XSystem;

namespace XInspector.ViewModels
{
    public class NativePropertyDescriptorViewModel : PropertyDescriptorViewModel
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="pPropertyDescriptor">The property info.</param>
        public NativePropertyDescriptorViewModel(PropertyDescriptor pPropertyDescriptor)
            : base(pPropertyDescriptor)
        {

        }

        /// <summary>
        /// Minimum value allowed.
        /// </summary>
        public long Minimum
        {
            get
            {
                BoundAttribute lAttribute = this.mPropertyDescriptor.GetFirstAttributeOfType<BoundAttribute>();
                if (lAttribute != null)
                {
                    return lAttribute.Minimum;
                }

                return Int64.MinValue;
            }
            set
            {

            }
        }

        /// <summary>
        /// Maximum value allowed.
        /// </summary>
        public long Maximum
        {
            get
            {
                BoundAttribute lAttribute = this.mPropertyDescriptor.GetFirstAttributeOfType<BoundAttribute>();
                if (lAttribute != null)
                {
                    return lAttribute.Maximum;
                }

                return Int64.MaxValue;
            }
            set
            {

            }
        }

        /// <summary>
        /// Number of decimals allowed.
        /// </summary>
        public int DecimalCount
        {
            get
            {
                DecimalCount lAttribute = this.mPropertyDescriptor.GetFirstAttributeOfType<DecimalCount>();
                if (lAttribute != null)
                {
                    return lAttribute.Count;
                }

                return 5;
            }
            set
            {

            }
        }

        /// <summary>
        /// Unit to display.
        /// </summary>
        public String Unit
        {
            get
            {
                UnitAttribute lAttribute = this.mPropertyDescriptor.GetFirstAttributeOfType<UnitAttribute>();
                if (lAttribute != null)
                {
                    return lAttribute.Description;
                }

                return string.Empty;
            }
            set
            {

            }
        }
    }
}
