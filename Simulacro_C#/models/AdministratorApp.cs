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

        // -------------------------------------METODOS PARA CLIENTES---------------------------------

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

        //Metodo para agregar un cliente a la lista de clientes de acuerdo al input del usuario.
        public static void AddCustomerFromUserInput()
        {
            Console.Clear();
            Console.WriteLine("\n=== Agregar Cliente ===");

            // Solicitar información del cliente
            Console.Write("Nombre: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Apellido: ");
            string lastName = Console.ReadLine() ?? "";

            Console.Write("Tipo de Documento: ");
            string typeDocument = Console.ReadLine() ?? "";

            Console.Write("Número de Documento: ");
            string identificationNumber = Console.ReadLine() ?? "";

            Console.Write("Fecha de Nacimiento (aaaa-mm-dd): ");
            DateOnly birthdate = DateOnly.Parse(Console.ReadLine() ?? "");

            Console.Write("Email: ");
            string email = Console.ReadLine() ?? "";

            Console.Write("Teléfono: ");
            string phoneNumber = Console.ReadLine() ?? "";

            Console.Write("Dirección: ");
            string address = Console.ReadLine() ?? "";

            Console.Write("Nivel de Membresía: ");
            string membershipLevel = Console.ReadLine() ?? "";

            Console.Write("Método de Pago Preferido: ");
            string preferrePaymentMethod = Console.ReadLine() ?? "";

            try
            {
                // Crear un nuevo cliente con los datos proporcionados
                Customer newCustomer = new Customer(name, lastName, typeDocument, identificationNumber, birthdate, email, phoneNumber, address, membershipLevel, preferrePaymentMethod);

                // Agregar el cliente a la lista
                Customers.Add(newCustomer);
                Console.WriteLine("\nCliente agregado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar el cliente: {ex.Message}");
            }
        }

        // Método para editar un cliente
        public static void EditCustomer()
        {
            Console.Clear();
            Console.WriteLine("\n=== Editar Cliente ===");

            // Buscar al cliente por identificación
            Console.Write("Ingrese el número de identificación del cliente a editar: ");
            string identificationNumber = Console.ReadLine() ?? "";

            // Buscar el cliente en la lista
            Customer? customer = Customers.FirstOrDefault(c => c.GetIdentificationNumber() == identificationNumber);

            if (customer != null)
            {
                // Solicitar nuevos detalles al usuario
                Console.Write("Ingrese el nuevo nombre (deje en blanco para mantener el actual): ");
                string newName = Console.ReadLine() ?? "";
                if (!string.IsNullOrEmpty(newName))
                {
                    customer.SetName(newName);
                }

                Console.Write("Ingrese el nuevo apellido (deje en blanco para mantener el actual): ");
                string newLastName = Console.ReadLine() ?? "";
                if (!string.IsNullOrEmpty(newLastName))
                {
                    customer.SetLastName(newLastName);
                }

                Console.Write("Ingrese el nuevo tipo de documento (deje en blanco para mantener el actual): ");
                string newTypeDocument = Console.ReadLine() ?? "";
                if (!string.IsNullOrEmpty(newTypeDocument))
                {
                    customer.SetTypeDocument(newTypeDocument);
                }

                Console.Write("Ingrese el nuevo número de documento (deje en blanco para mantener el actual): ");
                string newIdentificationNumber = Console.ReadLine() ?? "";
                if (!string.IsNullOrEmpty(newIdentificationNumber))
                {
                    customer.SetIdentificationNumber(newIdentificationNumber);
                }

                Console.Write("Ingrese la nueva dirección (deje en blanco para mantener la actual): ");
                string newAddress = Console.ReadLine() ?? "";
                if (!string.IsNullOrEmpty(newAddress))
                {
                    customer.SetAddress(newAddress);
                }

                Console.Write("Ingrese el nuevo nivel de membresía (deje en blanco para mantener el actual): ");
                string newMembershipLevel = Console.ReadLine() ?? "";
                if (!string.IsNullOrEmpty(newMembershipLevel))
                {
                    customer.SetMembershipLevel(newMembershipLevel);
                }

                Console.Write("Ingrese el nuevo método de pago preferido (deje en blanco para mantener el actual): ");
                string newPreferrePaymentMethod = Console.ReadLine() ?? "";
                if (!string.IsNullOrEmpty(newPreferrePaymentMethod))
                {
                    customer.SetPreferrePaymentMethod(newPreferrePaymentMethod);
                }

                Console.WriteLine("\nCliente actualizado exitosamente.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        //Metodo para eliminar un cliente 
        public static void DeleteCustomer()
        {
            Console.Clear();
            Console.WriteLine("\n=== Eliminar Cliente ===");

            // Mostrar clientes actuales
            ShowCustomers();

            // Solicitar el número de documento del cliente a eliminar
            Console.Write("Ingrese el número de documento del cliente a eliminar: ");
            string id = Console.ReadLine() ?? "";

            // Buscar el cliente en la lista
            Customer? customerToRemove = Customers.FirstOrDefault(c => c.GetIdentificationNumber() == id);

            if (customerToRemove != null)
            {
                // Solicitar confirmación al usuario
                Console.Write("¿Está seguro de que desea eliminar este cliente? (s/n): ");
                string confirmation = Console.ReadLine()?.Trim().ToLower() ?? "";

                if (confirmation == "s" || confirmation == "si")
                {
                    // Eliminar el cliente de la lista
                    Customers.Remove(customerToRemove);
                    Console.WriteLine("Cliente eliminado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Eliminación cancelada.");
                }
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        //Metodos para mostrar clientes mayores de 30 años
        public static List<Customer> GetCustomerOlderThan30(List<Customer> Customers)
        {
            return Customers.Where(s => s.GetAge() > 30).ToList();
        }

        //Metodo para encontrar Clientes que prefieren pagar con tarjeta de credito
        public static List<Customer> GetCustomersForCreditCard(List<Customer> Customers)
        {
            return Customers.Where(t => t.PreferrePaymentMethod?.Equals("Credit Card", StringComparison.OrdinalIgnoreCase) == true).ToList();
        }

        // Método para mostrar detalles básicos de todos los clientes
        public static void ShowBasicCustomers()
        {
            Console.Clear();
            Console.WriteLine("\n=== Lista de Clientes (Básico) ===\n");
            Console.WriteLine($"{"Nombre",-10}|{"Apellido",-10}|{"Número Doc.",-12}|{"Membership Level",-16}|{"Método de Pago",-15}|");
            Console.WriteLine(new string('-', 68));

            foreach (var customer in Customers)
            {
                customer.ShowBasicCustomer();
            }
            Console.WriteLine(new string('-', 68));
        }

        // -------------------------------------METODOS PARA CONDUCTORES---------------------------------

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

        //Metodo para mostrar a conductor por su experiencia en orden descendente
        public static List<Driver> GetDriversOrderedByExperienceDesc(List<Driver> Drivers)
        {
            return Drivers.OrderByDescending(t => t.GetDrivingExperience()).ToList();
        }

        //Metodo para encontrar conductores con licencia 'A2'
        public static List<Driver> ShowDriversWithA2(List<Driver> Drivers)
        {
            return Drivers.Where(d => d.LicenseCategory?.Equals("A2", StringComparison.OrdinalIgnoreCase) == true).ToList();
        }

        //Metodo para actualizar licencia de conductor
        public static void UpdateDriverLicense()
        {
            Console.Clear();
            Console.WriteLine("\n=== Actualizar Licencia de Conductor ===\n");

            // Solicitar el nombre del conductor
            Console.Write("Ingrese el nombre del conductor: ");
            string driverName = Console.ReadLine() ?? "";

            // Buscar el conductor en la lista
            Driver? driver = Drivers.FirstOrDefault(d => d.GetName().Equals(driverName, StringComparison.OrdinalIgnoreCase));

            if (driver != null)
            {
                // Mostrar la información actual de la licencia
                Console.WriteLine($"\nInformación actual de la licencia de {driver.GetName()} {driver.GetLastName()}:");
                Console.WriteLine($"Número de licencia: {driver.LicenseNumnber}");
                Console.WriteLine($"Categoría de licencia: {driver.LicenseCategory}");

                // Solicitar la nueva categoría de licencia
                Console.Write("\nIngrese la nueva categoría de licencia: ");
                string newLicenseCategory = Console.ReadLine() ?? "";

                // Actualizar la categoría de la licencia
                driver.UpdateLicenseCategory(newLicenseCategory);

                Console.WriteLine($"\nLa licencia de {driver.GetName()} {driver.GetLastName()} ha sido actualizada a la categoría {newLicenseCategory}.");
            }
            else
            {
                Console.WriteLine($"\nNo se encontró ningún conductor con el nombre '{driverName}'.");
            }
        }


        // -------------------------------------METODOS PARA VEHICULOS---------------------------------

        //Metodo para agregar vehiculo a la lista 
        public static void AddVehicle(Vehicle vehicle)
        {
            // Validar el objeto Vehicle
            Validator.ValidateVehicle(vehicle);

            // Agregar el vehículo a la colección
            Vehicles.Add(vehicle);
        }

        //Metodo para agregar un vehiculo a la lista de vehiculos de acuerdo al input del usuario.
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

        //Metodo para mostrar nuevos vehiculos con sus respectivos conductores
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

        //Metodo para actualizar un vehiculo
        public static void UpdateVehicle()
        {
            Console.Clear();

            // Mostrar los vehículos actuales
            ShowVehiclesWithDrivers();
            Console.WriteLine("\n=== Actualizar Vehículo ===\n");

            // Solicitar el ID del vehículo a actualizar
            Console.Write("Introduzca el ID del vehículo que desea actualizar: ");
            int id = Validator.GetValidIdFromUserInput();

            // Buscar el vehículo en la lista
            Vehicle? vehicleToUpdate = Vehicles.FirstOrDefault(v => v.Id == id);

            if (vehicleToUpdate != null)
            {
                Console.WriteLine($"\nActualizando vehículo con ID: {id}");
                Console.WriteLine("Deje en blanco y presione Enter para mantener el valor actual.\n");

                // Solicitar los nuevos datos del vehículo
                Console.Write($"Nueva placa -->  ");
                string plate = Console.ReadLine() ?? "";
                if (!string.IsNullOrWhiteSpace(plate))
                    vehicleToUpdate.Plate = Validator.GetValidPlateFromUserInput();

                Console.Write($"Tipo actual:({vehicleToUpdate.Type}): ");
                string type = Console.ReadLine() ?? "";
                if (!string.IsNullOrWhiteSpace(type))
                    vehicleToUpdate.Type = GetValidVehicleTypeFromUserInput();

                Console.Write($"Nuevo número de motor ({vehicleToUpdate.EngineNumber}): ");
                string engineNumber = Console.ReadLine() ?? "";
                if (!string.IsNullOrWhiteSpace(engineNumber))
                    vehicleToUpdate.EngineNumber = Validator.GetValidEngineNumberFromUserInput();

                Console.Write($"Nuevo número de serie ({vehicleToUpdate.SerialNumber}): ");
                string serialNumber = Console.ReadLine() ?? "";
                if (!string.IsNullOrWhiteSpace(serialNumber))
                    vehicleToUpdate.SerialNumber = Validator.GetValidSerialNumberFromUserInput();

                // Solicitar la nueva capacidad
                Console.Write($"Nueva capacidad ({vehicleToUpdate.PeopleCapacity}): ");
                string capacityInput = Console.ReadLine() ?? "";
                if (!string.IsNullOrWhiteSpace(capacityInput))
                    vehicleToUpdate.PeopleCapacity = GetValidPeopleCapacityForVehicleType(vehicleToUpdate.Type);

                Console.Write($"Nuevo conductor ({vehicleToUpdate.Owner?.GetName() ?? "No asignado"}): ");
                string ownerInput = Console.ReadLine() ?? "";
                if (!string.IsNullOrWhiteSpace(ownerInput))
                    vehicleToUpdate.Owner = GetValidDriverFromUserInput();

                Console.WriteLine("\nVehículo actualizado exitosamente.");
            }
            else
            {
                Console.WriteLine($"\nNo se encontró ningún vehículo con el ID {id}.");
            }
        }
        //Metodo para eliminar un vehiculo

        public static void DeleteVehicle()
        {
            Console.Clear();
            Console.WriteLine("\n=== Eliminar Vehículo ===\n");

            // Mostrar los vehículos actuales
            ShowVehiclesWithDrivers();

            // Solicitar el ID del vehículo a eliminar
            Console.Write("\nIntroduzca el ID del vehículo que desea eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido. Por favor, ingrese un número.");
                return;
            }

            // Buscar el vehículo en la lista
            Vehicle? vehicleToDelete = Vehicles.FirstOrDefault(v => v.Id == id);

            if (vehicleToDelete != null)
            {
                // Mostrar detalles del vehículo y pedir confirmación
                Console.WriteLine($"\nVehículo encontrado: {vehicleToDelete.Plate} - {vehicleToDelete.Type}");
                Console.Write("¿Está seguro que desea eliminar este vehículo? (S/N): ");
                string? confirmation = Console.ReadLine()?.ToUpper();

                if (confirmation == "S")
                {
                    // Eliminar el vehículo de la lista
                    Vehicles.Remove(vehicleToDelete);

                    // Si el vehículo tenía un conductor asignado, actualizar la lista de vehículos asignados del conductor
                    if (vehicleToDelete.Owner != null)
                    {
                        vehicleToDelete.Owner.AssignedVehicles.Remove(vehicleToDelete);
                    }

                    Console.WriteLine($"\nEl vehículo con ID {id} ha sido eliminado exitosamente.");
                }
                else
                {
                    Console.WriteLine("\nOperación de eliminación cancelada.");
                }
            }
            else
            {
                Console.WriteLine($"\nNo se encontró ningún vehículo con el ID {id}.");
            }
        }

        // -------------------------------------METODOS PARA CONDICIONALES DE VEHICULOS---------------------------------

        //Metodo para obtener un tipo de vehiculo valido segun los vehiculos permitidos en Vehicles
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

        //Metodo para obtener la capacidad valida dependiendo el tipo de vehiculos
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

        //Metodo para obtener conductores validos
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

    }
}