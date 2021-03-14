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

namespace RepairAirplanesWPF.UIComponents
{
    /// <summary>
    /// Логика взаимодействия для FrameworkElementWithHeader.xaml
    /// </summary>
    public partial class FrameworkElementWithHeader<T> : UserControl where T : ContentControl
    {
        public string HeaderText
        {
            get
            {
                return GetValue(HeaderTextProperty) as string;
            }
            set
            {
                SetValue(HeaderTextProperty, value);
            }
        }
        public string Text
        {
            get
            {
                return GetValue(TextProperty) as string;
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }
        public Orientation Orientation
        {
            get
            {
                return firstStackPanel.Orientation;
            }
            set
            {
                firstStackPanel.Orientation = value;
            }
        }
        public string EndText
        {
            get
            {
                return GetValue(TextProperty) as string;
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }
        public static DependencyProperty HeaderTextProperty;
        public static DependencyProperty TextProperty;
        public static DependencyProperty EndTextProperty;
        private StackPanel firstStackPanel;
        public FrameworkElementWithHeader()
        {
            this.DataContext = this;
            this.firstStackPanel = new StackPanel();

            var bindingToOrientation = new Binding();
            bindingToOrientation.Source = this;
            bindingToOrientation.Path = new PropertyPath("Orientation");
            this.firstStackPanel.SetBinding(StackPanel.OrientationProperty, bindingToOrientation);


            //InitializeComponent();
            var secondStackPanel = new StackPanel();
            secondStackPanel.Orientation = Orientation.Horizontal;

            var headerTextBox = new TextBox();
            var bindingToHeaderText = new Binding();
            bindingToHeaderText.Source = this;
            bindingToHeaderText.Path = new PropertyPath("HeaderText");
            headerTextBox.SetBinding(TextProperty, bindingToHeaderText);

            var textTextBox = new TextBox();
            var bindingToText = new Binding();
            bindingToText.Source = this;
            bindingToText.Path = new PropertyPath("Text");
            textTextBox.SetBinding(TextProperty, bindingToText);

            var endTextTextBox = new TextBox();
            var bindingToEndText = new Binding();
            bindingToEndText.Source = this;
            bindingToEndText.Path = new PropertyPath("EndText");
            endTextTextBox.SetBinding(TextProperty, bindingToEndText);
            endTextTextBox.Margin = new Thickness(5, 0, 0, 0);

            secondStackPanel.Children.Add(textTextBox);
            secondStackPanel.Children.Add(endTextTextBox);

            firstStackPanel.Children.Add(headerTextBox);
            firstStackPanel.Children.Add(secondStackPanel);
        }
        static FrameworkElementWithHeader()
        {
            HeaderTextProperty = DependencyProperty.Register("HeaderText", typeof(string), typeof(FrameworkElementWithHeader<T>));
            TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(FrameworkElementWithHeader<T>));
            EndTextProperty = DependencyProperty.Register("EndText", typeof(string), typeof(FrameworkElementWithHeader<T>));
        }
    }
}
