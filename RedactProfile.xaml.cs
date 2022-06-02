using System;
using System.Collections.Generic;
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

namespace coffee_app
{
    /// <summary>
    /// Логика взаимодействия для RedactProfile.xaml
    /// </summary>
    public partial class RedactProfile : Window
    {
        Coffee_AppEntities coffee = new Coffee_AppEntities();
        public Users User;
        public RedactProfile()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach(var i in coffee.Users)
            {
                if(User.idGuid == i.idGuid)
                {
                    i.name = name.Text;
                    i.surname = surname.Text;
                    i.login = login.Text;
                    i.pass = password.Text;
                }
            }
            MessageBox.Show("Сохранено!");
            coffee.SaveChanges();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Profile p = new Profile();
            p.UserName.Content = User.name.ToString() + " " + User.surname.ToString();
            p.User = User;
            p.Show();
            Hide();
        }
    }
}
