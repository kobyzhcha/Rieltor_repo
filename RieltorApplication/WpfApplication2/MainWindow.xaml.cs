using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RieltorApplication
{
    public partial class MainWindow : Window
    {
        kEntities rieBd = new kEntities();
        public User Current { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

            MinHeight = 500;
            MinWidth = 950;

            this.Content = new LoginPage(this);         
        }
        
        //public List<Apartment> 

        public List<string>[] FillCombobox() 
        {
            List<Subway> sub = rieBd.Subways.ToList<Subway>();
            List<Region> reg = rieBd.Regions.ToList<Region>();
            List<Type> type = rieBd.Types.ToList<Type>();

            List<string> subName = new List<string>();
            
            foreach (var item in sub)
            {
                subName.Add(item.Name);
            }

            List<string> regName = new List<string>();
            
            foreach (var item in reg)
            {
                regName.Add(item.Name);
            }

            List<string> typeName = new List<string>();
            
            foreach (var item in type)
            {
                typeName.Add(item.Name);
            }
            
            return new List<string>[] { subName, regName, typeName };
        }

        public List<Apartment> GetApartments()
        {
            return rieBd.Apartments.ToList<Apartment>();
        }

        public void AddApartment(Apartment ap)
        {
            rieBd.Apartments.Add(ap);
            rieBd.SaveChanges();
        }
        public void RemoveApartment(string name)
        {
            rieBd.Apartments.Remove(rieBd.Apartments.First(a => a.Name == name));
            rieBd.SaveChanges();
        }

        
        public IEnumerable<string> GetUsersNames()
        {
            List<User> user = rieBd.Users.ToList();
            var nameUser = from row in user
                           select row.Name;
            return nameUser;
        }

        public void AddUser(User usr)
        {
            rieBd.Users.Add(usr);
            rieBd.SaveChanges();
        }

        public void DeleteUser(string name)
        {
            rieBd.Users.Remove(rieBd.Users.First(a => a.Name == name));
            rieBd.SaveChanges();
        }
        public void Autorization(string name, string psw)
        {
            User anyone = null;
            if ((anyone = rieBd.Users.ToList<User>().FirstOrDefault(a => a.Login == name && a.Password == psw))!=null)
            {
                Current = anyone;
                this.Content = new MainPage(this, anyone.Admin);
            }
        }

        public void Logout()
        {
            this.Content = new LoginPage(this);
        }
    }
}
