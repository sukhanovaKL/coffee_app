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
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddArticle article = new AddArticle();
            article.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Articles articles = new Articles();
            articles.role.Content = "admin";
            articles.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            List_Users users = new List_Users();
            users.Show();
        }
    }
}
