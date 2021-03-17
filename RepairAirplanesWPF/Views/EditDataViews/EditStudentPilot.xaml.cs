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
    /// Логика взаимодействия для EditStudentPilot.xaml
    /// </summary>
    public partial class EditStudentPilot : Window
    {
        private BaseViewModel BaseViewModel;
        public EditStudentPilot(BaseViewModel baseViewModel)
        {
            this.BaseViewModel = baseViewModel;
            baseViewModel.StudyGroup_listChangedEvent += BaseViewModel_StudyGroup_listChangedEvent;
            InitializeComponent();
            addStudyGroup.Command = baseViewModel.AddStudyGroup_Show;
            addStudyGroup.CommandParameter = addStudyGroup;
        }
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            _ = BaseViewModel.LoadStudyGroupList();
        }
        private void BaseViewModel_StudyGroup_listChangedEvent()
        {
            studyGroupSelector.ItemsSource = null;
            studyGroupSelector.ItemsSource = BaseViewModel.StudyGroup_list;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
