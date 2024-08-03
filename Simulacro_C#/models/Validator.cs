using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simulacro_C_.models
{
    // Clase estática Validator que contiene métodos para validar datos de vehiculos y entradas del usuario
    public static class Validator
    {
        // Método para validar un objeto Vehcile
        public static void ValidateVehicle(Vehicle vehicle)
        {
            // Verifica si el objeto Vehicle es nulo y lanza una excepción si es así
            if (vehicle == null)
                throw new ArgumentNullException("El vehiculo no puede ser nulo.");

            // Valida  el id del vehiculo con el método ValidateId
            ValidateId(vehicle.Id);

            // Verifica si la placa del vehiculo está vacía o es nula
            if (string.IsNullOrWhiteSpace(vehicle.Plate))
                throw new ArgumentException("La placa del vehiculo no puede estar vacía.");
            // Valida la placa utilizando el método ValidateSearchTerm
            ValidateSearchTerm(vehicle.Plate, "placa");

            // Verifica si el tipo de vehiculo está vacío o es nulo
            if (string.IsNullOrWhiteSpace(vehicle.Type))
                throw new ArgumentException("El tipo de vehiculo no puede estar vacío.");
            // Valida el tipo utilizando el método ValidateSearchTerm
            ValidateSearchTerm(vehicle.Type, "tipo");

            // Verifica si el numero del motor del vehiculo está vacío o es nulo
            if (string.IsNullOrWhiteSpace(vehicle.EngineNumber))
                throw new ArgumentException("El numero del motor no puede estar vacío.");
            // Valida el numero del motor utilizando el método ValidateSearchTerm
            ValidateSearchTerm(vehicle.EngineNumber, "numero de motor");

            // Verifica si el numero de serie del vehiculo está vacío o es nulo
            if (string.IsNullOrWhiteSpace(vehicle.EngineNumber))
                throw new ArgumentException("El numero del serial no puede estar vacío.");
            // Valida el numero de serie utilizando el método ValidateSearchTerm
            ValidateSearchTerm(vehicle.EngineNumber, "numero de serie");

            // Valida la capacidad del vehiculo con el método ValidateCapacity
            ValidatePeopleCapacity(vehicle.PeopleCapacity);

        }

        // Método para validar que el id no sea negativo
        public static void ValidateId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El id no puede ser negativo.");
        }
        // Método para validar que la capacidad no sea negativa
        public static void ValidatePeopleCapacity(byte peopleCapacity)
        {
            if (peopleCapacity < 0)
                throw new ArgumentException("La capacidad no puede ser negativa.");
        }

        // Método para validar que un término de búsqueda no esté vacío
        public static void ValidateSearchTerm(string term, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(term))
                throw new ArgumentException($"El {fieldName} no puede estar vacío.");
        }

        // Método para obtener y validar el id desde la entrada del usuario
        public static int GetValidIdFromUserInput()
        {
            Console.Write("Id: ");
            // Intenta convertir la entrada a un número entero
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                throw new ArgumentException("Id inválido.");
            }
            // Valida el id utilizando el método ValidateAge
            ValidateId(id);
            return id;
        }

        // Método para obtener y validar la placa desde la entrada del usuario
        public static string GetValidPlateFromUserInput()
        {
            Console.Write("Placa: ");
            string plate = Console.ReadLine() ?? "";
            // Valida la placa utilizando el método ValidateSearchTerm
            ValidateSearchTerm(plate, "placa");
            return plate;
        }

        // Método para obtener y validar el tipo desde la entrada del usuario
        public static string GetValidTypeFromUserInput()
        {
            Console.Write("Tipo: ");
            string tipo = Console.ReadLine() ?? "";
            // Valida el tipo utilizando el método ValidateSearchTerm
            ValidateSearchTerm(tipo, "tipo");
            return tipo;
        }

        // Método para obtener y validar la capacidad del vehiculo desde la entrada del usuario
        public static byte GetValidPeopleCapacityFromUserInput()
        {
            Console.Write("Capacidad: ");
            // Intenta convertir la entrada a un número entero
            if (!byte.TryParse(Console.ReadLine(), out byte capacity))
            {
                throw new ArgumentException("Capacidad inválida.");
            }
            // Valida la capacidad utilizando el método ValidatePeopleCapacity
            ValidatePeopleCapacity(capacity);
            return capacity;
        }

        // Método para obtener y validar el numero del motor desde la entrada del usuario
        public static string GetValidEngineNumberFromUserInput()
        {
            Console.Write("Numero de motor: ");
            string motorNum = Console.ReadLine() ?? "";
            // Valida el numero del motor utilizando el método ValidateSearchTerm
            ValidateSearchTerm(motorNum, "numero de motor");
            return motorNum;
        }

        // Método para obtener y validar el numero de serie desde la entrada del usuario
        public static string GetValidSerialNumberFromUserInput()
        {
            Console.Write("Numero de serie: ");
            string serialNum = Console.ReadLine() ?? "";
            // Valida el numero de serie utilizando el método ValidateSearchTerm
            ValidateSearchTerm(serialNum, "numero de serie");
            return serialNum;
        }

    }
}