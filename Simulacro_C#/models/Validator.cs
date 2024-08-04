using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simulacro_C_.models
{
    // Clase estática Validator que contiene métodos para validar datos de vehiculos y entradas del usuario
    public static class Validator
    {
        // Valida todas las propiedades de un vehículo
        public static void ValidateVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
                throw new ArgumentNullException("El vehiculo no puede ser nulo.");

            ValidateId(vehicle.Id);
            ValidateStringProperty(vehicle.Plate, "placa");
            ValidateStringProperty(vehicle.Type, "tipo");
            ValidateStringProperty(vehicle.EngineNumber, "numero de motor");
            ValidateStringProperty(vehicle.SerialNumber, "numero de serie");
            ValidatePeopleCapacity(vehicle.PeopleCapacity);
        }

        // Verifica que el ID no sea negativo
        public static void ValidateId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El id no puede ser negativo.");
        }

        // Asegura que la capacidad de personas no sea negativa
        public static void ValidatePeopleCapacity(byte peopleCapacity)
        {
            if (peopleCapacity < 0)
                throw new ArgumentException("La capacidad no puede ser negativa.");
        }

        // Valida que una propiedad de tipo string no esté vacía
        public static void ValidateStringProperty(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"El campo {propertyName} no puede estar vacío.");
        }

        // Obtiene y valida un ID ingresado por el usuario
        public static int GetValidIdFromUserInput()
        {
            Console.Write("Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                throw new ArgumentException("Id inválido.");
            }
            ValidateId(id);
            return id;
        }

        // Método genérico para obtener y validar una entrada de string del usuario
        public static string GetValidStringInput(string prompt, string propertyName)
        {
            Console.Write($"{prompt}: ");
            string input = Console.ReadLine() ?? "";
            ValidateStringProperty(input, propertyName);
            return input;
        }

        // Los siguientes métodos obtienen y validan inputs específicos del usuario
        public static string GetValidPlateFromUserInput()
        {
            return GetValidStringInput("Placa", "placa");
        }

        public static string GetValidTypeFromUserInput()
        {
            return GetValidStringInput("Tipo", "tipo");
        }

        // Obtiene y valida la capacidad de personas ingresada por el usuario
        public static byte GetValidPeopleCapacityFromUserInput()
        {
            Console.Write("Capacidad: ");
            if (!byte.TryParse(Console.ReadLine(), out byte capacity))
            {
                throw new ArgumentException("Capacidad inválida.");
            }
            ValidatePeopleCapacity(capacity);
            return capacity;
        }

        public static string GetValidEngineNumberFromUserInput()
        {
            return GetValidStringInput("Numero de motor", "numero de motor");
        }

        public static string GetValidSerialNumberFromUserInput()
        {
            return GetValidStringInput("Numero de serie", "numero de serie");
        }
    }
}