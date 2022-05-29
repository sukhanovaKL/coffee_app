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
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public Users User;

        public Profile()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //статьи
        {
            ArticlesProfile articles = new ArticlesProfile();
            articles.idGuidUser = User.idGuid;
            articles.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //выйти
        {
            this.Hide();
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SavedArticles article = new SavedArticles(User.idGuid);
            article.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
