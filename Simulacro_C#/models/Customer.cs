using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simulacro_C_.models
{
    public class Customer : User
    {
        public string? MembershipLevel { get; set; }
        public string? PreferrePaymentMethod { get; set; }

        //Constructor completo
        public Customer(string name, string lastName, string typeDocument, string identificationNumber, DateOnly birthday, string email, string phoneNumber, string address, string membershipLevel, string preferrePaymentMethod) : base(name, lastName, typeDocument, identificationNumber, birthday, email, phoneNumber, address)
        {
            MembershipLevel = membershipLevel;
            PreferrePaymentMethod = preferrePaymentMethod;
        }

        // Constructor con menos parámetros
        public Customer(string name, string lastName, string identificationNumber, string membershipLevel, string preferrePaymentMethod)
            : base(name, lastName, identificationNumber)
        {
            MembershipLevel = membershipLevel;
            PreferrePaymentMethod = preferrePaymentMethod;
        }

        //Metodos para actualizar los atributos
        public void SetMembershipLevel(string membershipLevel) => MembershipLevel = membershipLevel;
        public void SetPreferrePaymentMethod(string preferrePaymentMethod) => PreferrePaymentMethod = preferrePaymentMethod;

        // Muestra los detalles del cliente en formato tabular
        public override void GetDetails()
        {
            Console.WriteLine($"{Name,-10}|{LastName,-10}|{TypeDocument,-12}|{IdentificationNumber,-12}|{Birthdate,-12}|{Email,-30}|{PhoneNumber,-12}|{Address,-20}|{MembershipLevel,-16}|{PreferrePaymentMethod,-15}|");
        }

        // Método para mostrar detalles básicos en formato tabular
        public void ShowBasicCustomer()
        {
            Console.WriteLine($"{Name,-10}|{LastName,-10}|{IdentificationNumber,-12}|{MembershipLevel,-16}|{PreferrePaymentMethod,-15}|");
        }
    }
}


//SI SE IMPLEMENTARA CON LA CLASE ABSTRACTA PERSON
// public class Customer : User
//     {
//         public string? MembershipLevel { get; set; }
//         public string? PreferrePaymentMethod { get; set; }

//         // Constructor completo
//         public Customer(string name, string lastName, string typeDocument, string identificationNumber, DateOnly birthday, string email, string phoneNumber, string address, string membershipLevel, string preferrePaymentMethod)
//             : base(name, lastName, typeDocument, identificationNumber, birthday, email, phoneNumber, address)
//         {
//             MembershipLevel = membershipLevel;
//             PreferrePaymentMethod = preferrePaymentMethod;
//         }

//         // Constructor simplificado
//         public Customer(string name, string lastName, string identificationNumber, string membershipLevel, string preferrePaymentMethod)
//             : base(name, lastName, "N/A", identificationNumber, DateOnly.MinValue, "N/A", "N/A", "N/A")
//         {
//             MembershipLevel = membershipLevel;
//             PreferrePaymentMethod = preferrePaymentMethod;
//         }

//         // Implementación del método abstracto
//         public override void DisplayDetails()
//         {
//             Console.WriteLine($"{Name,-10}|{LastName,-10}|{IdentificationNumber,-12}|{MembershipLevel,-16}|{PreferrePaymentMethod,-15}|");
//         }
//     }