using System;
using System.Collections.Generic;
using System.IO;

namespace Project_Student_Management.Base.Interface
{
    public class StudentFileHandler : IFileHandler<Student>
    {
        public void SaveFromList(string filePath, List<Student> data)
        {
            var lines = new List<string>();
            foreach (var student in data)
            {
                lines.Add(student.ToString()); // ToString của Student phải trả về đúng định dạng dòng dữ liệu
            }

            File.WriteAllLines(filePath, lines);
        }

        public List<Student> LoadDataList(string filePath)
        {
            var students = new List<Student>();

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var student = Student.FromString(line); // Tạo hàm này trong lớp Student để đọc dữ liệu từ chuỗi
                    if (student != null)
                    {
                        students.Add(student);
                    }
                }
            }
            else
            {
                Console.WriteLine("File không tồn tại.");
            }

            return students;
        }
    }
}
