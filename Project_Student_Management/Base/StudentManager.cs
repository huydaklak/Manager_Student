using System.Collections.Generic;
using System.IO;

namespace Project_Student_Management.Base
{
    public class StudentManager : IStudentManager
    {
        private List<Student> students = new List<Student>();

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
    }
}