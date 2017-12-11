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
            repository.InfoShow();
            ListBoxOfMemes.ItemsSource = repository.Memes;
            //  repository.MemeAdded += m => ListBoxOfMemes.Items.Refresh();
           
        }

        private void buttonAddMeme_Click(object sender, RoutedEventArgs e)
        {
            AddMemeWindow addMemeWindow = new AddMemeWindow();
            addMemeWindow.Show();
        }
       
    }
}
