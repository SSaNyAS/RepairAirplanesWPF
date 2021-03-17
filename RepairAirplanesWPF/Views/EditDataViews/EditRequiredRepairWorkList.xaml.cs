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
    /// Логика взаимодействия для EditRequiredRepairWorkList.xaml
    /// </summary>
    public partial class EditRequiredRepairWorkList : Window
    {
        private BaseViewModel BaseViewModel;
        public EditRequiredRepairWorkList(BaseViewModel baseViewModel)
        {
            this.BaseViewModel = baseViewModel;
            baseViewModel.Repair_work_listChangedEvent += BaseViewModel_Repair_work_listChangedEvent;
            baseViewModel.Repair_status_listChangedEvent += BaseViewModel_Repair_status_listChangedEvent;
            baseViewModel.Engineer_listChangedEvent += BaseViewModel_Engineer_listChangedEvent;

            InitializeComponent();

            addRepairWorkButton.Command = baseViewModel.AddRepairWork_Show;
            addRepairWorkButton.CommandParameter = addRepairWorkButton;

            addRepairStatusButton.Command = baseViewModel.AddRepairStatus_Show;
            addRepairStatusButton.CommandParameter = addRepairStatusButton;

            addRequiredRepairPartButton.Command = baseViewModel.AddRequredRepairPart_Show;
            addRequiredRepairPartButton.CommandParameter = addRequiredRepairPartButton;
        }
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            _ = BaseViewModel.LoadRepairWorkList();
            _ = BaseViewModel.LoadRepairStatusList();
            _ = BaseViewModel.LoadEngineerList();
        }
        private void BaseViewModel_Repair_status_listChangedEvent()
        {
            repairStatusSelector.ItemsSource = null;
            repairStatusSelector.ItemsSource = BaseViewModel.Repair_status_list;
        }

        private void BaseViewModel_Engineer_listChangedEvent()
        {
            engineerSelector.ItemsSource = null;
            engineerSelector.ItemsSource = BaseViewModel.Engineer_list;
        }

        private void BaseViewModel_Repair_work_listChangedEvent()
        {
            repairWorkSelector.ItemsSource = null;
            repairWorkSelector.ItemsSource = BaseViewModel.Repair_work_list;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}

