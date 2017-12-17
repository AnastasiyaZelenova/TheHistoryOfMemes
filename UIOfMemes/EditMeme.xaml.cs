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
using Microsoft.Win32;
using System.IO;

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
            textBoxEditDescription.Text = meme.Description;
            textBoxEditName.Text = meme.Name;
            textBoxEditPath.Text = meme.ImagePath;
            textBoxEditYear.Text = meme.Year.ToString();
        }

        private void buttonEditMemeCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
            MainWindow mainWindow = new MainWindow(_repository);
        }

        private void buttonEditMemeOk_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxEditName.Text))
            {
                MessageBox.Show("It is important to insert name.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                textBoxEditName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textBoxEditDescription.Text))
            {
                MessageBox.Show("It is important to insert description.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                textBoxEditDescription.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textBoxEditPath.Text))
            {
                MessageBox.Show("It is important to insert path.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                textBoxEditPath.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textBoxEditYear.Text))
            {
                MessageBox.Show("It is important to insert year.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                textBoxEditYear.Focus();
                return;
            }
            if (textBoxEditYear.Text.Length != 4)
            {
                MessageBox.Show("It is important to insert 4-digit year.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                textBoxEditYear.Focus();
                return;
            }
            try
            {
                _repository.EditMeme(_meme, textBoxEditName.Text, int.Parse(textBoxEditYear.Text), textBoxEditDescription.Text, textBoxEditPath.Text);
                Close();
                MainWindow mainWindow = new MainWindow(_repository);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonAddPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Select image file";
            fileDialog.InitialDirectory = "Memes";
            fileDialog.Filter = "Image (.jpg)|*.jpg";
            fileDialog.FilterIndex = 1;
            Nullable<bool> result = fileDialog.ShowDialog();

            if (result == true)
            {
                textBoxEditPath.Text = "/Memes/" + System.IO.Path.GetFileName(fileDialog.FileName);
                string path = AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.Length - 10);
                string name = System.IO.Path.GetFileName(fileDialog.FileName);
                File.Copy(fileDialog.FileName, path + "\\Memes\\" + name);
                MessageBox.Show("Image was added to the folder with resources. Now you need to add it to the folder inside solution.", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show("You did not select any image file");
            }
        }

        private void textBoxEditPath_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
    }
}
