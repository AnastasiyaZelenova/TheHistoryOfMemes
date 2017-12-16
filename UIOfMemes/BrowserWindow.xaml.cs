using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
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

namespace UIOfMemes
{
    /// <summary>
    /// Логика взаимодействия для BrowserWindow.xaml
    /// </summary>
    public partial class BrowserWindow : Window
    {
        public event Action<Uri> OnRedirected;

        public BrowserWindow()
        {
            InitializeComponent();
        }

        string _redirectPage;

        private void webBrowser_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e.Uri.ToString().StartsWith(_redirectPage))
            {
                OnRedirected?.Invoke(e.Uri);
                Close();
            }
        }

        public void NavigateTo(string page, string redirectPage)
        {
            _redirectPage = redirectPage;
            webBrowser.Navigate(page);
        }
    }
}
