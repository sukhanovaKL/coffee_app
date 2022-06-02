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
    /// Логика взаимодействия для AddCoffeeHouse.xaml
    /// </summary>
    public partial class AddCoffeeHouse : Window
    {
        public AddCoffeeHouse()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CoffeeHousesRedact coffeeHousesRedact = new CoffeeHousesRedact();
            coffeeHousesRedact.Show();
            Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string description = new TextRange(text.Document.ContentStart, text.Document.ContentEnd).Text;
            string adresText = new TextRange(adres.Document.ContentStart, adres.Document.ContentEnd).Text;
            string nameText = new TextRange(nameC.Document.ContentStart, nameC.Document.ContentEnd).Text;
            Functions f = new Functions();
            f.AddCoffeeHouse(nameText, description, adresText);
            CoffeeHousesRedact coffeeHousesRedact = new CoffeeHousesRedact();
            coffeeHousesRedact.Show();
            Hide();
        }
    }
}
