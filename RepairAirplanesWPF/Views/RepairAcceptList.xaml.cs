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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RepairAirplanesWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для RepairAcceptList.xaml
    /// </summary>
    public partial class RepairAcceptList : Page
    {
        private BaseViewModel BaseViewModel;
        public RepairAcceptList(BaseViewModel baseViewModel)
        {
            this.BaseViewModel = baseViewModel;
            baseViewModel.Repair_listChangedEvent += BaseViewModel_RepairToAccept_listChangedEvent;
            _ = baseViewModel.LoadRepairList();
            InitializeComponent();
            addRepairOrderButton.Command = baseViewModel.AddRepairListItem_Show;
            addRepairOrderButton.CommandTarget = addRepairOrderButton;
        }

        private void BaseViewModel_RepairToAccept_listChangedEvent()
        {
            this.repairListView.ItemsSource = null;
            this.repairListView.ItemsSource = BaseViewModel.Repair_list.Where((repair)=>repair.end_repair_date == null);
        }

        private void StackPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            BaseViewModel.ConfirmRequredRepairWork_Show.Execute(sender);
        }
    }
}
