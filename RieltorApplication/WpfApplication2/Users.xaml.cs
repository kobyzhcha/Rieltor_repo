using System.Windows;

namespace RieltorApplication
{
    /// <summary>
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class Users : Window
    {
       
        MainWindow parent;

        public Users()
        {
            InitializeComponent();
        }

        public Users(MainWindow mw)
        {
            InitializeComponent();
            parent = mw;
            parent.IsEnabled = false;

            this.Top = mw.Top + mw.Height / 2 - this.Height / 2;
            this.Left = mw.Left + mw.Width / 2 - this.Width / 2;

            this.Content = new UserManagementPage(parent, this);
        }

        public void Return()
        {
            this.Content = new UserManagementPage(parent, this);
        }

    }
}
