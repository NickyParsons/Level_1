using System;
using System.Text.Json;
using System.IO;

namespace Lesson_6
{
    class Program
    {
        //Метод сохранения в файл дерева файлов (задача №1)
        static void SaveDir(string dir, bool isRecursionNeeded)
        {
            if (!Directory.Exists(dir))
            {
                Console.WriteLine("Директория не существует!");
            }
            else
            {
                string[] entrires;
                string fileResultPath;
                string fileResultDir = @"D:\TEMP\GeekBrains\lesson-6\";
                if (isRecursionNeeded)
                {
                    fileResultPath = Path.Combine(fileResultDir, @"6_1_with_recursion.txt");
                    entrires = Directory.GetFileSystemEntries(dir, "*", SearchOption.AllDirectories);
                }
                else
                {
                    fileResultPath = Path.Combine(fileResultDir, @"6_1.txt");
                    entrires = Directory.GetFileSystemEntries(dir);
                }
                File.WriteAllLines(fileResultPath, entrires);
            }

        }
        //Метод чтения списка задач из Json (задача №2)
        static ToDo[] ReadTaskList(string filePath)
        {
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<ToDo[]>(jsonString);
            }
            else
            {
                return new ToDo[0];
            }
        }
        //Метод записи списка задач в Json (задача №2)
        static void WriteTaskList(string filePath, ToDo[] taskList)
        {
            string jsonString = JsonSerializer.Serialize(taskList);
            File.WriteAllText(filePath, jsonString);
        }
        //cуммирование элементов массива(задача №3)
        static int sumArray(string[ , ] array)
        {
            int sum = 0;
            if ((array.GetLength(0) == 4) && (array.GetLength(1) == 4))
            {

                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        try
                        {
                            sum += Convert.ToInt32(array[i,j]);
                        }
                        catch (Exception)
                        {
                            throw (new MyArrayDataException($"Не удалось преобразовать в Int элемент с индексом {i}, {j}"));
                        }
                    }
                }
            }
            else
            {
                throw (new MyArraySizeException());
            }
            return sum;
        }

        static void Main(string[] args)
        {
            string lessonDir = @"D:\TEMP\GeekBrains\lesson-6\"; // Директория с файлами для данного урока

            //1
            string dir = @"D:\TEMP"; // Директория для проверки в первой задаче
            SaveDir(dir, false);
            SaveDir(dir, true);
            Console.WriteLine($"Создан список файлов для директории \"{dir}\"");
            Support.Support.Next();

            //2
            ConsoleKeyInfo userChoise;
            string taskListPath = lessonDir + @"\6_2.json";
            ToDo[] savedTaskList;
            do
            {
                savedTaskList = ReadTaskList(taskListPath);
                Console.WriteLine("\nНажмите клавишу для выбора команды...");
                Console.WriteLine("    1 - показать существующие задачи");
                Console.WriteLine("    2 - создать новую задачу");
                Console.WriteLine("    3 - изменить статус задачи");
                Console.WriteLine("    Escape - пропустить");
                userChoise = Console.ReadKey();
                Console.Clear();
                switch (userChoise.Key)
                {
                    case ConsoleKey.Escape:
                        break;
                    //Показ текущих задач
                    case ConsoleKey.D1:
                        if (savedTaskList.Length == 0)
                        {
                            Console.WriteLine("Список задач пуст!");
                        }
                        else
                        {
                            for (int i = 0; i < savedTaskList.Length; i++)
                            {
                                savedTaskList[i].PrintInfo();
                            }
                        }
                        break;
                    //Добавление новой задачи
                    case ConsoleKey.D2:
                        ToDo[] newTaskList = new ToDo[savedTaskList.Length + 1];
                        for (int i = 0; i < savedTaskList.Length; i++)
                        {
                            newTaskList[i] = savedTaskList[i];
                        }
                        Console.WriteLine("Введите название задачи:");
                        newTaskList[savedTaskList.Length] = new ToDo(Console.ReadLine());
                        WriteTaskList(taskListPath, newTaskList);
                        Console.Clear();
                        Console.WriteLine("Задача создана!");
                        break;
                    //Изменения статуса задачи
                    case ConsoleKey.D3:
                        if (savedTaskList.Length == 0)
                        {
                            Console.WriteLine("Список задач пуст!");
                        }
                        else
                        {
                            for (int i = 0; i < savedTaskList.Length; i++)
                            {
                                Console.Write($" {i + 1}  ... ");
                                savedTaskList[i].PrintInfo();
                            }
                            int userNum;
                            do
                            {
                                Console.Write($"Введите порядковый номер задачи, статус которой Вы бы хотели изменить: ");
                                userNum = Convert.ToInt32(Console.ReadLine());
                                if (userNum <= 0 || userNum > savedTaskList.Length)
                                {
                                    Console.WriteLine("Указан неверный номер задачи!");
                                }
                            } while (userNum <= 0 || userNum > savedTaskList.Length);
                            savedTaskList[userNum - 1].SwitchStatus();
                            WriteTaskList(taskListPath, savedTaskList);
                            Console.Clear();
                            Console.WriteLine($"Статус задачи успешно изменен!");
                        }
                        break;
                    default:
                        Console.WriteLine($"Неизвестная команда - {userChoise.Key}!");
                        break;
                }
            } while (userChoise.Key != ConsoleKey.Escape);
            Support.Support.Next();
            //3
            string[,] arrayOfString = { { "1", "1", "1", "1" }, { "1", "1", "1", "1" }, { "1", "1", "1", "1" }, { "1", "1", "1", "1" } };
            string[,] wrongSizeArray = { { "1", "1", "1", "1" }, { "1", "1", "1", "1" }, { "1", "1", "1", "1" } };
            string[,] wrongDataArray = { { "1", "symbol", "1", "c" }, { "1", "-0.5", "1", "1" }, { "1", "0x0f", "1", "1" }, { "1", "symbol", "1", "c" } };
            Console.WriteLine("Вызов метода с передачей массива неправильного размера:");
            try
            {
                Console.WriteLine(sumArray(wrongSizeArray));
            }
            catch (MyArrayDataException ex)
            {
                Console.WriteLine($"Неверные данные в массиве! Исключение: \n{ex} \n{ex.MyMessage}");
            }
            catch (MyArraySizeException ex)
            {
                Console.WriteLine($"Неверный размер массива! Исключение: \n{ex}");
            }
            Support.Support.Next();
            Console.WriteLine("Вызов метода с передачей массива с неправильными данными:");
            try
            {
                Console.WriteLine(sumArray(wrongDataArray));
            }
            catch (MyArrayDataException ex)
            {
                Console.WriteLine($"Неверные данные в массиве! Исключение: \n{ex} \n{ex.MyMessage}");
            }
            catch (MyArraySizeException ex)
            {
                Console.WriteLine($"Неверный размер массива! Исключение: \n{ex}");
            }
            Support.Support.Next();
            Console.WriteLine("Вызов метода с передачей правильного массива:");
            try
            {
                Console.WriteLine(sumArray(arrayOfString));
            }
            catch (MyArrayDataException ex)
            {
                Console.WriteLine($"Неверные данные в массиве! Исключение: \n{ex} \n{ex.MyMessage}");
            }
            catch (MyArraySizeException ex)
            {
                Console.WriteLine($"Неверный размер массива! Исключение: \n{ex}");
            }
            Support.Support.Next();
            //4
            Employee[] array = new Employee[5];
            array[0] = new Employee("Ivanov Ivan", "Engineer", "ivivan@mailbox.com", "892312312", 888, 30);
            array[1] = new Employee("Sidorov Alexey", "Manager", "Sidorov@mailbox.com", "892312312", 999, 19);
            array[2] = new Employee("Payne Max", "Cleaner", "Payne@mailbox.com", "892312312", 470, 42);
            array[3] = new Employee("Bowie David", "Senjor Engineer", "BowieDavid@mailbox.com", "892312312", 1000, 47);
            array[4] = new Employee("Billy Herrington", "Boss of the Gym", "NoLeathermen@mailbox.com", "892312312", 300, 41);
            foreach (Employee employee in array)
            {
                if (employee.Age > 40)
                {
                    employee.PrintInfo();
                }
            }
        }
    }
}
