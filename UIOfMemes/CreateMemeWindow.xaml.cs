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
using System.IO;
using ClassLibraryOfMemes.Model;

namespace UIOfMemes
{
    /// <summary>
    /// Логика взаимодействия для CreateMemeWindow.xaml
    /// </summary>
    public partial class CreateMemeWindow : Window
    {
        Repository repository = new Repository();
        public CreateMemeWindow()
        {
            InitializeComponent();
            mcolor = new ColorRGB
            {
                red = 0,
                green = 0,
                blue = 0
            };
            lbl1.Background = new SolidColorBrush(Color.FromRgb(mcolor.red, mcolor.green, mcolor.blue));
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            inkCanvasPaint.Strokes.Clear();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(memeName.Text))
            {
                MessageBox.Show("It is important to insert name.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                memeName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(memeDescription.Text))
            {
                MessageBox.Show("It is important to insert description.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                memeDescription.Focus();
                return;
            }
            if (string.IsNullOrEmpty(memeYear.Text))
            {
                MessageBox.Show("It is important to insert year.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                memeYear.Focus();
                return;
            }
            try
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "savedimage"; 
                dlg.DefaultExt = ".jpg"; 
                dlg.Filter = "Image (.jpg)|*.jpg"; 
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    string filename = dlg.FileName;
                    int margin = (int)this.inkCanvasPaint.Margin.Left;
                    int width = (int)this.inkCanvasPaint.ActualWidth;
                    int height = (int)this.inkCanvasPaint.ActualHeight;
                    RenderTargetBitmap rtb = new RenderTargetBitmap(width, height, 96d, 96d, PixelFormats.Default);
                    rtb.Render(inkCanvasPaint);
                    using (FileStream fs = new FileStream(filename, FileMode.Create))
                    {
                        BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(rtb));
                        encoder.Save(fs);
                    }
                    UsersMeme meme = new UsersMeme
                    {
                        Name = memeName.Text,
                        Description = memeDescription.Text,
                        Year = int.Parse(memeYear.Text),
                        ImagePath = filename,
                        Likes = 0
                    };
                    repository.AddUsersMeme(meme);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void sldColor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            string crlName = slider.Name; 
            double value = slider.Value; 
            if (crlName.Equals("sldRed"))
            {
                mcolor.red = Convert.ToByte(value);
            }
            if (crlName.Equals("sldGreen"))
            {
                mcolor.green = Convert.ToByte(value);
            }
            if (crlName.Equals("sldBlue"))
            {
                mcolor.blue = Convert.ToByte(value);
            }
            clr = Color.FromRgb(mcolor.red, mcolor.green, mcolor.blue);
            lbl1.Background = new SolidColorBrush(Color.FromRgb(mcolor.red, mcolor.green, mcolor.blue));
            inkCanvasPaint.DefaultDrawingAttributes.Color = clr;
        }
        public ColorRGB mcolor { get; set; }
        public Color clr { get; set; }
    }
}
