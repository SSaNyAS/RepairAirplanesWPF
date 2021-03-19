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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BaseViewModel BaseViewmodel;
        public MainWindow()
        {
            InitializeComponent();
            this.BaseViewmodel = (Application.Current as App).baseViewModel;
            this.DataContext = BaseViewmodel;
            BaseViewmodel.WelcomePage_Open.Execute(firstPageButton);
        }
        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            if (e.Content is EngineListPage engineListPage)
            {
                engineListPage.DataContext = this.DataContext;
            }
        }
    }
}
