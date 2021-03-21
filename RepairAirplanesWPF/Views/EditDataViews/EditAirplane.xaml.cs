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
    /// Логика взаимодействия для EditAirplane.xaml
    /// </summary>
    public partial class EditAirplane : Window
    {
        private BaseViewModel BaseViewModel;
        public EditAirplane(BaseViewModel baseViewModel)
        {
            this.BaseViewModel = baseViewModel;
            baseViewModel.Engine_listChangedEvent += BaseViewModel_Engine_listChangedEvent;
            InitializeComponent();
            _ = baseViewModel.LoadEngineList();
            addEngineButton.Command = baseViewModel.AddEngine_Show;
            addEngineButton.CommandParameter = addEngineButton;
        }

        private void BaseViewModel_Engine_listChangedEvent()
        {
            var saved = engineSelector.SelectedValue;
            engineSelector.ItemsSource = null;
            engineSelector.ItemsSource = BaseViewModel.Engine_list;
            engineSelector.SelectedValue = saved;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
