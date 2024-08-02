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
        public Customer(string membershipLevel, string preferrePaymentMethod,string name, string lastName, string typeDocument, string identificationNumber, DateOnly birthday, string email, string phoneNumber, string address) : base (name,lastName,typeDocument, identificationNumber, birthday, email, phoneNumber, address)
        {
            MembershipLevel = membershipLevel;
            PreferrePaymentMethod = preferrePaymentMethod;
        }
        
        //UpdateMemberShip
        public void UpdateMembership()
        {
            MembershipLevel = "Gold";
        }

    }
}