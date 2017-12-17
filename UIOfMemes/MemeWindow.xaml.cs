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
    public delegate void LikesUpdateCallBack(int likesCount);
    /// <summary>
    /// Логика взаимодействия для MemeWindow.xaml
    /// </summary>
    public partial class MemeWindow : Window
    {
        Repository _repository;
        Meme _meme;
        VkAuth _vkAuth;
        public event LikesUpdateCallBack OnLikesChanged;

        public MemeWindow(Repository repository, Meme meme, VkAuth vkAuth)
        {
            _repository = repository;
            _meme = meme;
            _vkAuth = vkAuth;
            InitializeComponent();
            _vkAuth.OnAuthorized += Authorized;
            _vkAuth.CheckAuthorization();
            _repository.OnLikesChanged += UpdateLikes;
            imageMeme.Source = new BitmapImage(new Uri(meme.ImagePath, UriKind.RelativeOrAbsolute));
            textBlockDescription.Text = meme.Description;
            textBlockMemYear.Text = (meme.Year).ToString();
            textBlockLikes.Text = (meme.Likes).ToString();
        }

        private void Authorized()
        {
            buttonLikes.IsEnabled = true;
            buttonDeleteMeme.IsEnabled = false;
            buttonEditMeme.IsEnabled = false;
        }

        public void UpdateLikes(int likes)
        {
            textBlockLikes.Text = $"{likes}";
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
            Close();
        }

        private void buttonLikes_Click(object sender, RoutedEventArgs e)
        {
            _meme.Likes =  _repository.IncreaseLikes(_meme.Likes, _meme );
            IsEnabled = false;
        }
    }
}
