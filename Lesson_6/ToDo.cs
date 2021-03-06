using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_6
{
    class ToDo
    {
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public ToDo()
        {
            this.Title = "Новая задача";
            this.IsDone = false;
        }
        public ToDo(string title) : base()
        {
            this.Title = title;
        }
        public void PrintInfo()
        {
            if (this.IsDone)
            {
                Console.WriteLine($"[ X ] {this.Title}");
            }
            else
            {
                Console.WriteLine($"[   ] {this.Title}");
            }

        }
        public void CloseTask()
        {
            this.IsDone = true;
        }
        public void SwitchStatus()
        {
            this.IsDone = this.IsDone ? false : true;
        }
    }
}
