using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace XInspector.ViewModels
{
    /// <summary>
    /// Abstract class for all property view model.
    /// </summary>
    public abstract class BasePropertyViewModel : IPropertyViewModel

    {
        
        private bool mIsDisposed = false; // to detect redundant calls

        /// <summary>
        /// Default constructor.
        /// </summary>
        protected BasePropertyViewModel()
        {
            this.Instances = new ObservableCollection<object>();
            this.Instances.CollectionChanged += this.OnInstancesChanged;
        }

        /// <summary>
        /// Event raised when a property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets all edited instances.
        /// </summary>
        public virtual ObservableCollection<object> Instances
        {
            get;
        }

        /// <summary>
        /// Gets the property name.
        /// </summary>
        public virtual string PropertyName
        {
            get;
        }

        /// <summary>
        /// Gets the property type.
        /// </summary>
        public virtual Type PropertyType
        {
            get;
        }

        /// <summary>
        /// Display string in the property inspector.
        /// </summary>
        public virtual string DisplayString
        {
            get;
            set;
        }

        /// <summary>
        /// Tooltip in the property inspector.
        /// </summary>
        public virtual string Tooltip
        {
            get;
            set;
        }

        /// <summary>
        /// Flag to know if the property is enabled in the property inspector.
        /// </summary>
        public virtual bool IsEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// Flag to know if the property is visible in the property inspector.
        /// </summary>
        public virtual Visibility Visibility
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public virtual object Value
        {
            get;
            set;
        }
        
        /// <summary>
        /// This method is called when the instances are changed.
        /// </summary>
        /// <param name="pEventSender">The event sender.</param>
        /// <param name="pEventArgs">The event args</param>
        public void OnInstancesChanged(object pEventSender, NotifyCollectionChangedEventArgs pEventArgs)
        {
            switch (pEventArgs.Action)
            {
                case NotifyCollectionChangedAction.Remove:
                {
                    foreach (var lEditedObject in pEventArgs.OldItems)
                    {
                        INotifyPropertyChanged lPropertyChanged = lEditedObject as INotifyPropertyChanged;
                        if (lPropertyChanged != null)
                        {
                            lPropertyChanged.PropertyChanged -= this.OnInstancePropertyChanged;
                        }
                    }
                }
                break;

                case NotifyCollectionChangedAction.Add:
                {
                    foreach (var lEditedObject in pEventArgs.NewItems)
                    {
                        INotifyPropertyChanged lPropertyChanged = lEditedObject as INotifyPropertyChanged;
                        if (lPropertyChanged != null)
                        {
                            lPropertyChanged.PropertyChanged += this.OnInstancePropertyChanged;
                        }
                    }
                }
                break;
            }
        }

        protected virtual void OnInstancePropertyChanged(object pEventSender, PropertyChangedEventArgs pEventArgs)
        {
            if (pEventArgs.PropertyName == this.PropertyName)
            {
                this.NotifyPropertyChanged("Value");
            }
        }

        protected virtual void NotifyPropertyChanged(string pPropertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(pPropertyName));
        }

        protected virtual void Dispose(bool pIsDisposing)
        {
            if (!this.mIsDisposed)
            {
                if (pIsDisposing)
                {
                    foreach (var lEditedObject in this.Instances)
                    {
                        INotifyPropertyChanged lPropertyChanged = lEditedObject as INotifyPropertyChanged;
                        if (lPropertyChanged != null)
                        {
                            lPropertyChanged.PropertyChanged -= this.OnInstancePropertyChanged;
                        }
                    }
                }

                // There are no unmanaged resources to release, but
                // if we add them, they need to be released here.
            }
            this.mIsDisposed = true;
        }

        /// <summary>
        /// Dispose the class.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }
    }
}
