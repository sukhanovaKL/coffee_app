using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace coffee_app
{
    public class Functions
    {
        Coffee_AppEntities coffee = new Coffee_AppEntities();
        int count = 0;

        public Functions() { }

        public bool Reg(string log, string pass, string name, string surname)
        {
            var logins = coffee.Users.Select(x => x.login);
            if (!logins.Contains(log))
            {
                coffee.Users.Add(new Users()
                {
                    idGuid = Guid.NewGuid(),
                    login = log,
                    pass = pass,
                    name = name,
                    surname = surname,
                    role = "user"
                });
                coffee.SaveChanges();
                return true;
            }
            else
            {
                MessageBox.Show("Пользователь с таким логином уже есть");
                return false;
            }
        }

        public bool SignUp(string log, string pass)
        {
            if (log != "" || pass != "")
            {
                foreach (Users n in coffee.Users)
                {
                    if (log == n.login && pass == n.pass && n.role == "user")
                    {
                        Profile p = new Profile();
                        p.User = n;
                        p.Show();
                        p.UserName.Content = n.name + " " + n.surname + "!";
                        return true;
                    }
                    else if (log == n.login && pass == n.pass && n.role == "admin")
                    {
                        Admin admin = new Admin();
                        admin.Show();
                        return true;
                    }
                }
            }
            MessageBox.Show("Ошибка");
            MainWindow m = new MainWindow();
            m.Show();
            return false;
        }
        public bool EditArticle(Guid idArt, string name, string text)
        {
            Article article = new Article();
            foreach (var i in coffee.Article)
            {
                if (i.idGuid == idArt)
                    article = i;
            }
            article.name = name;
            article.text = text;

            coffee.SaveChanges();
            MessageBox.Show("Сохранено!");
            return true;
        }

        public bool SaveArticle(Guid idUser, Guid idArticle)
        {
            count = coffee.SavedArticle.Count();
            List<Guid?> ArticlesUser = new List<Guid?> ();
            foreach(var i in coffee.SavedArticle)
            {
                if (i.idGuidUser == idUser)
                    ArticlesUser.Add(i.idGuidArticle);
            }
            if (!ArticlesUser.Contains(idArticle))
            {
                coffee.SavedArticle.Add(new SavedArticle()
                {
                    id = ++count,
                    idGuidArticle = idArticle,
                    idGuidUser = idUser
                });
            }
            else
            {
                MessageBox.Show("Данная статья уже сохранена :)");
            }

            coffee.SaveChanges();
            return true;
        }

        public bool RegCoffeeHouse(Guid idCoffeeHouse, string name, string text, string adres)
        {
            CoffeeHouse house = new CoffeeHouse();
            foreach(var i in coffee.CoffeeHouse)
            {
                if(i.idGuid == idCoffeeHouse)
                {
                    house = i;
                }
            }
            house.name = name;
            house.description = text;
            house.address = adres;
            coffee.SaveChanges();
            MessageBox.Show("Сохранено!");
            return true;
        }

        public bool DeleteCoffeeHouse(CoffeeHouse house)
        {
            foreach(var i in coffee.CoffeeHouse)
            {
                if(house.idGuid == i.idGuid)
                    coffee.CoffeeHouse.Remove(i);
            }
            coffee.SaveChanges();
            MessageBox.Show("Удалено!");
            return true;
        }

        public bool AddCoffeeHouse(string name, string description, string adres)
        {
            coffee.CoffeeHouse.Add(new CoffeeHouse()
            {
                idGuid = Guid.NewGuid(),
                name = name,
                description = description,
                address = adres
            });
            coffee.SaveChanges();
            return true;
        }
    }
}
