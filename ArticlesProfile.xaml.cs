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
    /// Логика взаимодействия для ArticlesProfile.xaml
    /// </summary>
    public partial class ArticlesProfile : Window
    {
        Coffee_AppEntities coffee = new Coffee_AppEntities();
        public Guid idGuidUser;

        public ArticlesProfile()
        {
            InitializeComponent();

            foreach (var i in coffee.Article)
                Items1.Items.Add(i.name);

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenArticle openArticle = new OpenArticle();
            if (Items1.SelectedItem == null)
            {
                MessageBox.Show("Элемент не выбран!");
            }
            else
            {
                foreach (var i in coffee.Article)
                {
                    if (i.name == Items1.SelectedItem.ToString())
                    {
                        openArticle.name.AppendText(i.name);
                        openArticle.text.AppendText(i.text);
                        openArticle.idGuidArticle = i.idGuid;
                        openArticle.idGuidUser = idGuidUser;
                        openArticle.role.Content = "user";
                        openArticle.button_save.Visibility = Visibility.Visible;
                    }
                }
                openArticle.Show();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Functions f = new Functions();
            if (Items1.SelectedItem != null)
            {
                foreach (var i in coffee.Article)
                {
                    if (i.name == Items1.SelectedItem.ToString())
                    {
                        f.SaveArticle(idGuidUser, i.idGuid);
                    }
                }
            }
            else
                MessageBox.Show("Элемент не выбран!");
        }
    }
}
