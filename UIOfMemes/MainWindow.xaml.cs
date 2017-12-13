using ClassLibraryOfMemes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
        public MainWindow(Repository repository)
        {
           
            InitializeComponent();
            this.repository = repository;
            listViewMemes.ItemsSource = repository.Memes;
            listBoxGroups.ItemsSource = repository.Groups;
       
            repository.MemeAdded += m => listViewMemes.Items.Refresh();
            repository.GroupAdded += m => listBoxGroups.Items.Refresh();
        }

        private void buttonAddMeme_Click(object sender, RoutedEventArgs e)
        {
            AddMemeWindow addMemeWindow = new AddMemeWindow();
            addMemeWindow.Show();
        }

        private void listViewMemes_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(listViewMemes.SelectedIndex != -1)
            {
                MemeWindow memeWindow = new MemeWindow(repository,listViewMemes.SelectedItem as Meme);
                memeWindow.Show();
            }
        }
    }
}
