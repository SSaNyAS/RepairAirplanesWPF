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
    /// Логика взаимодействия для EditRequiredRepairPartList.xaml
    /// </summary>
    public partial class EditRequiredRepairPartList : Window
    {
        private BaseViewModel BaseViewModel;
        public EditRequiredRepairPartList(BaseViewModel baseViewModel)
        {
            this.BaseViewModel = baseViewModel;
            baseViewModel.Repair_part_listChangedEvent += BaseViewModel_Repair_part_listChangedEvent;
            InitializeComponent();
            addRepairPartButton.Command = baseViewModel.AddRepairPart_Show;
            addRepairPartButton.CommandParameter = addRepairPartButton;
        }
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            
            _ = BaseViewModel.LoadRepairPartList();
        }
        private void BaseViewModel_Repair_part_listChangedEvent()
        {
            var saved = repairPartSelector.SelectedValue;
            repairPartSelector.ItemsSource = null;
            repairPartSelector.ItemsSource = BaseViewModel.Repair_part_list;
            repairPartSelector.SelectedValue = saved;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
