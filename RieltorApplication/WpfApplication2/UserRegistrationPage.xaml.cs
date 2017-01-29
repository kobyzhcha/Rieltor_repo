using System.Windows;
using System.Windows.Controls;

namespace RieltorApplication
{
    /// <summary>
    /// Interaction logic for UserRegistrationPage.xaml
    /// </summary>
    public partial class UserRegistrationPage : Page
    {
        MainWindow parent;
        Users uw;
        public UserRegistrationPage()
        {
            InitializeComponent();
        }

        public UserRegistrationPage(MainWindow mw, Users usr)
        {
            InitializeComponent();

            parent = mw;
            uw = usr;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            uw.Return();
        }
        
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != "" && Login.Text != "" && Password.Text != "")
            {
                User usr = new User
                {
                    Admin = (bool)isAdmin.IsChecked,
                    Name = Name.Text,
                    Login = Login.Text,
                    Password = Password.Text
                };
                parent.AddUser(usr);
                uw.Return();
            }
        }
    }
}
