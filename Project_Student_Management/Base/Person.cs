using System;

namespace Project_Student_Management.Base
{

    public abstract class Person
    {

        public string FullName;
        public DateTime DateOfBirth;
        public string Gender;

        public Person()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine("Họ và tên sinh viên : {0}, Ngày tháng năm sinh : {1}, Giới tính : {2}", FullName, DateOfBirth, Gender);
        }

    }
}