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
            string nameText = new TextRange(name.Document.ContentStart, name.Document.ContentEnd).Text;
            string articleText = new TextRange(text.Document.ContentStart, text.Document.ContentEnd).Text;
            Functions f = new Functions();
            f.EditArticle(idGuidArticle, nameText, articleText);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
