using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using XInspector.Converters;
using XInspector.ViewModels;

namespace XInspector
{
    /// <summary>
    /// Logique d'interaction pour PropertyInspector.xaml
    /// </summary>
    public partial class PropertyInspector : UserControl
    {
        /// <summary>
        /// This field defines a dependency on the property "EditedObjects".
        /// </summary>
        public static readonly DependencyProperty msEditedObjectsProperty = DependencyProperty.Register("EditedObjects", typeof(IEnumerable<object>), typeof(PropertyInspector), new UIPropertyMetadata(null, EditedObjectsChanged));

        /// <summary>
        /// This field defines a dependency on the property "ViewModels".
        /// </summary>
        public static readonly DependencyProperty msViewModelsProperty = DependencyProperty.Register("ViewModels", typeof(ObservableCollection<IPropertyViewModel>), typeof(PropertyInspector), new UIPropertyMetadata(null, ViewModelsChanged));

        /// <summary>
        /// Default constructor.
        /// </summary>
        public PropertyInspector()
        {
            this.InitializeComponent();
            this.ViewModels = new ObservableCollection<IPropertyViewModel>();
            ConverterViewModelRegistry.Instance.FindAllConverters();
            this.DataContext = this;
            
        }

        /// <summary>
        /// Delegate called when the event "Unloaded" is raised.
        /// </summary>
        /// <param name="pEventSender"></param>
        /// <param name="pEventArgs"></param>
        private void OnUnloaded(object pEventSender, RoutedEventArgs pEventArgs)
        {
            this.ClearContent();
        }

        /// <summary>
        /// Gets or sets the list of edited objects.
        /// </summary>
        public IEnumerable<object> EditedObjects
        {
            get
            {
                return (IEnumerable<object>) this.GetValue(msEditedObjectsProperty);
            }
            set
            {
                this.SetValue(msEditedObjectsProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the list of edited objects.
        /// </summary>
        public ObservableCollection<IPropertyViewModel> ViewModels
        {
            get
            {
                return (ObservableCollection<IPropertyViewModel>) this.GetValue(msViewModelsProperty);
            }
            set
            {
                this.SetValue(msViewModelsProperty, value);
            }
        }

        /// <summary>
        /// This delegate is called when the edited objects are changed.
        /// </summary>
        /// <param name="pObject">The modified control.</param>
        /// <param name="pArgs">The event arguments.</param>
        private static void EditedObjectsChanged(DependencyObject pObject, DependencyPropertyChangedEventArgs pArgs)
        {
            PropertyInspector lPropertyInspector = (PropertyInspector)pObject;
            if
                (lPropertyInspector != null)
            {
                lPropertyInspector.UpdateContent();
            }
        }

        /// <summary>
        /// This delegate is called when the view models are changed.
        /// </summary>
        /// <param name="pObject">The modified control.</param>
        /// <param name="pArgs">The event arguments.</param>
        private static void ViewModelsChanged(DependencyObject pObject, DependencyPropertyChangedEventArgs pArgs)
        {
            // Nothing to do.
        }

        /// <summary>
        /// Updates the content of the control
        /// (after initialization and SelectedObject changes)
        /// </summary>
        private void UpdateContent()
        {
            // Checks if the control has been loaded.
            if
            ((this.IsVisible == false)
             || (this.InnerGrid == null)
            )
            {
                return;
            }

            // Clear the model.
            this.ClearContent();
            
            // Try to find view model converter for this given type.
            if (this.EditedObjects != null)
            {
                if (this.EditedObjects.Any())
                {
                    IViewModelConverter lConverter = ConverterViewModelRegistry.Instance.FindBestConverter(this.EditedObjects.First());
                    if (lConverter != null)
                    {
                        List<IPropertyViewModel> lViewModels = lConverter.Convert(this.EditedObjects.First());
                        foreach (var lViewModel in lViewModels)
                        {
                            lViewModel.Instances.Add(this.EditedObjects.First());
                            this.ViewModels.Add(lViewModel);
                        }
                    }
                }
            }
            
        }

        /// <summary>
        /// Clear the content of the control.
        /// </summary>
        private void ClearContent()
        {
            foreach (var lViewModel in this.ViewModels)
            {
                lViewModel.Dispose();
            }
            this.ViewModels.Clear();
        }
    }
}
