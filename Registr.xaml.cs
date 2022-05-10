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
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        public Registr()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Functions functions = new Functions();
            if(log.Text == "" || pass.Text == "" || name.Text == "" || surname.Text == "")
            {
                MessageBox.Show("Введите данные!");
            }
            else
            {
                functions.Reg(log.Text, pass.Text, name.Text, surname.Text);
                this.Hide();
                Entry entry = new Entry();
                entry.Show();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Hide();
        }
    }
}
