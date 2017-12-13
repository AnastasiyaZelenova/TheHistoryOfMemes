using ClassLibraryOfMemes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
            //ListBoxOfMemes.ItemsSource = repository.Memes;

            ListBoxOfMemes.ItemsSource = repository.Memes;
            listBoxGroups.ItemsSource = repository.Groups;
            //foreach (var item in repository.Info())
            //{
            //    ListBoxOfMemes.Items.Add(item);
            //}
            //foreach (var meme in repository.Memes)
            //{
            //    repository.InfoShow(meme);
            //    ListBoxOfMemes.Items.Add(meme);
            //}
            
            //  repository.MemeAdded += m => ListBoxOfMemes.Items.Refresh();
        }

        private void buttonAddMeme_Click(object sender, RoutedEventArgs e)
        {
            AddMemeWindow addMemeWindow = new AddMemeWindow();
            addMemeWindow.Show();
        }
    }
}
