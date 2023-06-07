using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace kursach.Models
{
    public class User
    {
        [JsonProperty(PropertyName = "Email")]
        public string Email;
        [JsonProperty(PropertyName = "Balance")]
        public double Balance;
        [JsonProperty(PropertyName = "Id")]
        public string Id;
        [JsonProperty(PropertyName = "ListOfVacancies")]
        public List<string> ListOfVacancies;

        public User(string email, string id)
        {
            Id = id;
            Email = email;
            ListOfVacancies = new List<string>();
            Balance = 0.0;
        }

        public User()
        {
            ListOfVacancies = new List<string>();
            Balance = 0.0;
        }

        public void AddVacancy(Vacancy vacancy)
        {
            ListOfVacancies.Add(vacancy.Id);
        }

        public void RemoveVacancy(Vacancy vacancy)
        {
            ListOfVacancies.Remove(vacancy.Id);
        }
    }
}
