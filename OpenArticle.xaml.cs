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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Functions f = new Functions();
            if (role.Content.ToString() == "admin")
            {
                string nameText = new TextRange(name.Document.ContentStart, name.Document.ContentEnd).Text;
                string articleText = new TextRange(text.Document.ContentStart, text.Document.ContentEnd).Text;
                f.EditArticle(idGuidArticle, nameText, articleText);
            }
            if(role.Content.ToString() == "user")
            {
                f.SaveArticle(idGuidUser, idGuidArticle);
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Articles articles = new Articles();
            if (role.Content != null)
            {
                if (role.Content.ToString() == "admin")
                {
                    articles.role.Content = "admin";
                    articles.Show();
                    Hide();
                }
                if (role.Content.ToString() == "user")
                {
                    Hide();
                }
            }
            else
            {
                articles.Show();
                Hide();
            }
        }
    }
}
