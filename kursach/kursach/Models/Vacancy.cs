using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach.Models
{
    public class Vacancy
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "Salary")]
        public string Salary { get; set; }


        public Vacancy()
        {
            Id = Guid.NewGuid().ToString();
        }

        public Vacancy(string name, string description, string salary)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Description = description;
            Salary = salary;

        }
    }
}

