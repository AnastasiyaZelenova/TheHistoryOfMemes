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
            
            listViewGroups.ItemsSource = repository.Groups;
            
            _vkAuth.OnAuthorized += Authorized;
            _vkAuth.CheckAuthorization();
            WriteUserName();
            repository.UsersMemesChanged += m => listViewMemes.Items.Refresh();
            repository.MemesChanged +=m=> listViewMemes.Items.Refresh();
            repository.GroupsChanged += m => listViewGroups.Items.Refresh();
        }

        private async void WriteUserName()
        {
            if (await _vkAuth.GetUserName() == null)
            {
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
                //MessageBox.Show("Login to your account again.", "Do not panic", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            textBlockUserName.Text = await _vkAuth.GetUserName();
        }

        private void Authorized()
        {
            buttonAddGroup.IsEnabled = false;
            buttonAddMeme.IsEnabled = false;
            menuItemDeleteGroup.IsEnabled = false;
            menuItemEditGroup.IsEnabled = false;
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
            _vkAuth.ClearCookies();
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void buttonAddUserMeme_Click(object sender, RoutedEventArgs e)
        {
            CreateMemeWindow createMeme = new CreateMemeWindow();
            createMeme.Show();
        }

        private void buttonAddMeme_Click(object sender, RoutedEventArgs e)
        {
            AddMemeWindow addMeme = new AddMemeWindow(_repository);
            addMeme.Show();
        }

        private void menuItemDeleteGroup_Click(object sender, RoutedEventArgs e)
        {
            _repository.DeleteGroup(listViewGroups.SelectedItem as Group);
        }

        private void menuItemEditGroup_Click(object sender, RoutedEventArgs e)
        {
            EditGroupWindow editGroup = new EditGroupWindow(listViewGroups.SelectedItem as Group, _repository);
            editGroup.Show();
        }
    
        private void listViewGroups_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Group selectedGroup = listViewGroups.SelectedItem as Group;
            System.Diagnostics.Process.Start(selectedGroup.Url); 
        }

        private void buttonAddGroup_Click(object sender, RoutedEventArgs e)
        {
            AddGroupWindow addGroup = new AddGroupWindow(_repository);
            addGroup.Show();
        }

        private void buttonRefresh_Click(object sender, RoutedEventArgs e)
        {
            listViewGroups.ItemsSource = _repository.Groups;
            listViewMemes.ItemsSource = _repository.Memes;
            listViewGroups.Items.Refresh();
            listViewMemes.Items.Refresh();
        }
    }
}
