using System;
using System.Collections.Generic;
using System.IO;

namespace Project_Student_Management.Base
{
    public class StudentManager : IStudentManager, IStudentConsoleUI
    {
        private List<Student> students = new List<Student>();
        private string filePath = "D:\\c#\\Project_Student_Management\\Project_Student_Management\\Student.txt";

        public void AddStudent(Student student)
        {
            students.Add(student);
        }
        public void EditStudent(string id, Student student)
        {
            var sv = FindById(id);
            if (sv != null)
            {
                sv.FullName = student.FullName;
                sv.DateOfBirth = student.DateOfBirth;
                sv.Gender = student.Gender;
                sv.ClassName = student.ClassName;
                sv.GPA = student.GPA;
            }
        }

        public void DeleteStudent(string id)
        {
            var sv = FindById(id);
            if (sv != null)
                students.Remove(sv);
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public Student FindById(string id)
        {
            return students.Find(s => s.StudentId == id);
        }

        public void SaveToFile(string path)
        {
            var lines = new List<string>();
            foreach (var sv in students)
                lines.Add(sv.ToString());
            File.WriteAllLines(path, lines);
        }

        public void LoadFromFile(string path)
        {
            students.Clear();
            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    students.Add(Student.FromString(line));
                }
            }
        }


        public void AddStudent()
        {
            Console.Write("Nhập mã sinh viên: ");
            string id = Console.ReadLine();

            Console.Write("Nhập họ tên: ");
            string name = Console.ReadLine();

            Console.Write("Nhập ngày sinh (dd/MM/yyyy): ");
            DateTime dob;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dob))
            {
                Console.Write("Sai định dạng, hãy nhập lại (dd/MM/yyyy): ");
            }

            Console.Write("Nhập giới tính: ");
            string gender = Console.ReadLine();

            Console.Write("Nhập lớp: ");
            string className = Console.ReadLine();

            Console.Write("Nhập GPA: ");
            double gpa;
            while (!double.TryParse(Console.ReadLine(), out gpa))
            {
                Console.Write("Sai định dạng GPA, hãy nhập lại: ");
            }

            Student newStudent = new Student
            {
                StudentId = id,
                FullName = name,
                DateOfBirth = dob,
                Gender = gender,
                ClassName = className,
                GPA = gpa
            };

            AddStudent(newStudent);
            Console.WriteLine("✔ Thêm sinh viên thành công!");
        }
        public void DisplayAllStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Danh sách sinh viên trống.");
                return;
            }

            Console.WriteLine("\n--- Danh sách sinh viên ---");
            foreach (var s in students)
            {
                s.DisplayInfo();
            }
        }
        public void FindStudentById()
        {
            Console.Write("Nhập mã sinh viên cần tìm: ");
            string id = Console.ReadLine();
            var sv = FindById(id);
            if (sv != null)
            {
                Console.WriteLine("Thông tin sinh viên:");
                sv.DisplayInfo();
            }
            else
            {
                Console.WriteLine("❌ Không tìm thấy sinh viên.");
            }
        }
        public void DeleteStudentById()
        {
            Console.Write("Nhập mã sinh viên cần xóa: ");
            string id = Console.ReadLine();
            var sv = FindById(id);
            if (sv != null)
            {
                DeleteStudent(id);
                Console.WriteLine("✔ Đã xóa sinh viên thành công.");
            }
            else
            {
                Console.WriteLine("❌ Không tìm thấy sinh viên.");
            }
        }
        public void SaveToFile()
        {
            SaveToFile(filePath);
            Console.WriteLine("✔ Đã lưu danh sách vào file.");
        }

        public void LoadFromFile()
        {
            LoadFromFile(filePath);
            Console.WriteLine("✔ Đã đọc danh sách từ file.");
        }
        public void Exit()
        {
            Console.WriteLine("👋 Tạm biệt!");
        }
    }
}
