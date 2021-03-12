using System;
using System.IO;
using Support;

namespace Lesson_5
{
    class Program
    {
        //Запись информации в файл
        static void InputData()
        {
            string path = @"D:\TEMP\GeekBrains\lesson-5\5_1.txt";
            Console.Write("Введите данные: ");
            string data = Console.ReadLine();
            Console.Clear();
            File.AppendAllText(path, data);
            Console.WriteLine($"Данные сохнанены!");
        }
        //Запись текущего времени в файл
        static void LogTime()
        {
            string path = @"D:\TEMP\GeekBrains\lesson-5\startup.txt";
            string time = DateTime.Now.ToLongTimeString()+"\n";
            File.AppendAllText(path, time);
        }
        //Запись информации в бинарный файл
        static void InputBinData()
        {
            string path = @"D:\TEMP\GeekBrains\lesson-5\5_3.bin";
            bool isInputCorect;
            string[] data;
            //Проверка введенных чисел
            do
            {
                isInputCorect = true;
                Console.Write("Введите целые числа от 0 до 255 через пробел: ");
                data = (Console.ReadLine()).Split(' ');
                for (int i = 0; i < data.Length; i++)
                {
                    int num = Convert.ToInt32(data[i]);
                    if (num < 0 || num > 255)
                    {
                        isInputCorect = false;
                        Console.WriteLine("Неккорректный ввод! Нажмите клавишу для продолжения...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                }
            } while (isInputCorect == false);
            //Преобразование строк в байты
            byte[] byteData = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                byteData[i] = Convert.ToByte(data[i]);
            }
            //Запись в файл
            File.WriteAllBytes(path, byteData);
            Console.WriteLine($"Данные сохнанены!");


        }
        static void Main(string[] args)
        {
            //2
            LogTime();
            //1
            InputData();
            Support.Support.Next();
            //3
            InputBinData();
            Support.Support.Next();
        }
    }
}
