using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSystem;

namespace XInspector.Converters
{
    /// <summary>
    /// This class stores all view model converters.
    /// </summary>
    public sealed class ConverterViewModelRegistry
    {
        /// <summary>
        /// This field stores the unique instance of the class.
        /// </summary>
        private static readonly Lazy<ConverterViewModelRegistry> msLazy = new Lazy<ConverterViewModelRegistry>(() => new ConverterViewModelRegistry());

        /// <summary>
        /// Gets the unique instance.
        /// </summary>
        public static ConverterViewModelRegistry Instance
        {
            get
            {
                return msLazy.Value;
            }
        }

        /// <summary>
        /// Get the list of all converters.
        /// </summary>
        public List<IViewModelConverter> Converters
        {
            get;
            set;
        }

        private ConverterViewModelRegistry()
        {
            this.Converters = new List<IViewModelConverter>();
        }

        /// <summary>
        /// Find all IComponent based types to get their corresponding component descriptors in cache.
        /// </summary>
        public void FindAllConverters()
        {
            IEnumerable<object> lConverters = typeof(IViewModelConverter).CreateAll();
            foreach (var lConverter in lConverters)
            {
                this.Converters.Add(lConverter as IViewModelConverter);
            }
        }
    }
}
