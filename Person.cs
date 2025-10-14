using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLab4Andre
{
    abstract class Person
    {
        public int studentID;
        public string studentName;
        public int studentAge;
        public string studentDateOfBirth;
        public char studentGender;
        public int studentYearOfRegister;
        abstract public void DisplayInfo();
    }
}
