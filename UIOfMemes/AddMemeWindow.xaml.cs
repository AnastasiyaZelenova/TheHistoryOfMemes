using System;
using System.Collections.Generic;
using System.IO;
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
using ClassLibraryOfMemes;
using ClassLibraryOfMemes.Model;

namespace UIOfMemes
{
    /// <summary>
    /// Логика взаимодействия для AddMemeWindow.xaml
    /// </summary>
    public partial class AddMemeWindow : Window
    {
        Repository _repository = new Repository();

        public AddMemeWindow(Repository repository)
        {
            _repository = repository;
            InitializeComponent();

        }

        private void buttonAddMemeOk_Click(object sender, RoutedEventArgs e)
        {
            Meme meme = new Meme
            {
                Name = textBoxAddName.Text,
                Year = int.Parse(textBoxAddYear.Text),
                Description = textBoxAddDescription.Text,
                ImagePath = textBoxAddPath.Text
            };
            _repository.AddMeme(meme);
            Close();
        }

        private void buttonAddMemeCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(_repository);
            mainWindow.Show();
        }

        


    }
}
