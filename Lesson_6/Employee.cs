using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_6
{
    public class Employee
    {
        public string FIO { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public double Salary { get; set; }
        public int Age { get; set; }
        public Employee(string fio, string pos, string email, string phone, double salary, int age)
        {
            this.FIO = fio;
            this.Position = pos;
            this.Email = email;
            this.Phone = phone;
            this.Salary = salary;
            this.Age = age;
        }
        public void PrintInfo()
        {
            Console.WriteLine($"ФИО: {this.FIO}");
            Console.WriteLine($"Должность: {this.Position}");
            Console.WriteLine($"E-Mail: {this.Email}");
            Console.WriteLine($"Телефон: {this.Phone}");
            Console.WriteLine($"Зарплата: {this.Salary}$");
            Console.WriteLine($"Возраст: {this.Age}");
            Console.WriteLine();
        }
    }
}
