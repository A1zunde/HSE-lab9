using System;

namespace lab9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создание объекта для ввода/вывода
            GeoCoordinatesUI ui = new();

            while (true)
            {
                // Отображение меню
                ui.ShowMenu();

                // Ввод выбора пользователя
                Console.WriteLine("Введите номер действия:");
                int choice = int.Parse(Console.ReadLine());

                // Обработка выбора
                ui.HandleMenuChoice(choice);
            }
        }
    }
}