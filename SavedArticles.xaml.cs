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
    /// Логика взаимодействия для SavedArticles.xaml
    /// </summary>
    public partial class SavedArticles : Window
    {
        Coffee_AppEntities coffee = new Coffee_AppEntities();
        public Guid idGuidUser;
        public Guid idGuidArticle;
        public SavedArticles()
        {
            InitializeComponent();

            List<Guid> savedA = new List<Guid>();
            foreach (var u in coffee.SavedArticle)
            {
                if (idGuidUser == u.idGuidUser)
                    savedA.Add((Guid)u.idGuidArticle);
            }

            foreach (var a in coffee.Article)
            {
                foreach(var sa in savedA)
                {
                    if (a.idGuid == sa)
                        name_a.Items.Add(a.name);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var i in coffee.Article)
            {
                if (i.name == name_a.SelectedItem.ToString())
                {
                    text.AppendText(i.text);
                }
            }
        }
    }
}
