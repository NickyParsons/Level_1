using System;

namespace Lesson_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите своё имя:");
            string userName = Console.ReadLine();
            string date = DateTime.Now.ToString("dd.MM.yyyy");
            Console.WriteLine($"Привет, {userName}, сегодня {date}");
        }
    }
}
