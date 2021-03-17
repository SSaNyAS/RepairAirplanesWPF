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
    /// Логика взаимодействия для EditEngine.xaml
    /// </summary>
    public partial class EditEngine : Window
    {
        public BaseViewModel BaseViewModel;
        public EditEngine(BaseViewModel baseViewModel)
        {
            this.BaseViewModel = baseViewModel;
            this.BaseViewModel.Fuel_type_listChangedEvent += BaseViewModel_Fuel_type_listChangedEvent;
            this.BaseViewModel.Cooling_system_listChangedEvent += BaseViewModel_Cooling_system_listChangedEvent;
            InitializeComponent();
            addCoolingSystemButton.Command = baseViewModel.AddCoolingSystem_Show;
            addCoolingSystemButton.CommandParameter = addCoolingSystemButton;
        }

        private void BaseViewModel_Cooling_system_listChangedEvent()
        {
            this.coolingSystemSelector.ItemsSource = null;
            this.coolingSystemSelector.ItemsSource = BaseViewModel.Cooling_system_list;
        }

        private void BaseViewModel_Fuel_type_listChangedEvent()
        {

        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            _ = BaseViewModel.LoadFuelTypeList();
            _ = BaseViewModel.LoadCoolingSystemList();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
