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
            var saved = repairStatusSelector.SelectedValue;
            repairStatusSelector.ItemsSource = null;
            repairStatusSelector.ItemsSource = BaseViewModel.Repair_status_list;
            repairStatusSelector.SelectedValue = saved;
        }

        private void BaseViewModel_Engineer_listChangedEvent()
        {
            var saved = engineerSelector.SelectedValue;
            engineerSelector.ItemsSource = null;
            engineerSelector.ItemsSource = BaseViewModel.Engineer_list;
            engineerSelector.SelectedValue = saved;
            if (DataContext is Required_repair_work required_Repair_Work)
            {
                requiredRepairPartListView.ItemsSource = required_Repair_Work.Required_repair_part.ToList();
            }
        }

        private void BaseViewModel_Repair_work_listChangedEvent()
        {
            var saved = repairWorkSelector.SelectedValue;
            repairWorkSelector.ItemsSource = null;
            repairWorkSelector.ItemsSource = BaseViewModel.Repair_work_list;
            repairWorkSelector.SelectedValue = saved;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
        private void RemovePart_Click(object sender, RoutedEventArgs e)
        {
            BaseViewModel.RemoveRequredRepairPart.Execute(sender);
        }
    }
}

