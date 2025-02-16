using System;

public class GeoCoordinates
{
    // Закрытые атрибуты
    public double latitude;
    public double longitude;

    // Статическая переменная для подсчета количества созданных объектов
    public static int objectCount = 0;

    // Свойства для доступа к широте
    public double Latitude
    {
        get { return latitude; }
        set
        {
            if (value < -90 || value > 90)
                throw new ArgumentOutOfRangeException("Ошибка! Широта может принимать значения между -90 и 90 градусами");
            latitude = value;
        }
    }

    // Свойство для доступа к долготе
    public double Longitude
    {
        get { return longitude; }
        set
        {
            if (value < -180 || value > 180)
                throw new ArgumentOutOfRangeException("Ошибка! Долгота может принимать значения между -180 и 180 градусами");
            longitude = value;
        }
    }

    // Конструктор без параметров
    public GeoCoordinates()
    {
        Latitude = 0;
        Longitude = 0;
        objectCount++;
    }

    // Конструктор с параметрами
    public GeoCoordinates(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
        objectCount++;
    }

    // Метод класса для вычисления расстояния до другой точки
    public double DistanceTo(GeoCoordinates other)
    {
        return CalculateDistance(this, other);
    }

    // Вспомогательная функция для перевода градусов в радианы
    private static double DegreesToRadians(double degrees)
    {
        return degrees * Math.PI / 180.0;
    }

    // Вычисление расстояния между двумя точками
    public static double CalculateDistance(GeoCoordinates pointOrigin, GeoCoordinates pointDestination)
    {
        // Радиус Земли
        const double EarthRadius = 6371.0;

        // Координаты точки начала
        double latitudeOrigin = DegreesToRadians(pointOrigin.Latitude);
        double longitudeOrigin = DegreesToRadians(pointOrigin.Longitude);

        // Координаты конечной точки
        double latitudeDestination = DegreesToRadians(pointDestination.Latitude);
        double longitudeDestination = DegreesToRadians(pointDestination.Longitude);

        // Разница между координатами начала и конца (расстояние)
        double distanceLatitude = latitudeDestination - latitudeOrigin;
        double distanceLongitude = longitudeDestination - longitudeOrigin;

        double a = Math.Sin(distanceLatitude / 2) * Math.Sin(distanceLatitude / 2) +
                   Math.Cos(latitudeOrigin) * Math.Cos(latitudeDestination) *
                   Math.Sin(distanceLongitude / 2) * Math.Sin(distanceLongitude / 2);

        double c = 2 * Math.Asin(Math.Sqrt(a));

        return Math.Round(EarthRadius * c, 3);
    }


    // Статический метод для получения количества созданных объектов
    public static int GetObjectCount()
    {
        return objectCount;
    }
}
