using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simulacro_C_.models
{
    public static class AdministratorApp
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
            "582-632-555",5,Drivers.FirstOrDefault())
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

        public static void AddVehicle(Vehicle vehicle)
        {
            // Validar el objeto Vehicle
            Validator.ValidateVehicle(vehicle);

            // Agregar el vehículo a la colección
            Vehicles.Add(vehicle);
        }

        //Agregar vehiculo : Este método permitirá agregar un vehiculo a la lista de vehiculos.
        public static void AddVehicleFromUserInput()
        {
            Console.Clear();
            Console.WriteLine("\n=== Agregar Vehículo ===");

            int id = Validator.GetValidIdFromUserInput();
            string plate = Validator.GetValidPlateFromUserInput();
            string type = GetValidVehicleTypeFromUserInput();
            string engineNumber = Validator.GetValidEngineNumberFromUserInput();
            string serialNumber = Validator.GetValidSerialNumberFromUserInput();
            byte peopleCapacity = GetValidPeopleCapacityForVehicleType(type);
            Driver owner = GetValidDriverFromUserInput();

            try
            {
                // Creamos un nuevo vehículo con los datos validados
                Vehicle newVehicle = new Vehicle(id, plate, type, engineNumber, serialNumber, peopleCapacity, owner);

                // Agregamos el vehículo a la lista
                Vehicles.Add(newVehicle);
                Console.WriteLine("\nVehículo agregado exitosamente.");

                // Asignamos el vehículo al conductor
                owner.AssignVehicle(newVehicle);
                Console.WriteLine($"\nVehículo asignado al conductor {owner.GetName()}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error al crear el vehículo: {ex.Message}");
            }
        }

        private static string GetValidVehicleTypeFromUserInput()
        {
            while (true)
            {
                Console.WriteLine("Tipos de vehículos permitidos:");
                foreach (var vehicleType in Vehicle.AllowedVehicles)
                {
                    Console.WriteLine($"- {vehicleType}");
                }
                Console.Write("Ingrese el tipo de vehículo: ");
                string type = Console.ReadLine() ?? "";
                if (Vehicle.AllowedVehicles.Contains(type, StringComparer.OrdinalIgnoreCase))
                {
                    return type;
                }
                Console.WriteLine("Tipo de vehículo no válido. Por favor, elija uno de la lista.");
            }
        }

        private static byte GetValidPeopleCapacityForVehicleType(string vehicleType)
        {
            int maxCapacity = vehicleType.ToLower() switch
            {
                "moto" => 2,
                "carro" => 5,
                "camioneta" => 8,
                "microbus" => 10,
                _ => throw new ArgumentException("Tipo de vehículo no válido")
            };

            while (true)
            {
                Console.Write($"Capacidad (máximo {maxCapacity} para {vehicleType}): ");
                if (byte.TryParse(Console.ReadLine(), out byte capacity) && capacity > 0 && capacity <= maxCapacity)
                {
                    return capacity;
                }
                Console.WriteLine($"Capacidad no válida. Debe ser un número entre 1 y {maxCapacity}.");
            }
        }

        private static Driver GetValidDriverFromUserInput()
        {
            while (true)
            {
                Console.Write("Nombre del conductor: ");
                string driverName = Console.ReadLine() ?? "";

                Driver? driver = Drivers.FirstOrDefault(d => d.GetName() != null && d.GetName().Equals(driverName, StringComparison.OrdinalIgnoreCase));
                if (driver != null)
                {
                    return driver;
                }
                Console.WriteLine("Conductor no encontrado. Por favor, intente de nuevo.");
            }
        }
        //Metodo para mostrar nuevos vehiculos con sus respectivos conducrores
        public static void ShowVehiclesWithDrivers()
        {
            Console.Clear();
            Console.WriteLine("\n=== Vehículos y sus Conductores Asignados ===\n");
            Console.WriteLine($"{"ID",-5}|{"Placa",-10}|{"Tipo",-10}|{"Capacidad",-10}|{"Nº Motor",-15}|{"Nº Serie",-15}|{"Conductor",-15}|");
            Console.WriteLine(new string('-', 87));

            foreach (var vehicle in Vehicles)
            {
                string driverName = vehicle.Owner != null ? $"{vehicle.Owner.GetName()} {vehicle.Owner.GetLastName()}" : "No asignado";
                Console.WriteLine($"{vehicle.Id,-5}|{vehicle.Plate,-10}|{vehicle.Type,-10}|{vehicle.PeopleCapacity,-10}|{vehicle.EngineNumber,-15}|{vehicle.SerialNumber,-15}|{driverName,-15}|");
            }

            Console.WriteLine(new string('-', 87));
        }
    }
}