using System;

namespace Lesson_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            //Создаем двумерный массив 5x5
            int[,] matrix = { { 1, 2, 3, 4, 5 }, { 4, 8, 15, 16, 23 }, { 42, -1, 0, 10, -6 }, { 6, 12, -40, 10, 50 }, { 9, 10, 7, 6, 5 } };

            //выводим исходный массив
            Console.WriteLine("Исходный массив:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($" {matrix[i, j]} ");
                }
                Console.WriteLine();
            }

            //выводим элементы по диагонали
            Console.WriteLine("Элементы по диагонали:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        for (int count = 0; count < i; count++)
                        {
                            Console.Write("  ");
                        }
                        Console.Write($"{matrix[i, j]}");
                    }

                }
                Console.WriteLine();
            }

            //Переход к следующему заданию
            Console.WriteLine("Нажмите Enter для продолжения...");
            Console.ReadLine();
            Console.Clear();

            //2
            // Создаем исходный массив
            string[][] phoneBook = new string[5][];
            phoneBook[0] = new string[2];
            phoneBook[0][0] = "John";
            phoneBook[0][1] = "+13(555)431-5446";
            phoneBook[1] = new string[2];
            phoneBook[1][0] = "Ivan";
            phoneBook[1][1] = "+7(977)952-9903";
            phoneBook[2] = new string[2];
            phoneBook[2][0] = "Frodo";
            phoneBook[2][1] = "SHire@mordor.com";
            phoneBook[3] = new string[2];
            phoneBook[3][0] = "KD9 3.7";
            phoneBook[3][1] = "blade_runner@la.com";
            phoneBook[4] = new string[2];
            phoneBook[4][0] = "Shiva";
            phoneBook[4][1] = "+9013(37)203213";

            //выводим на консоль
            for (int i = 0; i < phoneBook.GetLength(0); i++)
            {
                Console.Write($"{phoneBook[i][0]}  .........  {phoneBook[i][1]}\n");
            }

            //Переход к следующему заданию
            Console.WriteLine("Нажмите Enter для продолжения...");
            Console.ReadLine();
            Console.Clear();

            //3
            Console.Write("Введите строку: ");
            string str = Console.ReadLine();
            Console.Write("Инвертированная строка: ");
            for (int i = str.Length - 1; i >= 0; i--)
            {
                Console.Write(str[i]);
            }
            Console.WriteLine();

            //Переход к следующему заданию
            Console.WriteLine("Нажмите Enter для продолжения...");
            Console.ReadLine();
            Console.Clear();

            //Морской бой
            //Заполнение пустыми символами
            string[,] seaWar = new string[10, 10];
            for (int y = 0; y < seaWar.GetLength(0); y++)
            {
                for (int x = 0; x < seaWar.GetLength(1); x++)
                {
                    seaWar[x, y] = ".";
                }
            }
            //заполнение кораблями
            for (int i = 2; i < 6; i++)
            {
                seaWar[2, i] = "X";
            }
            for (int i = 3; i < 6; i++)
            {
                seaWar[i, 0] = "X";
            }
            for (int i = 2; i < 5; i++)
            {
                seaWar[7, i] = "X";
            }
            for (int i = 1; i < 3; i++)
            {
                seaWar[i, 9] = "X";
            }
            for (int i = 4; i < 6; i++)
            {
                seaWar[5, i] = "X";
            }
            for (int i = 7; i < 9; i++)
            {
                seaWar[9, i] = "X";
            }
            seaWar[0, 2] = "X";
            seaWar[0, 4] = "X";
            seaWar[7, 7] = "X";
            seaWar[9, 0] = "X";

            //Вывод игрового поля
            Console.Write("--------------------------------\n");
            for (int y = 0; y < seaWar.GetLength(0); y++)
            {
                Console.Write("|");
                for (int x = 0; x < seaWar.GetLength(1); x++)
                {
                    Console.Write($" {seaWar[x, y]} ");
                }
                Console.Write("|\n");
            }
            Console.Write("--------------------------------\n");
            Console.WriteLine("Нажмите Enter для продолжения...");
            Console.ReadLine();
            Console.Clear();

            //4
            //Ввод исходных данных
            int massSize;
            do
            {
                Console.Clear();
                Console.Write("Введите размерность массива: ");
                massSize = Convert.ToInt32(Console.ReadLine());
            } while (massSize <= 0);
            int[] mass = new int[massSize];
            for (int i = 0; i < mass.Length; i++)
            {
                Console.Write($"Введите элемент массива №{i + 1}: ");
                mass[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("Введите колличество сдвигов: ");
            int shift = Convert.ToInt32(Console.ReadLine());

            //Вывод исходного массива
            Console.Clear();
            Console.WriteLine("Исходный массив: ");
            for (int i = 0; i < mass.Length; i++)
            {
                Console.Write($"{mass[i]} ");
            }

            //Логика сдвига
            if (shift != 0)
            {
                if (shift > 0)
                {
                    for (int count = 1; count <= shift; count++)
                    {
                        int temp = mass[mass.Length - 1];
                        for (int i = mass.Length - 1; i > 0; i--)
                        {
                            mass[i] = mass[i - 1];
                        }
                        mass[0] = temp;
                    }
                }
                else
                {
                    for (int count = -1; count >= shift; count--)
                    {
                        int temp = mass[0];
                        for (int i = 0; i < mass.Length - 1; i++)
                        {
                            mass[i] = mass[i + 1];
                        }
                        mass[mass.Length - 1] = temp;
                    }
                }
            }

            //Вывод измененного массива
            Console.WriteLine("\nИзмененный массив: ");
            for (int i = 0; i < mass.Length; i++)
            {
                Console.Write($"{mass[i]} ");
            }
            //Конец
            Console.WriteLine("\nНажмите Enter для продолжения...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
