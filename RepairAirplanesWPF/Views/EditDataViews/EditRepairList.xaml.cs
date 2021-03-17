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
    /// Логика взаимодействия для EditRepairList.xaml
    /// </summary>
    public partial class EditRepairList : Window
    {
        private BaseViewModel BaseViewModel;
        public EditRepairList(BaseViewModel baseViewModel)
        {
            this.BaseViewModel = baseViewModel;
            baseViewModel.Airplane_listChangedEvent += BaseViewModel_Airplane_listChangedEvent;
            InitializeComponent();
            
            addRequiredRepairWorkButton.Command = baseViewModel.AddRequredRepairWork_Show;
            addRequiredRepairWorkButton.CommandParameter = addRequiredRepairWorkButton;
        }
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            _ = BaseViewModel.LoadAirplaneList();
        }
        private void BaseViewModel_Airplane_listChangedEvent()
        {
            airplaneSelector.ItemsSource = null;
            airplaneSelector.ItemsSource = BaseViewModel.Airplane_list;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
