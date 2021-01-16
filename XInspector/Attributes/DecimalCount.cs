using System;

namespace XInspector.Attributes
{
    /// <summary>
    /// The [Bound] attribute is used for decimal properties.
    /// <example>[DecimalCount(4)]</example>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DecimalCount : Attribute
    {
        #region Fields

        /// <summary>
        /// This variable defines 
        /// </summary>
        public static readonly DecimalCount msDefault = new DecimalCount();

        #endregion // Fields.

        #region Properties

        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        public Int32 Count 
        { 
            get; 
            set; 
        }

        #endregion

        #region Methods

        /// <summary>
        /// Default constructor.
        /// </summary>
        private DecimalCount()
        {
            this.Count = 5;
        }

        /// <summary>
        /// Constructor by initialization.
        /// </summary>
        public DecimalCount(Int32 pDecimalCount)
        {
            this.Count = pDecimalCount;
        }

        /// <summary>
        /// Compares the attribute with another one.
        /// </summary>
        /// <param name="pObject">The object to compare.</param>
        /// <returns>True if the objects are equal, false otherwise.</returns>
        public override Boolean Equals(Object pObject)
        {
            DecimalCount lBoundedObject = pObject as DecimalCount;
            return this.Count.Equals(lBoundedObject.Count);
        }

        /// <summary>
        /// Returns a hash code for the attribute.
        /// </summary>
        /// <returns>The computed hash code.</returns>
        public override Int32 GetHashCode()
        {
            return this.Count.GetHashCode();
        }

        /// <summary>
        /// This method checks if the attribute is the default attribute.
        /// </summary>
        /// <returns>True if the attribute is the default attribute, false otherwise.</returns>
        public override Boolean IsDefaultAttribute()
        {
            return this.Equals(msDefault);
        }

        #endregion
    }
}
