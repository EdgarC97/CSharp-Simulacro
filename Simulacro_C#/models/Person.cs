using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simulacro_C_.models
{
    //CLASE ABSTRACTA PARA PRACTICA
    public abstract class Person
    {
        protected Guid Id { get; set; }
        protected string? Name { get; set; }
        protected string? LastName { get; set; }
        protected DateOnly Birthdate { get; set; }

        // Constructor abstracto
        public Person(string name, string lastName, DateOnly birthdate)
        {
            Id = Guid.NewGuid();
            Name = name;
            LastName = lastName;
            Birthdate = birthdate;
        }

        // Método abstracto
        public abstract void DisplayDetails();

        // Método concreto
        public int GetAge()
        {
            int age = DateTime.Today.Year - Birthdate.Year;
            if (DateTime.Today.Month < Birthdate.Month ||
                (DateTime.Today.Month == Birthdate.Month && DateTime.Today.Day < Birthdate.Day))
            {
                age--;
            }
            return age;
        }
    }
}