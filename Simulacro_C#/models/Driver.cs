using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simulacro_C_.models
{
    public class Driver : User
    {
        public string? LicenseNumnber { get; set; }
        public string? LicenseCategory { get; set; }
        public int DrivingExperience { get; set; }

        //Constructor
        public Driver(string name, string lastName, string typeDocument, string identificationNumber, DateOnly birthday, string email, string phoneNumber, string address,string licenseNumber, string licenseCategory, int drivingExperience) : base (name,lastName,typeDocument, identificationNumber, birthday, email, phoneNumber, address)
        {
            LicenseNumnber = licenseNumber;
            LicenseCategory = licenseCategory;
            DrivingExperience = drivingExperience;
        }

        //UpdateLicenseCategory
        public void UpdateLicenseCategory(string newLicenseCategory)
        {
            LicenseCategory = newLicenseCategory;
        }

        //AddExperience
        public void AddExperience(int years)
        {
            DrivingExperience += years;
        }

    }
}