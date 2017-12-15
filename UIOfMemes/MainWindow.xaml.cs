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
        VkAuth _vkAuth = new VkAuth();

        Repository _repository;
        public MainWindow(Repository repository)
        {
            InitializeComponent();
            _repository = repository;
            listViewMemes.ItemsSource = repository.Memes;
            listBoxGroups.ItemsSource = repository.Groups;
            _vkAuth.OnAuthorized += Authorized;
            _vkAuth.CheckAuthorization();
            repository.UsersMemeAdded += m => listViewMemes.Items.Refresh();
            repository.GroupAdded += m => listBoxGroups.Items.Refresh();
        }

        private void Authorized()
        {
            buttonAddGroup.IsEnabled = false;
            buttonAddMeme.IsEnabled = false;
            buttonEditGroup.IsEnabled = false;
        }

        private void listViewMemes_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (listViewMemes.SelectedIndex != -1)
            {
                MemeWindow memeWindow = new MemeWindow(_repository, listViewMemes.SelectedItem as Meme, _vkAuth);
                memeWindow.Show();
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {            
                if (string.IsNullOrWhiteSpace(textBoxSearch.Text)) listViewMemes.ItemsSource = _repository.Memes;
                else listViewMemes.ItemsSource = _repository.Memes.Where(meme => meme.Name.ToUpper().Contains(textBoxSearch.Text.ToUpper()));           
        }

        private void buttonLogOut_Click(object sender, RoutedEventArgs e)
        {
            _vkAuth.ClearToken();
        }

        private void buttonAddUserMeme_Click(object sender, RoutedEventArgs e)
        {
            CreateMemeWindow createMeme = new CreateMemeWindow();
            createMeme.Show();
        }

        private void buttonAddMeme_Click(object sender, RoutedEventArgs e)
        {
            AddMemeWindow addMeme = new AddMemeWindow();
            addMeme.Show();
        }
    }
}
