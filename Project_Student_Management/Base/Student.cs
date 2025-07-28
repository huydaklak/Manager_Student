using System;

namespace Project_Student_Management.Base
{
    public class Student : Person
    {
        public string StudentId;
        public string ClassName;
        public double GPA;


        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("Họ và tên sinh viên : {0}, Ngày tháng năm sinh : {1}, Giới tính : {2}", FullName, DateOfBirth, Gender);
            Console.WriteLine("");
            Console.WriteLine("ID sinh viên : {0}, Lớp học : {1}, Điểm trung bình : {2} ", StudentId, ClassName, GPA);
        }

        public override string ToString()
        {
            return $"{StudentId}|{FullName}|{DateOfBirth.ToString("dd/MM/yyyy")}|{Gender}|{GPA}|{ClassName}";
        }

        public static Student FromString(string line)
        {
            var parts = line.Split('|');
            return new Student
            {
                StudentId = parts[0],
                FullName = parts[1],
                DateOfBirth = DateTime.ParseExact(parts[2], "dd/MM/yyyy", null),
                Gender = parts[3],
                GPA = double.Parse(parts[4]),
                ClassName = parts[5]
            };
        }
    }
}