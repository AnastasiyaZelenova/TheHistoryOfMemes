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
using System.Drawing;

namespace UIOfMemes
{
    /// <summary>
    /// Логика взаимодействия для MemeWindow.xaml
    /// </summary>
    public partial class MemeWindow : Window
    {
        Repository _repository;
        Meme _meme;
        VkAuth _vkAuth;
        public MemeWindow(Repository repository, Meme meme, VkAuth vkAuth)
        {
            _repository = repository;
            _meme = meme;
            _vkAuth = vkAuth;
            InitializeComponent();
            _vkAuth.OnAuthorized += Authorized;
            _vkAuth.CheckAuthorization();
            imageMeme.Source = new BitmapImage(new Uri(meme.ImagePath, UriKind.RelativeOrAbsolute));
            textBlockDescription.Text = meme.Description;
            textBlockMemYear.Text = (meme.Year).ToString();
            textBlockLikes.Text = (meme.Likes).ToString();
        }

        private void Authorized()
        {
            buttonDeleteMeme.IsEnabled = false;
            buttonEditMeme.IsEnabled = false;
        }

        private void buttonDeleteMeme_Click(object sender, RoutedEventArgs e)
        {
            
            _repository.DeleteMeme(_meme);
            
            Close();
        }

        private void buttonEditMeme_Click(object sender, RoutedEventArgs e)
        {
            EditMeme editMeme = new EditMeme(_repository, _meme);
            editMeme.Show();
        }

        private void buttonLikes_Click(object sender, RoutedEventArgs e)
        {
             _repository.Likes(int.Parse(textBlockLikes.Text));
        }
    }
}
