using RepairAirplanesWPF.ViewModels;
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
using System.Windows.Shapes;

namespace RepairAirplanesWPF.Views.EditDataViews
{
    /// <summary>
    /// Логика взаимодействия для EditPermissionForGroup.xaml
    /// </summary>
    public partial class EditPermissionForGroup : Window
    {
        public BaseViewModel BaseViewModel;
        public EditPermissionForGroup(BaseViewModel baseViewModel)
        {
            this.BaseViewModel = baseViewModel;
            InitializeComponent();
        }
    }
}
