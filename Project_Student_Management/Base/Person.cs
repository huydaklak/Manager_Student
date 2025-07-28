using System;

namespace Project_Student_Management.Base
{
    public abstract class Person
    {
        public string FullName;
        public DateTime DateOfBirth;
        public string Gender;


        public virtual void DisplayInfo()
        {
            Console.WriteLine("Họ và tên sinh viên : {0}, Ngày sinh : {1}, Giới tính : {2} ");
        }

    }
}