using System;
namespace oop2.Services
{
    public class Vacancy : IVacancy

    {
        public Vacancy(string? name, double cost, string? discription)
        {
            Name = name;
            Cost = cost;
            Discription = discription;
        }
        public Vacancy() { }

        public string Name { get; set; }
        public double Cost { get; set; }
        public string Discription { get; set; }

        public override string ToString()
        {
            return $"********** Vacancy name: {Name}, vacancy salary: {Cost}, vacancy discription: {Discription} **********";
        }

        public void Edit(string name, double cost, string discriprion)
        {
            Name = name;
            Cost = cost;
            Discription = discriprion;
        }
    }
}

