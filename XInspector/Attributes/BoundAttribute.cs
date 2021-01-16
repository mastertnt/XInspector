using System;

namespace XInspector.Attributes
{
    /// <summary>
    /// The [Bound] attribute is used for numeric properties.
    /// <example>[Bound(0,100)]</example>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class BoundAttribute : Attribute
    {
        #region Fields

        /// <summary>
        /// This variable defines 
        /// </summary>
        public static readonly BoundAttribute msDefault = new BoundAttribute();

        #endregion // Fields.

        #region Properties

        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        public virtual Int64 Minimum 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        public virtual Int64 Maximum 
        { 
            get; 
            set; 
        }

        #endregion

        #region Methods

        /// <summary>
        /// Default constructor.
        /// </summary>
        private BoundAttribute()
        {
            this.Minimum = 0;
            this.Maximum = 100;
        }

        /// <summary>
        /// Constructor by initialization.
        /// </summary>
        public BoundAttribute(Int64 pMinimum, Int64 pMaximum)
        {
            this.Minimum = pMinimum;
            this.Maximum = pMaximum;
        }

        /// <summary>
        /// Compares the attribute with another one.
        /// </summary>
        /// <param name="pObject">The object to compare.</param>
        /// <returns>True if the objects are equal, false otherwise.</returns>
        public override Boolean Equals(Object pObject)
        {
            BoundAttribute lBoundedObject = pObject as BoundAttribute;
            return this.Minimum.Equals(lBoundedObject.Minimum) && this.Maximum.Equals(lBoundedObject.Maximum);
        }

        /// <summary>
        /// Returns a hash code for the attribute.
        /// </summary>
        /// <returns>The computed hash code.</returns>
        public override Int32 GetHashCode()
        {
            return this.Minimum.GetHashCode() ^ this.Maximum.GetHashCode();
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
