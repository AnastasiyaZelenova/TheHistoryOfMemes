using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using ClassLibraryOfMemes;

namespace UIOfMemes
{
    /// <summary>
    /// Логика взаимодействия для PasswordWindow.xaml
    /// </summary>
    public partial class PasswordWindow : Window
    {
        Repository _repository = new Repository();
        VkAuth _vkAuth = new VkAuth();

        private void Authorize()
        {
            var browserWindow = new BrowserWindow();
            browserWindow.OnRedirected += _vkAuth.AuthorizationRedirect;
            browserWindow.Show();
            browserWindow.NavigateTo(_vkAuth.GetAuthUrl(), _vkAuth.RedirectPage);
        }

        public PasswordWindow()
        {
            InitializeComponent();
            _vkAuth.OnAuthorized += Authorized;
            _vkAuth.CheckAuthorization();
        }

        private void Authorized()
        {
            MainWindow _mainWindow = new MainWindow(_repository);
            _mainWindow.Show();
            Close();
        }

        private string CalculateHash(string password)
        {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Convert.ToBase64String(hash);
        }

        private void Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                buttonPassword_Click(null, null);
        }

        private void buttonPassword_Click(object sender, RoutedEventArgs e)
        {
            var hash = CalculateHash("imcoolgirl");

            if (textBoxLogin.Text == "zeNOfa" && CalculateHash(passwordBox.Password) == hash)
            {
                MainWindow mainWindow = new MainWindow(_repository);
                mainWindow.Show();
                Close();
            }
            else
                MessageBox.Show("Incorrect username or password entered. Please try again.", "Error");
        }

        bool _loginEntered = false;
        private void textBoxLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!_loginEntered)
            {
                textBoxLogin.Text = "";
                textBoxLogin.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void textBoxLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxLogin.Text))
                _loginEntered = true;
            else
            {
                textBoxLogin.Text = "Enter your username";
                _loginEntered = false;
                textBoxLogin.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void buttonVk_Click(object sender, RoutedEventArgs e)
        {
            Authorize();
        }

        private void buttonPasswordCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you really want to close the app?", "Close the app?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                Application.Current.Shutdown();
            if (result == MessageBoxResult.No)
                return;
        }
    }
}
