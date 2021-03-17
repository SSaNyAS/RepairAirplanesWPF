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
    /// Логика взаимодействия для PersonListPage.xaml
    /// </summary>
    public partial class PersonListPage : Page
    {
        private BaseViewModel BaseViewModel;
        public PersonListPage(BaseViewModel baseViewModel)
        {
            this.BaseViewModel = baseViewModel;
            baseViewModel.Person_listChangedEvent += BaseViewModel_Person_listChangedEvent;
            InitializeComponent();
            _ = baseViewModel.LoadPersonList();
            addPersonButton.Command = baseViewModel.AddPerson_Show;
            addPersonButton.CommandParameter = addPersonButton;
        }

        private void BaseViewModel_Person_listChangedEvent()
        {
            this.personListView.ItemsSource = null;
            this.personListView.ItemsSource = BaseViewModel.Person_list;
        }

        private void StackPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            BaseViewModel.EditPerson_Show.Execute(sender);
        }
    }
}
