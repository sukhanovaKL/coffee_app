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
    /// Логика взаимодействия для OpenArticle.xaml
    /// </summary>
    public partial class OpenArticle : Window
    {
        Coffee_AppEntities coffee = new Coffee_AppEntities();
        public Guid idGuidUser;
        public Guid idGuidArticle;

        public OpenArticle()
        {
            InitializeComponent();

            if (idGuidUser == Guid.Parse("00000000-0000-0000-0000-000000000001"))
                button_save.IsEnabled = false;
            else
                button_save.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            coffee.SavedArticle.Add(new SavedArticle()
            {
                idGuidArticle = idGuidArticle,
                idGuidUser = idGuidUser
            });
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
