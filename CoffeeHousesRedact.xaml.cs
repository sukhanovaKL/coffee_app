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
    /// Логика взаимодействия для CoffeeHousesRedact.xaml
    /// </summary>
    public partial class CoffeeHousesRedact : Window
    {
        Coffee_AppEntities coffee = new Coffee_AppEntities();
        CoffeeHouse CoffeeHouse;
        public CoffeeHousesRedact()
        {
            InitializeComponent();

            foreach (var i in coffee.CoffeeHouse)
                name.Items.Add(i.name);

            but_save.Visibility = Visibility.Hidden;
            but_delete.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (name.SelectedItem != null)
            {
                foreach (var i in coffee.CoffeeHouse)
                {
                    if (name.SelectedItem.ToString() == i.name)
                    {
                        text.Document.Blocks.Clear();
                        nameC.Document.Blocks.Clear();
                        adres.Document.Blocks.Clear();

                        text.AppendText(i.description);
                        nameC.AppendText(i.name);
                        adres.AppendText(i.address);

                        CoffeeHouse = i;
                    }
                }
                but_save.Visibility = Visibility.Visible;
                but_delete.Visibility = Visibility.Visible;
            }
            else
                MessageBox.Show("Элемент не выбран!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void but_save_Click_1(object sender, RoutedEventArgs e)
        {
            if (name.SelectedItem != null)
            {
                string description = new TextRange(text.Document.ContentStart, text.Document.ContentEnd).Text;
                string adresText = new TextRange(adres.Document.ContentStart, adres.Document.ContentEnd).Text;
                string nameText = new TextRange(nameC.Document.ContentStart, nameC.Document.ContentEnd).Text;

                Functions f = new Functions();
                f.RegCoffeeHouse(CoffeeHouse.idGuid, nameText, description, adresText);

                foreach (var i in coffee.CoffeeHouse)
                {
                    if (i.name == name.SelectedItem.ToString())
                    {
                        i.name = nameText;
                        i.description = description;
                        i.address = adresText;
                    }
                }

                but_save.Visibility = Visibility.Hidden;
                but_delete.Visibility = Visibility.Hidden;
                text.Document.Blocks.Clear();
                adres.Document.Blocks.Clear();
                nameC.Document.Blocks.Clear();

                coffee.SaveChanges();
                name.Items.Clear();
                foreach (var i in coffee.CoffeeHouse)
                    name.Items.Add(i.name);
            }
            else
                MessageBox.Show("Элемент не выбран!");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (name.SelectedItem != null)
            {
                foreach (var i in coffee.CoffeeHouse)
                {
                    if (name.SelectedItem.ToString() == i.name)
                    {
                        CoffeeHouse = i;
                    }
                }
                Functions f = new Functions();
                f.DeleteCoffeeHouse(CoffeeHouse);

                but_save.Visibility = Visibility.Hidden;
                but_delete.Visibility = Visibility.Hidden;
                text.Document.Blocks.Clear();
                adres.Document.Blocks.Clear();
                nameC.Document.Blocks.Clear();

                name.Items.Clear();
                foreach (var i in coffee.CoffeeHouse)
                    name.Items.Add(i.name);
            }
            else
                MessageBox.Show("Элемент не выбран!");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AddCoffeeHouse addCoffeeHouse = new AddCoffeeHouse();
            addCoffeeHouse.Show();
            Hide();
        }
    }
}
