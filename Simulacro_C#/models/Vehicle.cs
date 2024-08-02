using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simulacro_C_.models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string? Plate { get; set; }
        public string? Type { get; set; }
        public string? EngineNumber { get; set; }
        public string? SerialNumber { get; set; }
        public byte PeopleCapacity { get; set; }
        public Driver? Owner { get; set; }

        //Constructor
        public Vehicle(int id, string plate, string type, string engineNumber, string serialNumber, byte peopleCapacity, Driver owner)
        {
            Id = id;
            Plate = plate;
            Type = type;
            EngineNumber = engineNumber;
            SerialNumber = serialNumber;
            PeopleCapacity = peopleCapacity;
            Owner = owner;
        }

        //DeleteVehicle
        public void DeleteVehicle()
        {
            // Logic to delete the vehicle from the database or storage
        }
    }
}