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
    /// Логика взаимодействия для Articles.xaml
    /// </summary>
    public partial class Articles : Window
    {
        Coffee_AppEntities coffee = new Coffee_AppEntities();
        public Articles()
        {
            InitializeComponent();

            foreach (var i in coffee.Article)
                Items.Items.Add(i.name);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this.Hide();
            OpenArticle openArticle = new OpenArticle();
            if(Items.SelectedItem == null)
            {
                MessageBox.Show("Элемент не выбран!");
            }
            else
            {
                foreach (var i in coffee.Article)
                {
                    if (i.name == Items.SelectedItem.ToString())
                    {
                        openArticle.name.AppendText(i.name);
                        openArticle.text.AppendText(i.text);
                        openArticle.idGuidArticle = i.idGuid;
                        if(role.Content != null)
                        {
                            if (role.Content.ToString() != "admin")
                                openArticle.button_save.Visibility = Visibility.Hidden;
                            else
                                openArticle.role.Content = "admin";
                        }
                    }
                }
                openArticle.Show();
                Hide();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
