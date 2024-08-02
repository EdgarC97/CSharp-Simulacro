using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simulacro_C_.models
{
    public class User
    {
        protected Guid Id { get; set; }
        protected string? Name { get; set; }
        protected string? LastName { get; set; }
        protected string? TypeDocument { get; set; }
        protected string? IdentificationNumber { get; set; }
        protected DateOnly Birthdate { get; set; }
        protected string? Email { get; set; }
        protected string? PhoneNumber { get; set; }
        protected string? Address { get; set; }

        //Constructor
        public User(string name, string lastName, string typeDocument, string identificationNumber, DateOnly birthday, string email, string phoneNumber, string address)
        {
            Name = name;
            LastName = lastName;
            TypeDocument = typeDocument;
            IdentificationNumber = identificationNumber;
            Birthdate = birthday;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        //Show details
        protected void ShowDetails()
        {
            Console.WriteLine($"\nName: {Name}\nLast Name: {LastName}\nDocument Type: {TypeDocument}\nDocument Number: {IdentificationNumber}\nBirthdate: {Birthdate}\nEmail: {Email}\nPhone Number: {PhoneNumber}\nAddress: {Address}");
        }
        //Obtener details
        public virtual void GetDetails()
        {
            ShowDetails();
        }

        //Calculate age
        protected int CalculateAge()
        {
            int age = DateTime.Today.Year - Birthdate.Year;
            if (DateTime.Today.Month < Birthdate.Month || (DateTime.Today.Month == Birthdate.Month && DateTime.Today.Day < Birthdate.Day))
            {
                age--;
            }
            return age;
        }
        //Get age
        public int GetAge()
        {
            return CalculateAge();
        }

        //Show age
        protected void ShowAge()
        {
            Console.WriteLine("Showing age");
        }

    }
}