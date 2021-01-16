using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace XInspector.ViewModels
{
    /// <summary>
    /// Interface for all property view model.
    /// </summary>
    public interface IPropertyViewModel : INotifyPropertyChanged, IDisposable
    {
        /// <summary>
        /// The current edited instances.
        /// </summary>
        ObservableCollection<object> Instances
        {
            get;
        }

        /// <summary>
        /// Gets the property name.
        /// </summary>
        string PropertyName
        {
            get;
        }

        /// <summary>
        /// Gets the instance type.
        /// </summary>
        Type PropertyType
        {
            get;
        }

        /// <summary>
        /// Display string in the property inspector.
        /// </summary>
        string DisplayString
        {
            get; 
            set;
        }

        /// <summary>
        /// Tooltip in the property inspector.
        /// </summary>
        string Tooltip
        {
            get;
            set;
        }

        /// <summary>
        /// Flag to know if the property is enabled in the property inspector.
        /// </summary>
        bool IsEnabled
        {
            get; 
            set;
        }

        /// <summary>
        /// Flag to know if the property is visible.
        /// </summary>
        Visibility Visibility
        {
            get; 
            set;
        }

        /// <summary>
        /// Current value of the view model.
        /// </summary>
        object Value
        {
            get;
            set;
        }
    }
}
