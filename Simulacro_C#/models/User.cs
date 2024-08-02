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
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Last Name: {LastName}");
            Console.WriteLine($"Type Document: {TypeDocument}");
            Console.WriteLine($"Identification Number: {IdentificationNumber}");
            Console.WriteLine($"Birthday: {Birthdate.ToString("yyyy-MM-dd")}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Phone Number: {PhoneNumber}");
            Console.WriteLine($"Address: {Address}");
        }
        
        //Calculate age
        protected int CalculateAge()
        {
            return DateTime.Today.Year - Birthdate.Year;
        }

        //Show age
        protected void ShowAge()
        {
            Console.WriteLine("Showing age");
        }

    }
}