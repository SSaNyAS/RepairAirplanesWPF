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
    /// Логика взаимодействия для InstructorListPage.xaml
    /// </summary>
    public partial class InstructorListPage : Page
    {
        private BaseViewModel BaseViewModel;
        public InstructorListPage(BaseViewModel baseViewModel)
        {
            this.BaseViewModel = baseViewModel;
            baseViewModel.Instructor_listChangedEvent += BaseViewModel_Instructor_listChangedEvent;
            InitializeComponent();
            addInstructorButton.Command = baseViewModel.AddInstuctor_Show;
            addInstructorButton.CommandParameter = addInstructorButton;
        }

        private void BaseViewModel_Instructor_listChangedEvent()
        {
            instructorListView.ItemsSource = null;
            instructorListView.ItemsSource = BaseViewModel.Instructor_list;
        }

        private void StackPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            BaseViewModel.EditInstructor_Show.Execute(sender);
        }
    }
}
