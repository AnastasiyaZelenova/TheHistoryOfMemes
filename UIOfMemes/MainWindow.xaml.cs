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
        VkAuth vkAuth = new VkAuth();

        Repository _repository;
        public MainWindow(Repository repository)
        {
            InitializeComponent();
            _repository = repository;
            listViewMemes.ItemsSource = repository.Memes;
            listBoxGroups.ItemsSource = repository.Groups;
       
            repository.UsersMemeAdded += m => listViewMemes.Items.Refresh();
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
                MemeWindow memeWindow = new MemeWindow(_repository,listViewMemes.SelectedItem as Meme);
                memeWindow.Show();
            }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {            
                if (string.IsNullOrWhiteSpace(textBoxSearch.Text)) listViewMemes.ItemsSource = repository.Memes;
                else listViewMemes.ItemsSource = repository.Memes.Where(meme => meme.Name.ToUpper().Contains(textBoxSearch.Text.ToUpper()));           
        }

        private void buttonLogOut_Click(object sender, RoutedEventArgs e)
        {
            vkAuth.ClearToken();
        }
    }
}
