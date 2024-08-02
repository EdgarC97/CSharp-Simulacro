using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simulacro_C_.models
{
    public class AdministratorApp
    {
        // Lista de conductores inicial
        public static List<Driver> Drivers = new List<Driver>
        {
            new Driver(
            "Juan", "Pérez", "DNI", "12345678",
            new DateOnly(1963, 1, 1),"juan.perez@email.com","3007448967",
            "Calle falsa 123","89600","B2",15)
        };
        //Lista de clientes inicial
        public static List<Customer> Customers = new List<Customer>
        {
            new Customer(
            "Benito", "Mussolini", "DNI", "987654321",
            new DateOnly(1962, 2, 2),"benito.mussolini@email.com","3007448968",
            "Calle falsa 321","Gold","Cash")
        };
        //Lista de vehiculos inicial
        public static List<Vehicle> Vehicles = new List<Vehicle>
        {
            new Vehicle(
            8900, "AHN-333", "Car", "951-357",
            "582-632-555",5)
        };
    }
}