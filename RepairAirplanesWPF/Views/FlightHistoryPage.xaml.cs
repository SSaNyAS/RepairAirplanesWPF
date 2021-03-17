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
    /// Логика взаимодействия для FlightHistoryPage.xaml
    /// </summary>
    public partial class FlightHistoryPage : Page
    {
        private BaseViewModel BaseViewModel;
        public FlightHistoryPage(BaseViewModel baseViewModel)
        {
            this.BaseViewModel = baseViewModel;
            baseViewModel.FlightLog_listChangedEvent += BaseViewModel_FlightLog_listChangedEvent;
            InitializeComponent();
            baseViewModel.LoadFlightLogList();
        }

        private void BaseViewModel_FlightLog_listChangedEvent()
        {
            this.flightLogView.ItemsSource = null;
            this.flightLogView.ItemsSource = BaseViewModel.FlightLog_list;
        }

    }
}
