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
    /// Логика взаимодействия для TextBoxWithHeader.xaml
    /// </summary>
    public partial class TextBoxWithHeader : UserControl
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
        public TextBoxWithHeader()
        {
            this.DataContext = this;
            InitializeComponent();
        }
        static TextBoxWithHeader()
        {
            HeaderTextProperty = DependencyProperty.Register("HeaderText", typeof(string), typeof(TextBoxWithHeader));
            TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(TextBoxWithHeader));
            EndTextProperty = DependencyProperty.Register("EndText", typeof(string), typeof(TextBoxWithHeader));
        }
    }
}
