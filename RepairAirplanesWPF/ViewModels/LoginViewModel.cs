using RepairAirplanesWPF;
using RepairAirplanesWPF.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace RepairAirplanesWPF.ViewModels
{
    public class LoginViewModel : DependencyObject
    {
        private RepairAirplanesConnection dataLoader = new RepairAirplanesConnection();
        static LoginViewModel()
        {
            LoginProperty = DependencyProperty.RegisterAttached("Login", typeof(string), typeof(LoginViewModel), new PropertyMetadata(""));
            PasswordProperty = DependencyProperty.RegisterAttached("Password", typeof(string), typeof(LoginViewModel), new PropertyMetadata(""));
        }
        public bool IsConnected => dataLoader.Database.Connection.State == System.Data.ConnectionState.Open;
        public Person Authorization(string login, string password, Action<Person> completion = null)
        {
            if (IsConnected == false)
            {
                return null;
            }

            var result = this.dataLoader.CustomLogin(login, password);
            if (result.Count() > 0)
            {
                var first = this.dataLoader.CustomLogin(login, password).First();
                AuthorizedClient = this.dataLoader.Person.Find(first.id);
            }
            else
            {
                AuthorizedClient = null;
            }
            completion?.Invoke(AuthorizedClient);
            return AuthorizedClient;
        }
        public Person AuthorizedClient { get; set; } = null;
        public String Login
        {
            get
            {
                return (string)GetValue(LoginProperty);
            }
            set
            {
                SetValue(LoginProperty, value);
            }
        }
        public String Password
        {
            get
            {
                return (string)GetValue(PasswordProperty);
            }
            set
            {
                SetValue(PasswordProperty, value);
            }
        }
        public bool TryOpenConnection()
        {
            try
            {
                dataLoader.Database.Connection.Open();
            }
            catch
            {

            }
            return IsConnected;
        }
        public void LoginClick(object sender)
        {
            TryOpenConnection();
            var client = Authorization(Login, Password, (Authorizedclient) =>
            {
                if (Authorizedclient != null)
                {
                    var mainWindow = new MainWindow();
                    Thread.Sleep(200);
                    mainWindow.Show();
                    closeScreen?.Invoke();
                }
                else
                {
                    if (IsConnected == false)
                    {
                        MessageBox.Show("Проверьте подключение к базе данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                        MessageBox.Show("Неправильный логин или пароль!!!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

        }
        public Action closeScreen;

        public static readonly DependencyProperty LoginProperty;

        public static readonly DependencyProperty PasswordProperty;

    }
}
