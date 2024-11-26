using System;
using System.Collections;
using System.Collections.Generic;

namespace VehicleApp
{
    // Базовий клас для транспортних засобів
    public class Vehicle
    {
        public string Name { get; set; } // Назва транспортного засобу
        public int Speed { get; set; } // Швидкість транспортного засобу

        // Конструктор для ініціалізації атрибутів
        public Vehicle(string name, int speed)
        {
            Name = name; // Присвоєння назви
            Speed = speed; // Присвоєння швидкості
        }

        // Метод для відображення інформації про транспортний засіб
        public override string ToString()
        {
            return $"Name: {Name}, Speed: {Speed} km/h"; // Повертає рядок з інформацією
        }
    }

    // Клас Plain, що наслідує Vehicle
    public class Plain : Vehicle
    {
        public int Altitude { get; set; } // Висота польоту

        // Конструктор для ініціалізації атрибутів
        public Plain(string name, int speed, int altitude) : base(name, speed)
        {
            Altitude = altitude; // Присвоєння висоти
        }

        // Метод для відображення інформації про літак
        public override string ToString()
        {
            return base.ToString() + $", Altitude: {Altitude} m"; // Додає висоту до інформації
        }
    }

    // Клас Car, що наслідує Vehicle
    public class Car : Vehicle
    {
        public string Model { get; set; } // Модель автомобіля

        // Конструктор для ініціалізації атрибутів
        public Car(string name, int speed, string model) : base(name, speed)
        {
            Model = model; // Присвоєння моделі
        }

        // Метод для відображення інформації про автомобіль
        public override string ToString()
        {
            return base.ToString() + $", Model: {Model}"; // Додає модель до інформації
        }
    }

    // Клас Ship, що наслідує Vehicle
    public class Ship : Vehicle
    {
        public int CargoCapacity { get; set; } // Вантажопідйомність корабля

        // Конструктор для ініціалізації атрибутів
        public Ship(string name, int speed, int cargoCapacity) : base(name, speed)
        {
            CargoCapacity = cargoCapacity; // Присвоєння вантажопідйомності
        }

        // Метод для відображення інформації про корабель
        public override string ToString()
        {
            return base.ToString() + $", Cargo Capacity: {CargoCapacity} tons"; // Додає вантажопідйомність до інформації
        }
    }

    // Клас VehicleCollection для зберігання колекції транспортних засобів
    public class VehicleCollection
    {
        // Використання SortedList для зберігання транспортних засобів за назвою
        private SortedList<string, Vehicle> vehiclesList = new SortedList<string, Vehicle>();
        // Використання Generic SortedList для зберігання транспортних засобів за швидкістю
        private SortedList<int, Vehicle> vehiclesGenericList = new SortedList<int, Vehicle>();

        // Метод для додавання транспортного засобу до колекції
        public void AddVehicle(Vehicle vehicle)
        {
            // Додає транспортний засіб до обох колекцій
            vehiclesList.Add(vehicle.Name, vehicle);
            vehiclesGenericList.Add(vehicle.Speed, vehicle);
        }

        // Метод для перебору та відображення всіх транспортних засобів у колекції
        public void DisplayAllVehicles()
        {
            Console.WriteLine("All Vehicles (SortedList):");
            // Перебір і відображення всіх транспортних засобів в SortedList
            foreach (var vehicle in vehiclesList)
            {
                Console.WriteLine(vehicle.Value); // Виводить інформацію про кожний транспортний засіб
            }

            Console.WriteLine("\nAll Vehicles (Generic SortedList):");
            // Перебір і відображення всіх транспортних засобів в Generic SortedList
            foreach (var vehicle in vehiclesGenericList)
            {
                Console.WriteLine(vehicle.Value); // Виводить інформацію про кожний транспортний засіб
            }
        }

        // Метод для відображення інформації про конкретний транспортний засіб за назвою
        public void DisplayVehicle(string name)
        {
            // Спробувати отримати транспортний засіб за назвою
            if (vehiclesList.TryGetValue(name, out Vehicle vehicle))
            {
                Console.WriteLine($"Found Vehicle: {vehicle}"); // Якщо знайдено, відобразити інформацію
            }
            else
            {
                Console.WriteLine("Vehicle not found."); // Якщо не знайдено, вивести повідомлення
            }
        }
    }

    // Головний клас програми
    class Program
    {
        static void Main(string[] args)
        {
            // Створення нового екземпляра VehicleCollection
            VehicleCollection vehicleCollection = new VehicleCollection();

            // Додавання транспортних засобів до колекції
            vehicleCollection.AddVehicle(new Plain("Boeing 747", 900, 10000));
            vehicleCollection.AddVehicle(new Car("Tesla Model S", 250, "Model S"));
            vehicleCollection.AddVehicle(new Ship("Titanic", 50, 3000));

            // Відображення всіх транспортних засобів у колекції
            vehicleCollection.DisplayAllVehicles();

            // Відображення інформації про конкретний транспортний засіб за назвою
            vehicleCollection.DisplayVehicle("Tesla Model S");
        }
    }
}

