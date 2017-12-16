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
using ClassLibraryOfMemes;

namespace UIOfMemes
{
    /// <summary>
    /// Логика взаимодействия для EditMeme.xaml
    /// </summary>
    public partial class EditMeme : Window
    {
        Repository _repository;
        Meme _meme;

        public EditMeme(Repository repository, Meme meme)
        {
            _repository = repository;
            _meme = meme;
            InitializeComponent();

        }

        private void buttonEditMemeCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
            MainWindow mainWindow = new MainWindow(_repository);
        }

        private void buttonEditMemeOk_Click(object sender, RoutedEventArgs e)
        {
            _meme = new Meme
            {
                Name = textBoxEditName.Text,
                Description = textBoxEditDescription.Text,
                Year = int.Parse(textBoxEditYear.Text),
                ImagePath = textBoxEditPath.Text
            };
            _repository.AddMeme(_meme);
            Close();
            MainWindow mainWindow = new MainWindow(_repository);
        }
    }
}
