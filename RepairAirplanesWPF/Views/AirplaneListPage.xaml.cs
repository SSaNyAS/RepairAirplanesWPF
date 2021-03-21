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
    /// Логика взаимодействия для AirplaneListPage.xaml
    /// </summary>
    public partial class AirplaneListPage : Page
    {
        private BaseViewModel BaseViewModel;
        public AirplaneListPage(BaseViewModel baseViewModel)
        {
            this.BaseViewModel = baseViewModel;
            baseViewModel.Airplane_listChangedEvent += BaseViewModel_Airplane_listChangedEvent;
            InitializeComponent();
            _ = baseViewModel.LoadAirplaneList();
            addAirplaneButton.Command = baseViewModel.AddAirplane_Show;
            addAirplaneButton.CommandParameter = addAirplaneButton;
        }

        private void BaseViewModel_Airplane_listChangedEvent()
        {
            airplaneListView.ItemsSource = null;
            searchTextBox_TextChanged(null, null);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            BaseViewModel.EditAirplane_Show.Execute(sender);
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            BaseViewModel.RemoveAirplane.Execute(sender);
        }

        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = searchTextBox.Text.Trim();
            if (text.Length > 0)
            {
                this.airplaneListView.ItemsSource = BaseViewModel.Airplane_list.Where((airplane) => airplane.model.Trim().ToLower().Contains(text.ToLower()));
            }
            else
            {
                this.airplaneListView.ItemsSource = BaseViewModel.Airplane_list;
            }
        }
    }
}
