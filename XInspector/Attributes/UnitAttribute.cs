using System.ComponentModel;

namespace XInspector.Attributes
{
    /// <summary>
    /// Class used to specify a unit.
    /// </summary>
    public class UnitAttribute : DescriptionAttribute
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="pUnitSymbol">The unit to symbol</param>
        public UnitAttribute(string pUnitSymbol)
        :base(pUnitSymbol)
        {

        }
    }
}
