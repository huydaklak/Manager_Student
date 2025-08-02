using System;
using System.Collections.Generic;
using System.IO;

namespace Project_Student_Management.Base.Interface
{
    public class DataFileHandler : IFileHandler<Student>
    {
        private string filePath = "D:\\c#\\Project_Student_Management\\Project_Student_Management\\Student.txt";

        public void SaveFromList(List<Student> data)
        {
            var lines = new List<string>();
            foreach (var student in data)
            {
                lines.Add(student.ToString()); // ToString của Student phải trả về đúng định dạng dòng dữ liệu
            }

            File.WriteAllLines(filePath, lines);
        }

        public List<Student> LoadDataList()
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

        public void ChangeFilePathData(string newFath)
        {
            if (string.IsNullOrEmpty(newFath))
            {
                Console.WriteLine("Đường dẫn không hợp lệ.");
                return;
            }
            filePath = newFath;
            Console.WriteLine($"Đường dẫn tệp đã được thay đổi thành: {filePath}");
        }

        public void ShowFilePathData()
        {
            if (string.IsNullOrEmpty(filePath))
            {
                Console.WriteLine("Đường dẫn tệp chưa được thiết lập.");
            }
            else
            {
                Console.WriteLine($"Đường dẫn tệp hiện tại: {filePath}");
            }
        }
    }
}
