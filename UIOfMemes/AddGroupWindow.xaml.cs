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
    /// Логика взаимодействия для AddGroupWindow.xaml
    /// </summary>
    public partial class AddGroupWindow : Window
    {
        Repository _repository;

        public AddGroupWindow(Repository repository)
        {
            _repository = repository;
            InitializeComponent();
        }

        private void buttonAddGroupOk_Click(object sender, RoutedEventArgs e)
        {
            Group group = new Group
            {
                Name = textBoxAddName.Text,
                Url = textBoxAddUrl.Text
            };
            _repository.AddGroup(group);
            Close();
        }

        private void buttonAddGroupCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(_repository);
        }
    }
}
