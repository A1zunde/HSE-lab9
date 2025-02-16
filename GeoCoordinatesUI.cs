using System;

using System;

public class GeoCoordinatesUI
{
    // Точки для демонстрации
    private GeoCoordinates point1;
    private GeoCoordinates point2;
    private GeoCoordinatesArray collection;

    // Метод для ввода координат с клавиатуры
    public GeoCoordinates InputCoordinates()
    {
        Console.WriteLine("Введите широту (latitude): ");
        double latitude = double.Parse(Console.ReadLine());

        Console.WriteLine("Введите долготу (longitude): ");
        double longitude = double.Parse(Console.ReadLine());

        return new GeoCoordinates(latitude, longitude);
    }

    // Метод для вывода координат на экран
    public void PrintCoordinates(GeoCoordinates point)
    {
        Console.WriteLine($"Latitude: {point.Latitude}, Longitude: {point.Longitude}");
    }

    // Метод для вывода всех точек в коллекции
    public void PrintCollection()
    {
        if (collection == null)
        {
            Console.WriteLine("Коллекция не создана.");
            return;
        }

        for (int i = 0; i < collection.Length; i++)
        {
            Console.WriteLine($"Точка {i}:");
            PrintCoordinates(collection[i]);
        }
    }

    // Метод для демонстрации работы с объектами класса GeoCoordinates
    public void Demonstrate()
    {
        Console.WriteLine("Демонстрационная программа:");

        // Пример точек
        point1 = new GeoCoordinates(55.7558, 37.6176); // Москва
        point2 = new GeoCoordinates(59.9343, 30.3351); // Санкт-Петербург

        Console.WriteLine("Точка 1 (Москва):");
        PrintCoordinates(point1);

        Console.WriteLine("Точка 2 (Санкт-Петербург):");
        PrintCoordinates(point2);

        // Вычисление расстояния между точками
        double distance = point1.DistanceTo(point2);
        Console.WriteLine($"Расстояние между Москвой и Санкт-Петербургом: {distance} км");

        // Создание коллекции
        collection = new GeoCoordinatesArray(3);
        Console.WriteLine("Создана коллекция из 3 случайных точек:");
        PrintCollection();

        // Добавление точки 1 в коллекцию
        Console.WriteLine("Добавление точки 1 в коллекцию:");
        GeoCoordinatesArray newCollection = new GeoCoordinatesArray(collection.Length + 1);

        for (int i = 0; i < collection.Length; i++)
        {
            newCollection[i] = collection[i];
        }

        newCollection[collection.Length] = point1;
        collection = newCollection;
        PrintCollection();
    }

    // Метод для отображения меню
    public void ShowMenu()
    {
        Console.WriteLine("\nМеню:");
        Console.WriteLine("1. Ввести координаты для точки 1");
        Console.WriteLine("2. Ввести координаты для точки 2");
        Console.WriteLine("3. Измерить расстояние между точками 1 и 2");
        Console.WriteLine("4. Запустить демонстрационную программу");
        Console.WriteLine("5. Создать новую коллекцию");
        Console.WriteLine("6. Добавить точку 1 в коллекцию");
        Console.WriteLine("7. Вывести текущие точки и коллекцию");
        Console.WriteLine("8. Завершить программу");
    }

    // Метод для обработки выбора пользователя
    public void HandleMenuChoice(int choice)
    {
        switch (choice)
        {
            case 1:
                point1 = InputCoordinates();
                Console.WriteLine("Точка 1 успешно создана.");
                break;
            case 2:
                point2 = InputCoordinates();
                Console.WriteLine("Точка 2 успешно создана.");
                break;
            case 3:
                if (point1 == null || point2 == null)
                {
                    Console.WriteLine("Ошибка: точки 1 и 2 должны быть созданы.");
                    return;
                }
                double distance = point1.DistanceTo(point2);
                Console.WriteLine($"Расстояние между точками: {distance} км");
                break;
            case 4:
                Demonstrate();
                break;
            case 5:
                Console.WriteLine("Введите размер коллекции:");
                int size = int.Parse(Console.ReadLine());
                collection = new GeoCoordinatesArray(size);
                Console.WriteLine("Коллекция успешно создана.");
                break;
            case 6:
                if (point1 == null)
                {
                    Console.WriteLine("Ошибка: точка 1 не создана.");
                    return;
                }
                if (collection == null)
                {
                    Console.WriteLine("Ошибка: коллекция не создана.");
                    return;
                }
                GeoCoordinatesArray newCollection = new GeoCoordinatesArray(collection.Length + 1);
                for (int i = 0; i < collection.Length; i++)
                {
                    newCollection[i] = collection[i];
                }
                newCollection[collection.Length] = point1;
                collection = newCollection;
                Console.WriteLine("Точка 1 успешно добавлена в коллекцию.");
                break;
            case 7:
                Console.WriteLine("Точка 1:");
                if (point1 != null)
                    PrintCoordinates(point1);
                else
                    Console.WriteLine("Точка 1 не создана.");

                Console.WriteLine("Точка 2:");
                if (point2 != null)
                    PrintCoordinates(point2);
                else
                    Console.WriteLine("Точка 2 не создана.");

                Console.WriteLine("Коллекция:");
                PrintCollection();
                break;
            case 8:
                Console.WriteLine("Завершение программы...");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Неверный выбор. Попробуйте снова.");
                break;
        }
    }
}