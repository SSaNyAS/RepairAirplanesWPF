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
    /// Логика взаимодействия для ManualListPage.xaml
    /// </summary>
    public partial class ManualListPage : Page
    {
        private BaseViewModel BaseViewModel;
        public ManualListPage(BaseViewModel baseViewModel)
        {
            this.BaseViewModel = baseViewModel;
            InitializeComponent();
            repairWorkButton.Command = baseViewModel.EditRepairWorkList_Open;
            repairWorkButton.CommandParameter = repairWorkButton;

            repairPartButton.Command = baseViewModel.EditRepairPartList_Open;
            repairPartButton.CommandParameter = repairPartButton;

            coolingSystemButton.Command = baseViewModel.EditCoolingSystemList_Open;
            coolingSystemButton.CommandParameter = coolingSystemButton;

            studentGroupButton.Command = baseViewModel.EditStudyGroupList_Open;
            studentGroupButton.CommandParameter = studentGroupButton;
        }
    }
}
