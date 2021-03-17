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
    /// Логика взаимодействия для EngineerListPage.xaml
    /// </summary>
    public partial class EngineerListPage : Page
    {
        private BaseViewModel BaseViewModel;
        public EngineerListPage(BaseViewModel baseViewModel)
        {
            this.BaseViewModel = baseViewModel;
            baseViewModel.Engineer_listChangedEvent += BaseViewModel_Engineer_listChangedEvent;
            InitializeComponent();
            _ = baseViewModel.LoadEngineerList();
            addEngineerButton.Command = baseViewModel.AddEngineer_Show;
            addEngineerButton.CommandParameter = addEngineerButton;
        }

        private void BaseViewModel_Engineer_listChangedEvent()
        {
            engineerListView.ItemsSource = null;
            engineerListView.ItemsSource = BaseViewModel.Engineer_list;
        }

        private void StackPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            BaseViewModel.EditEngineer_Show.Execute(sender);
        }
    }
}
