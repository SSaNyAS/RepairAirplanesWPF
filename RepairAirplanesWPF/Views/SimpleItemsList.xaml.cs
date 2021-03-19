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

namespace RepairAirplanesWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для SimpleItemsList.xaml
    /// </summary>
    public partial class SimpleItemsList : Window
    {
        private BaseViewModel BaseViewModel;
        public SimpleItemsList(BaseViewModel baseViewModel, object itemsList)
        {
            this.BaseViewModel = baseViewModel;
            baseViewModel.Cooling_system_listChangedEvent += ListChanged;
            baseViewModel.StudyGroup_listChangedEvent += ListChanged;
            baseViewModel.Repair_work_listChangedEvent += ListChanged;
            baseViewModel.Repair_part_listChangedEvent += ListChanged;
            InitializeComponent();
            EditButton.Command = BaseViewModel.EditSimpleItem;
            EditButton.CommandParameter = EditButton;
            RemoveButton.Command = baseViewModel.RemoveSimpleItem;
            RemoveButton.CommandParameter = RemoveButton;
        }

        private void ListChanged()
        {
            elementListView.ItemsSource = null;
            if (this.DataContext is ObservableCollection<Cooling_system>) {
                elementListView.ItemsSource = BaseViewModel.Cooling_system_list;
            }
            if (this.DataContext is ObservableCollection<Study_group>)
            {
                elementListView.ItemsSource = BaseViewModel.StudyGroup_list;
            }
            if (this.DataContext is ObservableCollection<Repair_part>)
            {
                elementListView.ItemsSource = BaseViewModel.Repair_part_list;
            }
            if (this.DataContext is ObservableCollection<Repair_work>)
            {
                elementListView.ItemsSource = BaseViewModel.Repair_work_list;
            }
        }
    }
}
