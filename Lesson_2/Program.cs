using System;

namespace Lesson_2
{
    [Flags]
    public enum DaysOfWeek
    {
        Понедельник = 0b_0000001,
        Вторник = 0b_0000010,
        Среда = 0b_0000100,
        Четверг = 0b_0001000,
        Пятница = 0b_0010000,
        Суббота = 0b_0100000,
        Воскресенье = 0b_1000000
    }
    class Program
    {
        static void Main(string[] args)
        {
            //1
            Console.WriteLine("Введите минимальную температуру за сутки:");
            double tempMin = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите максимальную температуру за сутки:");
            double tempMax = Convert.ToDouble(Console.ReadLine());
            double tempAvg = (tempMin + tempMax) / 2;
            Console.WriteLine($"Средняя температура за сутки составляет: {tempAvg}");
            Console.ReadLine();
            Console.Clear();

            //2
            Console.WriteLine("Введите порядковый номер месяца");
            int currrentMonth = Convert.ToInt32(Console.ReadLine());
            switch (currrentMonth)
            {
                case 1:
                    Console.WriteLine("Январь");
                    break;
                case 2:
                    Console.WriteLine("Февраль");
                    break;
                case 3:
                    Console.WriteLine("Март");
                    break;
                case 4:
                    Console.WriteLine("Апрель");
                    break;
                case 5:
                    Console.WriteLine("Май");
                    break;
                case 6:
                    Console.WriteLine("Июнь");
                    break;
                case 7:
                    Console.WriteLine("Июль");
                    break;
                case 8:
                    Console.WriteLine("Август");
                    break;
                case 9:
                    Console.WriteLine("Сентябрь");
                    break;
                case 10:
                    Console.WriteLine("Октябрь");
                    break;
                case 11:
                    Console.WriteLine("Ноябрь");
                    break;
                case 12:
                    Console.WriteLine("Декабрь");
                    break;
                default:
                    Console.WriteLine("Введен не правильный номер! (Должен быть от 1 до 12)");
                    break;
            }
            //5
            if (((currrentMonth == 1) || (currrentMonth == 2) || (currrentMonth == 12)) && (tempAvg > 0))
            {
                Console.WriteLine("Дождливая зима");
            }
            Console.ReadLine();
            Console.Clear();

            //3
            Console.WriteLine("Введите целое число");
            int number = Convert.ToInt32(Console.ReadLine());
            if ((number % 2) == 1)
            {
                Console.WriteLine("Введенное вами число нечетное.");
            }
            else
            {
                Console.WriteLine("Введенное вами число четное.");
            }
            Console.ReadLine();
            Console.Clear();

            //4
            string name = "Иван";
            string lastname = "Иванов";
            string surname = "Иванович";
            int checkNumber = 1348676;
            string goodOne = "Кирпич";
            double priceOne = 49.99;
            int countOne = 7;
            double totalOne = priceOne * countOne;
            string goodTwo = "Цемент";
            double priceTwo = 549.99;
            int countTwo = 2;
            double totalTwo = priceTwo * countTwo;

            Console.WriteLine("##########################");
            Console.WriteLine("      ООО \"Ромашка\"      ");
            Console.WriteLine("      Кассовый чек      ");
            Console.WriteLine($"    №: {checkNumber} ");
            Console.WriteLine();
            Console.WriteLine($"    Кассир: {lastname}");
            Console.WriteLine($"      {name} {surname}     ");
            Console.WriteLine();
            Console.WriteLine($"1. {goodOne}");
            Console.WriteLine($"   {priceOne} x {countOne}");
            Console.WriteLine($"Стоимость....... {totalOne}");
            Console.WriteLine($"2. {goodTwo}");
            Console.WriteLine($"   {priceTwo} x {countTwo}");
            Console.WriteLine($"Стоимость....... {totalTwo}");
            Console.WriteLine();
            Console.WriteLine($"   ИТОГО:       {totalOne + totalTwo}");
            Console.WriteLine();
            Console.WriteLine("   Спасибо за покупку!   ");
            Console.WriteLine("##########################");
            Console.ReadLine();
            Console.Clear();

            //6
            DaysOfWeek OfficeOne = (DaysOfWeek) 0b_0001110;
            DaysOfWeek OfficeTwo = (DaysOfWeek)0b_0111111;
            Console.WriteLine($"Рабочие дни первого оффиса: {OfficeOne}");
            Console.WriteLine($"Рабочие дни второго оффиса: {OfficeTwo}");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
