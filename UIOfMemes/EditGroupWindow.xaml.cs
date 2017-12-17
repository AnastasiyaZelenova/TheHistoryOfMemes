using ClassLibraryOfMemes;
using System;
using System.Windows;

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
            Close();
        }

        private void buttonEditGroupOk_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxEditName.Text))
            {
                MessageBox.Show("It is important to insert name.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                textBoxEditName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textBoxEditUrl.Text))
            {
                MessageBox.Show("It is important to insert URL.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                textBoxEditUrl.Focus();
                return;
            }
            try
            {
                _repository.EditGroup(_group, textBoxEditUrl.Text, textBoxEditName.Text);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
