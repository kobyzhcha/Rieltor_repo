using System.Windows;
using System.Windows.Controls;

namespace RieltorApplication
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        MainWindow MW;

        public LoginPage(MainWindow mw)
        {
            InitializeComponent();
            this.MW = mw;
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            MW.Autorization(Login.Text, Password.Password);
            label2.Content = "Неверный логин/пароль!";
            Password.Password = "";
        }
    }
}
