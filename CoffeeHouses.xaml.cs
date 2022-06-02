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
    /// Логика взаимодействия для CoffeeHouses.xaml
    /// </summary>
    public partial class CoffeeHouses : Window
    {
        Coffee_AppEntities coffee = new Coffee_AppEntities();
        public CoffeeHouses()
        {
            InitializeComponent();

            foreach (var i in coffee.CoffeeHouse)
                name.Items.Add(i.name);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (name.SelectedItem != null)
            {
                foreach (var i in coffee.CoffeeHouse)
                {
                    if (name.SelectedItem.ToString() == i.name)
                    {
                        text.Document.Blocks.Clear();
                        text.AppendText(i.description + "\n" + "Адрес:\n" + i.address);
                    }
                }
            }
            else
                MessageBox.Show("Элемент не выбран!");
        }
    }
}
