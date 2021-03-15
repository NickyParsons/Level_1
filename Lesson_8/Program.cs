using System;
using System.Diagnostics;
using System.Threading;
using Support;

namespace Lesson_8
{
    class Program
    {
        static Process[] processes;
        static int choisenNum;
        static void ShowProcesses()
        {
            processes = Process.GetProcesses();
            for (int i = 0; i < processes.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {processes[i].ProcessName}");
            }
        }
        static bool IsInputNum(string str)
        {
            try
            {
                choisenNum = Convert.ToInt32(str);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        static void Main()
        {

            while (true)
            {
                Console.Clear();
                //Задание №2
                Support.Support.Greeting();
                Console.WriteLine();
                //Задание №1
                ShowProcesses();
                Console.Write("\nВведите номер или имя процесса, который Вы желаете завершить. Или exit для завершения программы: ");
                string userCommand = Console.ReadLine();
                if (userCommand == "exit")
                {
                    break;
                }
                else
                {
                    if (IsInputNum(userCommand))
                    {
                        processes[choisenNum-1].Kill();
                        Thread.Sleep(100);
                    }
                    else
                    {
                        Process[] choisenProcesses = Process.GetProcessesByName(userCommand);
                        foreach (Process item in choisenProcesses)
                        {
                            item.Kill();
                        }
                        Thread.Sleep(100);
                    }
                }  
            }
        }
    }
}
