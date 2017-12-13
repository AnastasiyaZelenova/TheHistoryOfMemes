using ClassLibraryOfMemes;
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
using System.Windows.Threading;

namespace UIOfMemes
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        DispatcherTimer dtClockTime = new DispatcherTimer();
        Repository repository = new Repository();
        public StartWindow()
        {
            InitializeComponent();
            dtClockTime.Interval = new TimeSpan(0, 0, 4); 
            dtClockTime.Tick += new EventHandler(windowClosed);
            dtClockTime.Start();
        }
        private void windowClosed(object sender, EventArgs e)
        {
            //Application.Current.MainWindow.Hide();
            //MainWindow mainWindow = new MainWindow(repository);
            //mainWindow.Show();
            PasswordWindow passwordWindow = new PasswordWindow();
            try
            {
                passwordWindow.Show();
            }
            catch (Exception)
            {
                Close();
            }
            dtClockTime.Stop();
        }
    }
}
