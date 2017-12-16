using ClassLibraryOfMemes;
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

namespace UIOfMemes
{
    /// <summary>
    /// Логика взаимодействия для EditGroupWindow.xaml
    /// </summary>
    public partial class EditGroupWindow : Window     
    {
        Repository _repository;
        Group _group;
        public EditGroupWindow(Group group, Repository repository)
        {

            InitializeComponent();
            _repository = repository;
            _group = group;
            textBoxEditName.Text = group.Name;
            textBoxEditUrl.Text = group.Url;

        }

        private void buttonEditGroupCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(_repository);
        }

        private void buttonEditGroupOk_Click(object sender, RoutedEventArgs e)
        {
            _repository.EditGroup(_group, textBoxEditUrl.Text, textBoxEditName.Text);
            Close();
        }
    }
}
