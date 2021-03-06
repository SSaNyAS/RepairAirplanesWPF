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

namespace RepairAirplanesWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public LoginViewModel loginViewModel;
        public AuthorizationWindow()
        {
            this.loginViewModel = new LoginViewModel();
            this.DataContext = loginViewModel;
            loginViewModel.closeScreen = () => { this.Close(); };
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            loginViewModel.LoginClick(sender);
        }
    }
}
