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
    /// Логика взаимодействия для ConfirmRequiredRepairList.xaml
    /// </summary>
    public partial class ConfirmRequiredRepairList : Window
    {
        private BaseViewModel BaseViewModel;
        public ConfirmRequiredRepairList(BaseViewModel baseViewModel)
        {
            this.BaseViewModel = baseViewModel;
            InitializeComponent();
            printRepairInfo.Command = baseViewModel.PrintRepairInfo;
            printRepairInfo.CommandParameter = printRepairInfo;
        }
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            updateList();
        }
        private void updateList()
        {
            var saved = repairWorkList.ItemsSource;
            repairWorkList.ItemsSource = null;
            repairWorkList.ItemsSource = saved;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BaseViewModel.ConfirmRequredRepairWork.Execute(sender);
            updateList();
        }
    }
}
