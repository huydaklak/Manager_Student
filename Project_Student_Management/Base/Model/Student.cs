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

            Console.WriteLine("");
            Console.WriteLine("ID sinh viên : {0}, Lớp học : {1}, Điểm trung bình : {2} ", StudentId, ClassName, GPA);
        }

        public int GetAge()
        {
            var today = DateTime.Today;
            int age = today.Year - DateOfBirth.Year;
            if (DateOfBirth > today.AddYears(-age)) age--;  //  chưa đến sinh nhật năm nay thì trừ đi 1
            return age;
        }

        public override string ToString()
        {
            //return $"{StudentId}|{FullName}|{DateOfBirth.ToString("dd/MM/yyyy")}|{Gender}|{GPA}|{ClassName}";
            return $"{StudentId}|{FullName}|{DateOfBirth:dd/MM/yyyy}|{Gender}|{GPA}|{ClassName}";
        }

        public static Student FromString(string line)
        {
            try
            {
                var parts = line.Split('|');
                if (parts.Length == 6)
                {
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
                else
                {
                    Console.WriteLine("⚠ Dữ liệu sai định dạng (không đủ 6 phần): " + line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi đọc dòng: {line}");
                Console.WriteLine($"Chi tiết lỗi: {ex.Message}");
            }

            return null;

        }
    }
}
