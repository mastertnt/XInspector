using System;

namespace XInspector.Attributes
{
    /// <summary>
    /// The [SelectableCollection] attribute is used to link a collection with and index of a class.
    /// The collection becomes a collection with a selected item.
    /// The index must be hidden with [Browsable(false)] to avoid a second display.
    /// </summary>
    /// <example>[SelectableCollection(NameOfIndex)]</example>
    /// <!-- NBY -->
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class SelectableCollectionAttribute : Attribute
    { 
        #region Properties

        /// <summary>
        /// Gets the name of the index property.
        /// </summary>
        public String IndexPropertyName
        {
            get;
            private set;
        }

        #endregion // Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectableCollectionAttribute"/> class.
        /// </summary>
        public SelectableCollectionAttribute(String pIndexPropertyName)
        {
            this.IndexPropertyName = pIndexPropertyName;
        }

        #endregion // Constructors.
    }
}
