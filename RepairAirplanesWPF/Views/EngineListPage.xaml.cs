using RepairAirplanesWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для EngineListPage.xaml
    /// </summary>
    public partial class EngineListPage : Page
    {
        private BaseViewModel BaseViewModel;
        public EngineListPage( BaseViewModel baseViewModel)
        {
            this.BaseViewModel = baseViewModel;
            baseViewModel.Engine_listChangedEvent += BaseViewModel_Engine_listChangedEvent;
            InitializeComponent();
            _ = BaseViewModel.LoadEngineList();
            addEngineButton.Command = baseViewModel.AddEngine_Show;
            addEngineButton.CommandParameter = addEngineButton;
        }
        private void BaseViewModel_Engine_listChangedEvent()
        {
            this.engineListView.ItemsSource = null;
            this.engineListView.ItemsSource = BaseViewModel.Engine_list;
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            BaseViewModel.EditEngine_Show.Execute(sender);
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            BaseViewModel.RemoveEngine.Execute(sender);
        }
    }
}
