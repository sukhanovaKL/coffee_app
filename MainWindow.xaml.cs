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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace coffee_app
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //вход
        {
            this.Hide();
            Entry entry = new Entry();
            entry.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //регистрация
        {
            this.Hide();
            Registr reg = new Registr();
            reg.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //this.Hide();
            Articles article = new Articles();
            article.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CoffeeHouses coffee = new CoffeeHouses();
            coffee.Show();
        }
    }
}
