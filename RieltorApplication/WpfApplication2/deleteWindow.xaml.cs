using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RieltorApplication
{
    /// <summary>
    /// Interaction logic for deleteWindow.xaml
    /// </summary>
    public partial class deleteWindow : Window
    {
        kEntities rieBD;
        MainWindow parent;

        public deleteWindow()
        {
            InitializeComponent();
        }

        public deleteWindow(MainWindow mw)
        {
            InitializeComponent();
            parent = mw;

            this.Top = mw.Top + mw.Height / 2 - this.Height / 2;
            this.Left = mw.Left + mw.Width / 2 - this.Width / 2;

            listBox.SelectionMode = SelectionMode.Extended;

            ListUpdate();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var forDelete = listBox.SelectedItems;
            foreach (string item in forDelete)
            {
                rieBD.Apartments.Remove(rieBD.Apartments.First(a => a.Name == item));
            }
            rieBD.SaveChanges();
            ListUpdate();

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            parent.IsEnabled = true;
        }

        void ListUpdate()
        {
            rieBD = new kEntities();
            List<Apartment> app = rieBD.Apartments.ToList();
            var nameApp = from row in app
                          select row.Name;
            listBox.ItemsSource = nameApp;
        }
    }
}
