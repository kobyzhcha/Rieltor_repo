using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RieltorApplication
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        MainWindow MW;
        List<Apartment> ApList;
        public MainPage()
        {
            InitializeComponent();
        }

        public MainPage(MainWindow mw, bool isAdmin)
        {
            InitializeComponent();
            this.MW = mw;
            
            List<string>[] FillCombobox = MW.FillCombobox();
            FillCombobox[0].Insert(0, "Любое метро");
            FillCombobox[1].Insert(0, "Любой район");
            FillCombobox[2].Insert(0, "Любой тип");
            Subway.ItemsSource = FillCombobox[0];
            Region.ItemsSource = FillCombobox[1];
            Type.ItemsSource = FillCombobox[2];
            Subway.SelectedIndex = 0;
            Region.SelectedIndex = 0;
            Type.SelectedIndex = 0;

            if(!isAdmin)
                User.Children.Remove(newUser);
            labelName.Content = MW.Current.Name;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MW.Logout();
        }

        private void newUser_Click(object sender, RoutedEventArgs e)
        {
            Users usr = new Users(MW);
            usr.Show();
        }

        private void deleteFlat_Click(object sender, RoutedEventArgs e)
        {
            if (ApartmentList.SelectedIndex != -1)
            {
                MW.RemoveApartment(ApartmentList.SelectedItem.ToString());
                ShowList();
            }
        }

        private void addFlat_Click(object sender, RoutedEventArgs e)
        {
            addWindow AW = new addWindow(MW, this);
            AW.Show();
        }

        private void showResults_Click(object sender, RoutedEventArgs e)
        {
            ShowList();
        }

        public void ShowList()
        {
            ApList = MW.GetApartments();
            var Source = from row in ApList
                         where
                         (Region.SelectedIndex != 0 ? row.RegionId == Region.SelectedIndex : true) &&
                         (Type.SelectedIndex != 0 ? row.TypeId == Type.SelectedIndex : true) &&
                         (Subway.SelectedIndex != 0 ? row.SubwayId == Subway.SelectedIndex : true) &&
                         (numRooms.Text != "" ? row.Rooms == Convert.ToInt32(numRooms.Text) : true) &&
                         (maxPrice.Text != "" ? row.Price <= Convert.ToInt32(maxPrice.Text) : true) &&
                         (minPrice.Text != "" ? row.Price >= Convert.ToInt32(minPrice.Text) : true)
                         select row.Name;

            ApartmentList.ItemsSource = Source;
        }

        private void ApartmentList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (ApartmentList.SelectedIndex != -1)
            {
                DescriptionWindow dw = new DescriptionWindow(ApList[ApartmentList.SelectedIndex], MW);
                dw.Show();
            }
        }
    }
}
