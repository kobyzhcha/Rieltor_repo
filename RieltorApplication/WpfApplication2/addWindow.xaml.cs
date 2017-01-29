using System;
using System.Collections.Generic;
using System.Windows;

namespace RieltorApplication
{
    /// <summary>
    /// Interaction logic for addWindow.xaml
    /// </summary>
    public partial class addWindow : Window
    {
        MainWindow parent;
        MainPage MP;
        public addWindow()
        {
            InitializeComponent();
        }

        public addWindow(MainWindow mw, MainPage mp)
        {
            InitializeComponent();
            parent = mw;
            MP = mp;
            parent.IsEnabled = false;

            this.Top = mw.Top + mw.Height / 2 - this.Height / 2;
            this.Left = mw.Left + mw.Width / 2 - this.Width / 2;



            List<string>[] FillCombobox = parent.FillCombobox();

            comboSubway.ItemsSource = FillCombobox[0];
            comboRegion.ItemsSource = FillCombobox[1];
            comboType.ItemsSource = FillCombobox[2];

        }
        
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            parent.IsEnabled = true;
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            Apartment nApp = new Apartment()
            {
                SubwayId = comboSubway.SelectedIndex + 1,
                RegionId = comboRegion.SelectedIndex + 1,
                TypeId = comboType.SelectedIndex + 1,
                Name = flatName.Text,
                Price = Convert.ToInt32(flatPrice.Text),
                Rooms = Convert.ToInt16(flatRooms.Text),
                Floor = Convert.ToInt16(flatFloor.Text),
                Square = Convert.ToInt16(flatSquare.Text),
                SquareLiving = Convert.ToInt16(flatSquareLiving.Text),
                SquareKitchen = Convert.ToInt16(flatSquareKitchen.Text),
                toSubway = Convert.ToInt16(flatToSubway.Text),
                Improvment = (bool)flatImprovment.IsChecked,
                Parking = (bool)flatParking.IsChecked,
                Elevator = (bool)flatElevator.IsChecked
        };
            parent.AddApartment(nApp);
            parent.IsEnabled = true;
            MP.ShowList();
            this.Close();
        }
    }
}
