using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simulacro_C_.models
{
    public class UserInterface
    {
        public static void Run()
        {
            bool exit = false; // Bandera para controlar la salida del bucle principal
            while (!exit)
            {
                // Limpio la consola para una presentación más limpia del menú
                Console.Clear();
                // Muestro el menú de opciones al usuario
                Console.WriteLine("=== Sistema de Transporte Riwi ===");
                Console.WriteLine("1. Gestión de Clientes");
                Console.WriteLine("2. Gestión de Conductores");
                Console.WriteLine("3. Gestión de Vehículos");
                Console.WriteLine("4. Métodos LINQ");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                // Leo la opción ingresada por el usuario y valida que sea un número
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        ManageCustomers();
                        break;
                    case 2:
                        ManageDrivers();
                        break;
                    case 3:
                        ManageVehicles();
                        break;
                    case 4:
                        LinqMethods();
                        break;
                    case 5:
                        exit = true; // Salir del bucle principal
                        Console.WriteLine("Gracias por usar el Sistema de Transporte de Riwi. ¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                        break;
                }

                if (!exit)
                {
                    // Solicito al usuario que presione una tecla para continuar si no se ha salido
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        //Metodo para gestionar los clientes
        private static void ManageCustomers()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Gestión de Clientes ===");
                Console.WriteLine("1. Mostrar clientes registrados");
                Console.WriteLine("2. Agregar clientes ");
                Console.WriteLine("3. Actualizar clientes ");
                Console.WriteLine("4. Eliminar clientes ");
                Console.WriteLine("5. Encontrar clientes con método de pago: Tarjeta de crédito");
                Console.WriteLine("6. Mostrar info basica de clientes registrados");
                Console.WriteLine("7. Regresar al menú principal");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AdministratorApp.ShowCustomers();
                        break;
                    case 2:
                        AdministratorApp.AddCustomerFromUserInput();
                        break;
                    case 3:
                        AdministratorApp.EditCustomer();
                        break;
                    case 4:
                        AdministratorApp.DeleteCustomer();
                        break;
                    case 5:
                        Console.Clear();
                        var customersForCreditCard = AdministratorApp.GetCustomersForCreditCard(AdministratorApp.Customers);
                        Console.WriteLine("\n=== Clientes que usan 'Credit Card' ===\n");
                        Console.WriteLine($"{"Nombre",-10}|{"Apellido",-10}|{"Tipo Doc.",-12}|{"Número Doc.",-12}|{"Cumpleaños",-12}|{"Email",-30}|{"Teléfono",-12}|{"Direccion",-20}|{"Membership Level",-16}|{"Metodo de pago",-15}|");
                        Console.WriteLine(new string('-', 159));
                        foreach (var customer in customersForCreditCard)
                        {
                            customer.GetDetails();
                        }
                        break;
                    case 6:
                        AdministratorApp.ShowBasicCustomers();
                        break;
                    case 7:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        //Metodos para gestionar los conductores
        private static void ManageDrivers()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Gestión de Conductores ===");
                Console.WriteLine("1. Mostrar conductores registrados");
                Console.WriteLine("2. Actualizar licencia de conductor");
                Console.WriteLine("3. Mostrar conductores con licencia de categoría: A2");
                Console.WriteLine("4. Ordenar conductores por su experiencia");
                Console.WriteLine("5. Regresar al menú principal");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AdministratorApp.ShowDrivers();
                        break;
                    case 2:
                        AdministratorApp.UpdateDriverLicense();
                        break;
                    case 3:
                        Console.Clear();
                        var driversForA2 = AdministratorApp.ShowDriversWithA2(AdministratorApp.Drivers);
                        Console.WriteLine("\n=== Conductores con licencia 'A2' ===\n");
                        Console.WriteLine($"{"Nombre",-10}|{"Apellido",-10}|{"Tipo Doc.",-12}|{"Número Doc.",-12}|{"Cumpleaños",-12}|{"Email",-30}|{"Teléfono",-12}|{"Direccion",-20}|{"Num de licencia",-15}|{"Tipo de licencia",-17}|{"Experiencia(años)",-17}|");
                        Console.WriteLine(new string('-', 178));
                        foreach (var driver in driversForA2)
                        {
                            driver.GetDetails();
                        }
                        break;
                    case 4:
                        Console.Clear();
                        var driversOrderedByExpDesc = AdministratorApp.GetDriversOrderedByExperienceDesc(AdministratorApp.Drivers);
                        Console.WriteLine("\n=== Conductores ordenados por experiencia descendente ===\n");
                        Console.WriteLine($"{"Nombre",-10}|{"Apellido",-10}|{"Tipo Doc.",-12}|{"Número Doc.",-12}|{"Cumpleaños",-12}|{"Email",-30}|{"Teléfono",-12}|{"Direccion",-20}|{"Num de licencia",-15}|{"Tipo de licencia",-17}|{"Experiencia(años)",-17}|");
                        Console.WriteLine(new string('-', 178));
                        foreach (var driver in driversOrderedByExpDesc)
                        {
                            driver.GetDetails();
                        }
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        //Metodo para gestionar los vehículos
        private static void ManageVehicles()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Gestión de Vehículos ===");
                Console.WriteLine("1. Agregar un vehículo");
                Console.WriteLine("2. Mostrar vehículos y conductores asignados");
                Console.WriteLine("3. Actualizar vehículo");
                Console.WriteLine("4. Eliminar vehículo");
                Console.WriteLine("5. Regresar al menú principal");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AdministratorApp.AddVehicleFromUserInput();
                        break;
                    case 2:
                        AdministratorApp.ShowVehiclesWithDrivers();
                        break;
                    case 3:
                        AdministratorApp.UpdateVehicle();
                        break;
                    case 4:
                        AdministratorApp.DeleteVehicle();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        //Metodo para gestionar ejercicios de LINQ
        private static void LinqMethods()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Métodos LINQ ===");
                Console.WriteLine("1. Mostrar usuarios con más de 30 años de edad");
                Console.WriteLine("2. Regresar al menú principal");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        var driversOlderThan30 = AdministratorApp.GetDriverOlderThan30(AdministratorApp.Drivers);
                        Console.WriteLine("\n=== Conductores mayores de 30 años ===\n");
                        Console.WriteLine($"{"Nombre",-10}|{"Apellido",-10}|{"Tipo Doc.",-12}|{"Número Doc.",-12}|{"Cumpleaños",-12}|{"Email",-30}|{"Teléfono",-12}|{"Direccion",-20}|{"Num de licencia",-15}|{"Tipo de licencia",-17}|{"Experiencia(años)",-17}|");
                        Console.WriteLine(new string('-', 178));
                        foreach (var user in driversOlderThan30)
                        {
                            user.GetDetails();
                        }
                        var customersOlderThan30 = AdministratorApp.GetCustomerOlderThan30(AdministratorApp.Customers);
                        Console.WriteLine("\n=== Clientes mayores de 30 años ===\n");
                        Console.WriteLine($"{"Nombre",-10}|{"Apellido",-10}|{"Tipo Doc.",-12}|{"Número Doc.",-12}|{"Cumpleaños",-12}|{"Email",-30}|{"Teléfono",-12}|{"Direccion",-20}|{"Membership Level",-16}|{"Metodo de pago",-15}|");
                        Console.WriteLine(new string('-', 159));
                        foreach (var user in customersOlderThan30)
                        {
                            user.GetDetails();
                        }
                        break;
                    case 2:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}