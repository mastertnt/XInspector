using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using XInspector.SampleModels;

namespace XInspector.Demo
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void Instances_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Inspector.EditedObjects = new List<object>(){ e.AddedItems[0]};
            this.Inspector2.EditedObjects = new List<object>() { e.AddedItems[0] };
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Instances.Items.Add(new Simple() { BooleanValue = true, DoubleValue = 3.1, IntValue = 42, StringValue = "MyString", Position = new XInspector.SampleModels.Point() { X=23, Y=31} });
        }
    }
}
