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
using Microsoft.Win32;
using System.Resources;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

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
            if (string.IsNullOrEmpty(textBoxAddName.Text))
            {
                MessageBox.Show("It is important to insert name.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                textBoxAddName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textBoxAddDescription.Text))
            {
                MessageBox.Show("It is important to insert description.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                textBoxAddDescription.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textBoxAddPath.Text))
            {
                MessageBox.Show("It is important to insert path.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                textBoxAddPath.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textBoxAddYear.Text))
            {
                MessageBox.Show("It is important to insert year.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                textBoxAddYear.Focus();
                return;
            }
            if (textBoxAddYear.Text.Length != 4)
            {
                MessageBox.Show("It is important to insert 4-digit year.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                textBoxAddYear.Focus();
                return;
            }
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonAddMemeCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
                textBoxAddPath.Text = "/Memes/" + System.IO.Path.GetFileName(fileDialog.FileName);
                string path = AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.Length - 10);
                string name = Path.GetFileName(fileDialog.FileName);
                string[] allFoundFiles = Directory.GetFiles("/Memes/", name, SearchOption.AllDirectories);
                foreach (var item in allFoundFiles)
                {
                    if ("/Memes/name" != item)
                    {
                        File.Copy(fileDialog.FileName, path + "\\Memes\\" + name);
                        MessageBox.Show("Image was added to the folder with resources. Now you need to add it to the folder inside solution.", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        MessageBox.Show("File with the same name already exists.", "Change name.", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                

            }
            else
            {
                MessageBox.Show("You did not select any image file");
            }
        }

        private void textBoxAddPath_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
    }
}
