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
using System.Windows.Shapes;

namespace RepairAirplanesWPF.Views.EditDataViews
{
    /// <summary>
    /// Логика взаимодействия для EditPerson.xaml
    /// </summary>
    public partial class EditPerson : Window
    {
        private BaseViewModel BaseViewModel;
        public EditPerson(BaseViewModel baseViewModel)
        {
            this.BaseViewModel = baseViewModel;
            InitializeComponent();
            BaseViewModel.Permission_group_listChangedEvent += BaseViewModel_Permission_group_listChangedEvent;
        }
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            _ = BaseViewModel.LoadPermissionGroupList();
        }
        private void BaseViewModel_Permission_group_listChangedEvent()
        {
            this.permissionGroupSelector.ItemsSource = null;
            this.permissionGroupSelector.ItemsSource = BaseViewModel.Permission_group_list;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
