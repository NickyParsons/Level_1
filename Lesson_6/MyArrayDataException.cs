using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_6
{
    public class MyArrayDataException : Exception
    {
        public string MyMessage { get; set; }
        
        public MyArrayDataException(string message)
        {
            this.MyMessage = message;
        }
    }
}
