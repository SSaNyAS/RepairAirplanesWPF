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
            printPersonButton.Command = baseViewModel.PrintPerson;
            printPersonButton.CommandParameter = printPersonButton;
        }

        private void BaseViewModel_Person_listChangedEvent()
        {
            this.personListView.ItemsSource = null;
            searchTextBox_TextChanged(null,null);
        }

        private void StackPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            BaseViewModel.EditPerson_Show.Execute(sender);
        }

        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = searchTextBox.Text.Trim();
            if (text.Length > 0)
            {
                this.personListView.ItemsSource = BaseViewModel.Person_list.Where((person) => person.FIO.Trim().ToLower().Contains(text.ToLower()));
            }
            else
            {
                this.personListView.ItemsSource = BaseViewModel.Person_list;
            }
        }
    }
}
