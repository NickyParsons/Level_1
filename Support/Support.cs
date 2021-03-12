using System;

namespace Support
{
    static public class Support
    {
        //Переход к следующему заданию
        public static void Next()
        {
            Console.WriteLine("\nНажмите Enter для продолжения...");
            Console.ReadLine();
            Console.Clear();
        }

        //Распечатать элементы массива
        public static void PrintAray<T>(T[] array)
        {
            Console.Write("Массив: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                if (i < array.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write(";");
        }
    }
}
