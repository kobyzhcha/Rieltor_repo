using System;
using System.Collections.Generic;
using System.IO;
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

namespace RieltorApplication
{
    /// <summary>
    /// Interaction logic for DescriptionWindow.xaml
    /// </summary>
    public partial class DescriptionWindow : Window
    {
        MainWindow MW;
        public DescriptionWindow()
        {
            InitializeComponent();
        }

        public DescriptionWindow(Apartment item, MainWindow mw)
        {
            InitializeComponent();


            this.Top = mw.Top + mw.Height / 2 - this.Height / 2;
            this.Left = mw.Left + mw.Width / 2 - this.Width / 2;
            this.MW = mw;

            textName.Text = item.Name;
            textRegion.Text = item.Region.Name;
            textType.Text = item.Type.Name;
            textRooms.Text = "Комнат: " + item.Rooms.ToString();
            textFloor.Text = item.Floor.ToString() + " этаж";
            textPrice.Text = item.Price.ToString() + " $";
            textParking.Text = (item.Parking ? "Есть парковка" : "Нету парковки");
            textImprovment.Text = (item.Improvment ? "С ремонтом" : "Без ремонта");
            textElevator.Text = (item.Elevator ? "Есть лифт" : "Нету лифта");
            textSquare.Text = (item.SquareKitchen != null && item.SquareLiving != null ? "Площадь общая/жилая/кухни: " + item.Square + "/" + item.SquareLiving + "/" + item.SquareKitchen + " м2" : "Площадь общая: " + item.Square + " м2");
            textSubway.Text = (item.SubwayId != null ? "Метро " + item.Subway.Name + " " + item.toSubway + " мин." : "Нету метро");
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}