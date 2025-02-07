using System;
using static Part1;

public class GeoCoordinatesUI
{
    // Ввод координат с клавиатуры
    static GeoCoordinates InputCoordinates()
    {
        Console.WriteLine("Введите широту (latitude): ");
        double latitude = double.Parse(Console.ReadLine());

        Console.WriteLine("Введите долготу (longitude): ");
        double longitude = double.Parse(Console.ReadLine());

        return new GeoCoordinates(latitude, longitude);
    }

    // Вывод координат на экран
    static void PrintCoordinates(GeoCoordinates point)
    {
        point.PrintCoordinates();
    }

    // Работа с объектами класса GeoCoordinates
    public void Demonstrate()
    {
        Console.WriteLine("Создание первой точки:");
        GeoCoordinates point1 = InputCoordinates();

        Console.WriteLine("Создание второй точки:");
        GeoCoordinates point2 = InputCoordinates();

        Console.WriteLine("Координаты первой точки:");
        PrintCoordinates(point1);

        Console.WriteLine("Координаты второй точки:");
        PrintCoordinates(point2);

        // Вычисление расстояния между точками с использованием статической функции
        double distanceStatic = GeoCoordinates.CalculateDistance(point1, point2);
        Console.WriteLine($"Расстояние между точками (статический метод): {distanceStatic} км");

        // Вычисление расстояния между точками с использованием метода класса
        double distanceMethod = point1.DistanceTo(point2);
        Console.WriteLine($"Расстояние между точками (метод класса): {distanceMethod} км");

        // Вывод количества созданных объектов
        Console.WriteLine($"Количество созданных объектов GeoCoordinates: {GeoCoordinates.GetObjectCount()}");
    }
}