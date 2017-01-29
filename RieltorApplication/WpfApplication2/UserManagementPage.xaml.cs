using System.Windows;
using System.Windows.Controls;

namespace RieltorApplication
{
    /// <summary>
    /// Interaction logic for UserManagementPage.xaml
    /// </summary>
    public partial class UserManagementPage : Page
    {
        MainWindow parent;
        Users uW;

        public UserManagementPage()
        {
            InitializeComponent();
        }

        public UserManagementPage(MainWindow mw, Users usr)
        {
            InitializeComponent();

            parent = mw;
            uW = usr;
            
            listBox.ItemsSource = parent.GetUsersNames();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            uW.Content = new UserRegistrationPage(parent, uW);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                parent.DeleteUser(listBox.SelectedItem.ToString());
                listBox.ItemsSource = parent.GetUsersNames();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            uW.Close();
            parent.IsEnabled = true;
        }
    }
}
