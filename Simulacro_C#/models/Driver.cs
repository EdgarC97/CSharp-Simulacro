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
        public Driver(string name, string lastName, string typeDocument, string identificationNumber, DateOnly birthday, string email, string phoneNumber, string address, string licenseNumber, string licenseCategory, int drivingExperience) : base(name, lastName, typeDocument, identificationNumber, birthday, email, phoneNumber, address)
        {
            LicenseNumnber = licenseNumber;
            LicenseCategory = licenseCategory;
            DrivingExperience = drivingExperience;
        }

        public List<Vehicle> AssignedVehicles { get; set; } = new List<Vehicle>();

        public void AssignVehicle(Vehicle vehicle)
        {
            AssignedVehicles.Add(vehicle);
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

        // Muestra los detalles del conductor en formato tabular
        public override void GetDetails()
        {
            Console.WriteLine($"{Name,-10}|{LastName,-10}|{TypeDocument,-12}|{IdentificationNumber,-12}|{Birthdate,-12}|{Email,-30}|{PhoneNumber,-12}|{Address,-20}|{LicenseNumnber,-15}|{LicenseCategory,-17}|{DrivingExperience,-17}|");
        }

        //Obtiene los años de experiencia del conductor
        // Obtiene el salario del profesor
        public double GetDrivingExperience()
        {
            return DrivingExperience;
        }

    }
}