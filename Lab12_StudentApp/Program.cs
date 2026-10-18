using System;

namespace Lab12_StudentApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Лабораторна робота №12 (Композиція: виклик методів внутрішніх об'єктів) ---\n");

            // Крок 1. Створіть автомобіль. Виведіть, скільки шин спущено (CountFlatWheels)
            // і чи готове авто до поїздки (IsReadyToDrive).
            Car car = new Car("Toyota");
            Console.WriteLine($"Крок 1. Спущених шин: {car.CountFlatWheels()}. Готове до поїздки: {car.IsReadyToDrive()}");

            // Крок 2. Спробуйте завести двигун, поки водія немає (виведіть результат TryStartEngine).
            // Створіть водія, посадіть його в авто й заведіть двигун ще раз.
            Console.WriteLine($"Крок 2. Запуск двигуна без водія: {car.TryStartEngine()}");
            car.CarDriver = new Driver("Микита", 5);
            Console.WriteLine($"Запуск двигуна з водієм: {car.TryStartEngine()}");

            // Крок 3. Проїдьте 100 км. Виведіть результат Drive і показання одометра (Mileage).
            Console.WriteLine($"Крок 3. Проїхали: {car.Drive(100)} км. Одометр: {car.Mileage} км.");

            // Крок 4. Прокол: car.Wheels[2].Puncture();
            // Виведіть кількість спущених шин, IsReadyToDrive і результат спроби проїхати 10 км.
            car.Wheels[2].Puncture();
            Console.WriteLine($"Крок 4. Прокол! Спущених шин: {car.CountFlatWheels()}. Готове до поїздки: {car.IsReadyToDrive()}");
            Console.WriteLine($"Спроба проїхати 10 км з проколом: {car.Drive(10)} км.");

            // Крок 5. Ремонт: замініть колесо (ReplaceWheel) на нове Wheel(16).
            // Виведіть, чи було зняте колесо спущеним, і чи знову готове авто до поїздки.
            // Проїдьте ще 50 км і виведіть Mileage.
            Wheel oldWheel = car.ReplaceWheel(2, new Wheel(16));
            Console.WriteLine($"Крок 5. Ремонт. Чи було зняте колесо спущеним: {oldWheel.IsFlat}");
            Console.WriteLine($"Готове до поїздки після ремонту: {car.IsReadyToDrive()}");
            car.Drive(50);
            Console.WriteLine($"Проїхали ще 50 км. Одометр: {car.Mileage} км.");

            // Крок 6. Передбач і спостерігай:
            // а) приберіть водія (RemoveDriver)
            car.RemoveDriver();

            // б) обгорніть у try / catch (NullReferenceException) і виведіть ex.GetType().Name;
            try
            {
                Console.WriteLine(car.CarDriver.Introduce());
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"Крок 6. Спіймано виняток: {ex.GetType().Name}");
            }

            // в) виведіть безпечну версію з ?. та ??, щоб без водія виводилося "Водія немає".
            Console.WriteLine($"Безпечний виклик: {car.CarDriver?.Introduce() ?? "Водія немає"}");

            Console.WriteLine("\nЯкщо все працює без помилок — завантажуйте файли на GitHub!");
            Console.ReadLine();
        }
    }
}