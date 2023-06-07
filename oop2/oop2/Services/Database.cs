using System;
using System.IO;
using oop2.Entities;
using oop2.Services;
using SerializerLib;

namespace oop2.Services
{
	public class Database
	{
		public Database()
		{

		}

		public List<User> Allusers = new();
        public List<Vacancy> Allvacancies = new();

		public void AddUser(User user)
		{
			Allusers.Add(user);
		}

        public void DeleteUser(User user)
        {
			Allusers.Remove(user);
        }

        public void AddVacancy(Vacancy vacancy)
        {
            Allvacancies.Add(vacancy);
        }

        public void DeleteVacancy(Vacancy vacancy)
        {

            Allvacancies.Remove(vacancy);

        }

        public void EditVacancy(string nameOfVacancy, string name, double cost, string discription)
        {
            foreach (var item in Allvacancies)
            {
                if (item.Name == nameOfVacancy)
                {
                    item.Edit(name, cost, discription);
                }
            }
        }

        public void AddVacancyToUser (Vacancy vacancy, User user)
        {
            foreach (var item in Allusers)
            {
                if (user == item)
                {
                    item.vacancies.Add(vacancy);
                }
            }
        }

        public User FindUserByVacancy (string vacancyName)
        {
            foreach (var user in Allusers)
            {
                foreach (var vac in user.vacancies)
                {
                    if (vacancyName == vac.Name)
                    {
                        return user;
                    }
                }
            }
            return null;
        }

        public bool VerifyCheck(string login, string password)
        {
            foreach (var item in Allusers)
            {
                if (item.Login == login && item.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public User CurrentUser(string login, string password)
        {
            foreach (var item in Allusers)
            {
                if (item.Login == login && item.Password == password)
                {
                    return item;
                }
            }
            return null;
        }

        public Vacancy FindVacancy(string name)
        {
            foreach (var item in Allvacancies)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }

    }
}

