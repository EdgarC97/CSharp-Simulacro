using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simulacro_C_.models
{
    public class AdministratorApp
    {
        //Lista de usuarios
        public static List<User> Users = new List<User>();
        // Lista de conductores inicial
        public static List<Driver> Drivers = new List<Driver>
        {
            new Driver(
            "Juan", "Pérez", "DNI", "12345678",
            new DateOnly(1963, 1, 1),"juan.perez@email.com","3007448967",
            "Calle falsa 123","89700","B2",15),

            new Driver(
            "Alci", "Acosta", "DNI", "49845678",
            new DateOnly(1999, 1, 1),"alci.acosta@email.com","3027448968",
            "Calle falsa 567","89600","A2",8),

            new Driver(
            "Checo", "Acosta", "DNI", "12201678",
            new DateOnly(1970, 1, 1),"checo.acosta@email.com","3017448969",
            "Calle falsa 890","89800","A2",10),

            new Driver(
            "Ana", "Pulido", "DNI", "00345678",
            new DateOnly(2000, 1, 1),"ana.pulido@email.com","3037448960",
            "Calle falsa 000","89500","B2",2)
        };
        //Lista de clientes inicial
        public static List<Customer> Customers = new List<Customer>
        {
            new Customer(
            "Benito", "Mussolini", "DNI", "987654321",
            new DateOnly(1962, 2, 2),"benito.mussolini@email.com","3007448968",
            "Calle falsa 321","Gold","Cash"),

            new Customer(
            "Joseph", "Stanlin", "DNI", "087654321",
            new DateOnly(2000, 2, 2),"joseph.stanlin@email.com","3017448969",
            "Calle falsa 567","Premiun","Credit Card"),

            new Customer(
            "Adolf", "Hitler", "DNI", "187654321",
            new DateOnly(1950, 2, 2),"adolf.hitler@email.com","3027448969",
            "Calle falsa 000","Elite","Credit Card")
        };
        //Lista de vehiculos inicial
        public static List<Vehicle> Vehicles = new List<Vehicle>
        {
            new Vehicle(
            8900, "AHN-333", "Car", "951-357",
            "582-632-555",5)
        };

        //Methods

        //Metodo para mostrar todos los clientes registrados
        public static void ShowCustomers()
        {
            Console.Clear();
            Console.WriteLine("\n=== Lista de clientes ===\n");
            Console.WriteLine($"{"Nombre",-10}|{"Apellido",-10}|{"Tipo Doc.",-12}|{"Número Doc.",-12}|{"Cumpleaños",-12}|{"Email",-30}|{"Teléfono",-12}|{"Direccion",-20}|{"Membership Level",-16}|{"Metodo de pago",-15}|");
            Console.WriteLine(new string('-', 159));

            foreach (var customer in Customers)
            {
                customer.GetDetails();
            }
            Console.WriteLine(new string('-', 159));
        }

        //Metodo para mostrar todos los conductores registrados
        public static void ShowDrivers()
        {
            Console.Clear();
            Console.WriteLine("\n=== Lista de conductores ===\n");
            Console.WriteLine($"{"Nombre",-10}|{"Apellido",-10}|{"Tipo Doc.",-12}|{"Número Doc.",-12}|{"Cumpleaños",-12}|{"Email",-30}|{"Teléfono",-12}|{"Direccion",-20}|{"Num de licencia",-15}|{"Tipo de licencia",-17}|{"Experiencia(años)",-17}|");
            Console.WriteLine(new string('-', 178));

            foreach (var driver in Drivers)
            {
                driver.GetDetails();
            }
            Console.WriteLine(new string('-', 178));
        }

        //Metodos para mostrar a usuarios mayores de 30 años
        public static List<Driver> GetDriverOlderThan30(List<Driver> Drivers)
        {
            return Drivers.Where(s => s.GetAge() > 30).ToList();
        }
        public static List<Customer> GetCustomerOlderThan30(List<Customer> Customers)
        {
            return Customers.Where(s => s.GetAge() > 30).ToList();
        }

        //Metodo para mostrar a conductor por su experiencia en orden descendente
        public static List<Driver> GetTeachersOrderedBySalaryDesc(List<Driver> Drivers)
        {
            return Drivers.OrderByDescending(t => t.GetDrivingExperience()).ToList();
        }

        //Metodo para encontrar Clientes que prefieren pagar con tarjeta de credito
        public static List<Customer> GetCustomersForCreditCard(List<Customer> Customers)
        {
            return Customers.Where(t => t.PreferrePaymentMethod?.Equals("Credit Card", StringComparison.OrdinalIgnoreCase) == true).ToList();
        }

        //Metodo para encontrar conductores con licencia 'A2'
        public static List<Driver> ShowDriversWithA2(List<Driver> Drivers)
        {
            return Drivers.Where(d => d.LicenseCategory?.Equals("A2", StringComparison.OrdinalIgnoreCase) == true).ToList();
        }
    }
}