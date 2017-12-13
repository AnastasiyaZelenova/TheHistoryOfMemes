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
        Repository repository = new Repository();
        public AddMemeWindow()
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
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "savedimage"; // Default file name
            dlg.DefaultExt = ".jpg"; // Default file extension
            dlg.Filter = "Image (.jpg)|*.jpg"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
                //get the dimensions of the ink control
                int margin = (int)this.inkCanvasPaint.Margin.Left;
                int width = (int)this.inkCanvasPaint.ActualWidth;
                int height = (int)this.inkCanvasPaint.ActualHeight;
                //render ink to bitmap
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
            }
            }

        private void sldColor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            string crlName = slider.Name; //Определяем имя контрола, который покрутили
            double value = slider.Value; // Получаем значение контрола
                                         //В зависимости от выбранного контрола, меняем ту или иную компоненту и переводим ее в тип byte
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
            //Задаем значение переменной класса clr 
            clr = Color.FromRgb(mcolor.red, mcolor.green, mcolor.blue);
            //Устанавливаем фон для контрола Label 
            lbl1.Background = new SolidColorBrush(Color.FromRgb(mcolor.red, mcolor.green, mcolor.blue));
            // Задаем цвет кисти для контрола InkCanvas
            inkCanvasPaint.DefaultDrawingAttributes.Color = clr;
        }
        public ColorRGB mcolor { get; set; }
        public Color clr { get; set; }

  
    }
}
