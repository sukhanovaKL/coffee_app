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
    /// Логика взаимодействия для AddArticle.xaml
    /// </summary>
    public partial class AddArticle : Window
    {
        Coffee_AppEntities coffee = new Coffee_AppEntities();
        
        public AddArticle()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextRange text = new TextRange(richBox.Document.ContentStart, richBox.Document.ContentEnd);
            coffee.Article.Add(new Article()
            {
                idGuid = Guid.NewGuid(),
                name = nameArticle.Text,
                text = text.Text
            }) ;
            coffee.SaveChanges();
        }
    }
}
