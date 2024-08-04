using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simulacro_C_.models
{
    public class User //: Person
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

        //Constructor principal
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

        // Constructor adicional
        public User(string name, string lastName, string identificationNumber)
        {
            Name = name;
            LastName = lastName;
            IdentificationNumber = identificationNumber;
        }

        // Métodos públicos para actualizar los atributos
        public void SetName(string name) => Name = name;
        public void SetLastName(string lastName) => LastName = lastName;
        public void SetTypeDocument(string typeDocument) => TypeDocument = typeDocument;
        public void SetIdentificationNumber(string identificationNumber) => IdentificationNumber = identificationNumber;
        public void SetBirthdate(DateOnly birthdate) => Birthdate = birthdate;
        public void SetEmail(string email) => Email = email;
        public void SetPhoneNumber(string phoneNumber) => PhoneNumber = phoneNumber;
        public void SetAddress(string address) => Address = address;

        //Metodo para obtener el nombre del usuario
        public string? GetName()
        {
            return Name;
        }

        //Metodo para obtener el apellido del usuario
        public string? GetLastName()
        {
            return LastName;
        }

        //Metodo para obtener el documento del usuario
        public string? GetIdentificationNumber()
        {
            return IdentificationNumber;
        }

        //Metodo para mostrar obtener los detalles de los usuarios
        protected void ShowDetails()
        {
            Console.WriteLine($"\nName: {Name}\nLast Name: {LastName}\nDocument Type: {TypeDocument}\nDocument Number: {IdentificationNumber}\nBirthdate: {Birthdate}\nEmail: {Email}\nPhone Number: {PhoneNumber}\nAddress: {Address}");
        }

        //Metodo para obtener los detalles de los usuarios
        public virtual void GetDetails()
        {
            ShowDetails();
        }

        //Metodo para calcular la edad
        protected int CalculateAge()
        {
            //Aqui se obtiene la diferencia en años
            int age = DateTime.Today.Year - Birthdate.Year;
            //Aqui se verifica si ya los cumplió o no, de acuerdo al mes y al dia
            if (DateTime.Today.Month < Birthdate.Month || (DateTime.Today.Month == Birthdate.Month && DateTime.Today.Day < Birthdate.Day))
            {
                age--;
            }
            return age;
        }
        //Metodo para obtener la edad calculada
        public int GetAge()
        {
            return CalculateAge();
        }

    }
}

//SI SE IMPLEMENTARA LA CLASE ABSTRACTA PERSON
// public class User : Person
//     {
//         protected string? TypeDocument { get; set; }
//         protected string? IdentificationNumber { get; set; }
//         protected string? Email { get; set; }
//         protected string? PhoneNumber { get; set; }
//         protected string? Address { get; set; }

//         // Constructor
//         public User(string name, string lastName, string typeDocument, string identificationNumber, DateOnly birthdate, string email, string phoneNumber, string address)
//             : base(name, lastName, birthdate)
//         {
//             TypeDocument = typeDocument;
//             IdentificationNumber = identificationNumber;
//             Email = email;
//             PhoneNumber = phoneNumber;
//             Address = address;
//         }

//         // Implementación del método abstracto
//         public override void DisplayDetails()
//         {
//             Console.WriteLine($"Name: {Name}\nLast Name: {LastName}\nDocument Type: {TypeDocument}\nDocument Number: {IdentificationNumber}\nBirthdate: {Birthdate}\nEmail: {Email}\nPhone Number: {PhoneNumber}\nAddress: {Address}");
//         }
//     }