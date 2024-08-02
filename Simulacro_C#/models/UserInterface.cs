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
            bool exit = false; // Bandera para controlar la salida del bucle
            while (!exit)
            {
                // Limpio la consola para una presentación más limpia del menú
                Console.Clear();
                // Muestro el menú de opciones al usuario
                Console.WriteLine("=== Sistema de Transporte Riwi ===");
                Console.WriteLine("1. Listar clientes registrados");
                Console.WriteLine("2. Listar conductores registrados");
                Console.WriteLine("3. Listar usuarios con más de 30 años de edad");
                Console.WriteLine("4. Ordenar conductores por su expereriencia");
                Console.WriteLine("5. Encontrar clientes con metodo de pago: Tarjeta de credito");
                Console.WriteLine("6. Listar conductores con licencia de categoria : A2");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");

                // Leo la opción ingresada por el usuario y valida que sea un número
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    Console.ReadKey();
                    continue;
                }

                try
                {
                    // Ejecuto la acción correspondiente según la opción seleccionada
                    switch (choice)
                    {
                        case 1:
                            AdministratorApp.ShowCustomers();
                            break;
                        case 2:
                            AdministratorApp.ShowDrivers();
                            break;
                        case 3:
                            Console.Clear();
                            var driversOlderThan30 = AdministratorApp.GetDriverOlderThan30(AdministratorApp.Drivers);
                            Console.WriteLine("Conductores mayores de 30 años:");
                            foreach (var user in driversOlderThan30)
                            {
                                user.GetDetails();
                            }
                            var customersOlderThan30 = AdministratorApp.GetCustomerOlderThan30(AdministratorApp.Customers);
                            Console.WriteLine("Clientes mayores de 30 años:");
                            foreach (var user in customersOlderThan30)
                            {
                                user.GetDetails();
                            }
                            break;
                        case 4:
                            Console.Clear();
                            var driversOrderedByExpDesc = AdministratorApp.GetTeachersOrderedBySalaryDesc(AdministratorApp.Drivers);
                            Console.WriteLine("\nConductores ordenados por experiencia descendente:\n");
                            foreach (var driver in driversOrderedByExpDesc)
                            {
                                driver.GetDetails();
                            }
                            break;
                        // case 5:
                        //     AdministratorApp.FindCreditCardCustomers();
                        //     break;
                        // case 6:
                        //     AdministratorApp.ShowDriversWithA2();
                        //     break;
                        case 7:
                            exit = true; // Establezco la bandera exit a true para salir del bucle
                            Console.WriteLine("Gracias por usar el Sistema de Gestión de Escuela. ¡Hasta luego!");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Por favor, intente de nuevo."); // Mensaje para opciones no válidas
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // Capturo y muestra cualquier excepción que ocurra durante la ejecución
                    Console.WriteLine($"Error: {ex.Message}");
                }

                if (!exit)
                {
                    // Solicito al usuario que presione una tecla para continuar si no se ha salido
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}