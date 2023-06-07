using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using oop2.Services;

namespace oop2.Entities
{
    public class Admin : IUser
    {
        public Admin(int id, string? name, string? login, string? password)
        {
            Id = id;
            Name = name;
            Login = login;
            Password = password;
        }
        public Admin()
        {
            Id = -1;
            Name = "admin";
            Login = "admin";
            Password = "admin";
        }

        Database database;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        private List<Vacancy> vacancies = new();

        public void DeleteAdminVacancy(Vacancy vacancy)
        {
            database.DeleteVacancy(vacancy);
        }

        public void EditAdminVacancy(Vacancy vacancy, string name, double cost, string discription)
        {
            foreach (var item in database.Allvacancies)
            {
                if (item == vacancy)
                {
                    item.Name = name;
                    item.Cost = cost;
                    item.Discription = discription;
                }
            }
        }

        public List<Vacancy> GetListIncomes()
        {
            return vacancies;
        }
    }
}
