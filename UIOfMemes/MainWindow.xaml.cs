using ClassLibraryOfMemes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.IO;

namespace UIOfMemes
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repository repository;
        VkAuth vkAuth = new VkAuth();

        public MainWindow(Repository repository)
        {
            InitializeComponent();
            this.repository = repository;

            listViewMemes.ItemsSource = repository.Info();
            listBoxGroups.ItemsSource = repository.Groups;
       
            repository.MemeAdded += m => listViewMemes.Items.Refresh();
            repository.GroupAdded += m => listBoxGroups.Items.Refresh();
        }

        private void buttonAddMeme_Click(object sender, RoutedEventArgs e)
        {
            AddMemeWindow addMemeWindow = new AddMemeWindow();
            addMemeWindow.Show();
        }

        private void buttonLogOut_Click(object sender, RoutedEventArgs e)
        {
            vkAuth.ClearToken();
        }
    }
}
