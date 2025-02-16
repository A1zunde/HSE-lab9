using System;

public class GeoCoordinatesArray
{
    // Поле для хранения массива объектов GeoCoordinates
    private GeoCoordinates[] arr;

    // Статическая переменная для подсчета количества созданных коллекций
    private static int collectionCount = 0;

    // Конструктор без параметров
    public GeoCoordinatesArray()
    {
        arr = new GeoCoordinates[0]; // Пустой массив
        collectionCount++;
    }

    // Конструктор с параметрами (заполнение случайными значениями)
    public GeoCoordinatesArray(int size)
    {
        arr = new GeoCoordinates[size];
        Random random = new Random();
        for (int i = 0; i < size; i++)
        {
            double latitude = random.Next(-90, 91) + random.NextDouble();
            double longitude = random.Next(-180, 181) + random.NextDouble();
            arr[i] = new GeoCoordinates(latitude, longitude);
        }
        collectionCount++;
    }

    // Копирование
    public GeoCoordinatesArray(GeoCoordinatesArray other)
    {
        arr = new GeoCoordinates[other.arr.Length];
        for (int i = 0; i < other.arr.Length; i++)
        {
            arr[i] = new GeoCoordinates(other.arr[i].Latitude, other.arr[i].Longitude);
        }
        collectionCount++;
    }

    // Доступ к элементам массива
    public GeoCoordinates this[int index]
    {
        get
        {
            if (index < 0 || index >= arr.Length)
                throw new IndexOutOfRangeException("Индекс выходит за пределы массива.");
            return arr[index];
        }
        set
        {
            if (index < 0 || index >= arr.Length)
                throw new IndexOutOfRangeException("Индекс выходит за пределы массива.");
            arr[index] = value;
        }
    }

    // Получение размера массива
    public int Length => arr.Length;

    // Получение количества созданных коллекций
    public static int GetCollectionCount()
    {
        return collectionCount;
    }
}