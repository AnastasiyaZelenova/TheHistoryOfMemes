using System;
using System.Windows;
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
            if (string.IsNullOrEmpty(textBoxAddName.Text))
            {
                MessageBox.Show("It is important to insert name.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                textBoxAddName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textBoxAddUrl.Text))
            {
                MessageBox.Show("It is important to insert URL.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                textBoxAddUrl.Focus();
                return;
            }
            try
            {
                Group group = new Group
                {
                    Name = textBoxAddName.Text,
                    Url = textBoxAddUrl.Text
                };
                _repository.AddGroup(group);
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonAddGroupCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
