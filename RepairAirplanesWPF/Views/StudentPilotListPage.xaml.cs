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
    /// Логика взаимодействия для StudentPilotListPage.xaml
    /// </summary>
    public partial class StudentPilotListPage : Page
    {
        private BaseViewModel BaseViewModel;
        public StudentPilotListPage(BaseViewModel baseViewModel)
        {
            this.BaseViewModel = baseViewModel;
            baseViewModel.StudentPilot_listChangedEvent += BaseViewModel_StudentPilot_listChangedEvent;
            InitializeComponent();
            _ = baseViewModel.LoadStudentPilotList();
            addStudentButton.Command = baseViewModel.AddStudentPilot_Show;
            addStudentButton.CommandParameter = addStudentButton;

            printStudentButton.Command = baseViewModel.PrintStudentPilot;
            printStudentButton.CommandParameter = printStudentButton;
        }
        private void BaseViewModel_StudentPilot_listChangedEvent()
        {
            studentListView.ItemsSource = null;
            searchTextBox_TextChanged(null, null);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            BaseViewModel.EditStudentPilot_Show.Execute(sender);
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            BaseViewModel.RemoveStudentPilot.Execute(sender);
        }
        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = searchTextBox.Text.Trim().ToLower();
            if (text.Length > 0)
            {
                this.studentListView.ItemsSource = BaseViewModel.StudentPilot_list.Where((student) => student.Pilot.Person.FIO.Trim().ToLower().Contains(text) || student.eduation_sertificate.Trim().Contains(text));
            }
            else
            {
                this.studentListView.ItemsSource = BaseViewModel.StudentPilot_list;
            }
        }
    }
}
