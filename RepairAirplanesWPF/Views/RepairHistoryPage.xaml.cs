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
    /// Логика взаимодействия для RepairHistoryPage.xaml
    /// </summary>
    public partial class RepairHistoryPage : Page
    {
        private BaseViewModel BaseViewModel;
        public RepairHistoryPage(BaseViewModel baseViewModel)
        {
            this.BaseViewModel = baseViewModel;
            baseViewModel.Repair_listChangedEvent += BaseViewModel_FinishedRepair_listChangedEvent;
            _ = baseViewModel.LoadRepairList();
            InitializeComponent();
        }

        private void BaseViewModel_FinishedRepair_listChangedEvent()
        {
            this.repairListView.ItemsSource = null;
            this.repairListView.ItemsSource = BaseViewModel.Repair_list.Where((repair)=>repair.end_repair_date != null);
        }

        private void StackPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            BaseViewModel.ConfirmRequredRepairWork_Show.Execute(sender);
        }
    }
}
