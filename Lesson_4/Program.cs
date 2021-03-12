using System;

namespace Lesson_4
{
    public enum Seasons
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }
    class Program
    {
        
        // Метод принимающий ФИО пожлементно и возвращающий ФИО единой строкой.
        static string GetFio(string firstName, string lastName, string patronymic)
        {
            return lastName + " " + firstName + " " + patronymic;
        }

        // Сумма целых чисел из строки.
        static int GetSum (string str)
        {
            int summa = 0;
            string tempStr = null;
            bool isNumDone = false;

            for (int i = 0; i < str.Length; i++)
            {
                //проверяем не пробел ли
                if (str[i] != ' ')
                //если не пробел
                {
                    //проверяем не последний ли символ
                    if (i >= str.Length - 1)
                    //если символ был последним
                    {
                        tempStr += str[i];
                        isNumDone = true;
                    }
                    //если символ был не последним
                    else
                    {
                        tempStr += str[i];
                    }
                }
                else
                //если пробел
                {
                    isNumDone = true;
                }
                
                //прибавляем к сумме, если число завершилось
                if (isNumDone == true)
                {
                    if(tempStr != null)
                        summa += Convert.ToInt32(tempStr);
                    tempStr = null;
                    isNumDone = false;
                }
            }

            return summa;
        }

        //Ввод и проверка номера месяца
        static int InputMonth()
        {
            int month;
            do
            {
                Console.WriteLine("Введите номер месяца:");
                month = Convert.ToInt32(Console.ReadLine());
                if ((month < 1) || (month > 12))
                {
                    Console.WriteLine("Неверный номер месяца! Должен быть от 1 до 12!");
                }
            }
            while ((month < 1) || (month > 12));
            return month;
        }
        
        //Определение времени года
        static Seasons GetSeason(int monthNum)
        {
            Seasons season;
            switch (monthNum)
            {
                case 1:
                case 2:
                    season = Seasons.Winter;
                    break;
                case 3:
                case 4:
                case 5:
                    season = Seasons.Spring;
                    break;
                case 6:
                case 7:
                case 8:
                    season = Seasons.Summer;
                    break;
                case 9:
                case 10:
                case 11:
                    season = Seasons.Autumn;
                    break;
                case 12:
                    season = Seasons.Winter;
                    break;
                default:
                    season = Seasons.Winter;
                    break;
            }
            return season;
        }
        //Вывод названия времени года
        static void PrintSeason(Seasons season)
        {
            switch (season)
            {
                case Seasons.Winter:
                    Console.WriteLine("Зима");
                    break;
                case Seasons.Spring:
                    Console.WriteLine("Весна");
                    break;
                case Seasons.Summer:
                    Console.WriteLine("Лето");
                    break;
                case Seasons.Autumn:
                    Console.WriteLine("Осень");
                    break;
                default:
                    Console.WriteLine("Неизвестно");
                    break;
            }
        }
        //Fibonacci 
        static int Fibonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }

        static void Main(string[] args)
        {
            //1
            string name1 = "Иван";
            string lastname1 = "Иванов";
            string patronymic1 = "Иванович";
            string name2 = "Петр";
            string lastname2 = "Петров";
            string patronymic2 = "Петрович";
            string name3 = "Александр";
            string lastname3 = "Сидоров";
            string patronymic3 = "Александрович";
            Console.WriteLine(GetFio(name1, lastname1, patronymic1));
            Console.WriteLine(GetFio(name2, lastname2, patronymic2));
            Console.WriteLine(GetFio(name3, lastname3, patronymic3));
            Support.Support.Next();

            //2
            Console.WriteLine("Введите целые числа через пробел");
            string nums = Console.ReadLine();
            Console.Write("Сумма элементов: ");
            Console.WriteLine(GetSum(nums));
            Support.Support.Next();

            //3
            int currentMonth = InputMonth();
            Seasons season = GetSeason(currentMonth);
            PrintSeason(season);
            Support.Support.Next();

            //4
            Fibonacci(5);
        }
    }
}
