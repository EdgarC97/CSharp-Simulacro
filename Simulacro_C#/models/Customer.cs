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

        //Constructor
        public Customer(string name, string lastName, string typeDocument, string identificationNumber, DateOnly birthday, string email, string phoneNumber, string address, string membershipLevel, string preferrePaymentMethod) : base(name, lastName, typeDocument, identificationNumber, birthday, email, phoneNumber, address)
        {
            MembershipLevel = membershipLevel;
            PreferrePaymentMethod = preferrePaymentMethod;
        }

        //UpdateMemberShip
        public void UpdateMembership()
        {
            MembershipLevel = "Gold";
        }

        //// Muestra los detalles del cliente en formato tabular
        public override void GetDetails()
        {
            Console.WriteLine($"{Name,-10}|{LastName,-10}|{TypeDocument,-12}|{IdentificationNumber,-12}|{Email,-30}|{PhoneNumber,-12}||{MembershipLevel,-12}|{PreferrePaymentMethod,-12}|");
        }

    }
}