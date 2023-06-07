using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oop2.Services;

namespace oop2.Entities
{
    public class User : IUser
    {
        public User(int id, string? name, string? login, string? password)
        {
            Id = id;
            Name = name;
            Login = login;
            Password = password;
        }
        public User()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public List<Vacancy> vacancies = new();

        public void EditVacancyUser(string nameOfVacancy,string name, double cost, string discription)
        {
            foreach (var item in vacancies)
            {
                if (item.Name == nameOfVacancy)
                {
                    item.Edit(name, cost, discription);
                }
            }
        }

        public void DeleteVacancyUser(string nameOfVacancy)
        {
            if (vacancies.Count == 0)
            {
                return;
            }
            if (vacancies.Count >= 2)
            {
                foreach (var item in vacancies)
                {
                    if (item.Name == nameOfVacancy)
                    {
                        vacancies.Remove(item);
                    }
                }
            }
            else
            {
                vacancies.Clear();
            }
            
            
        }

        public List<Vacancy> GetList()
        {
            return vacancies;
        }
    }
}
