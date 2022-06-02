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
    /// Логика взаимодействия для List_Users.xaml
    /// </summary>
    public partial class List_Users : Window
    {
        Coffee_AppEntities coffee = new Coffee_AppEntities();
        public List_Users()
        {
            InitializeComponent();

            foreach (var i in coffee.Users)
                Items.Items.Add(i.name + " " + i.surname + " Логин: " + i.login);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Items.SelectedItem != null)
            {
                foreach (var i in coffee.Users)
                {
                    string item = i.name + " " + i.surname + " Логин: " + i.login;
                    if (item == Items.SelectedItem.ToString())
                    {
                        coffee.Users.Remove(i);
                    }
                }
                coffee.SaveChanges();

                Items.Items.Clear();

                foreach (var i in coffee.Users)
                    Items.Items.Add(i.name + " " + i.surname + " Логин: " + i.login);
            }
            else
                MessageBox.Show("Элемент не выбран!");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
