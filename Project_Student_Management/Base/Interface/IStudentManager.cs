using System.Collections.Generic;

namespace Project_Student_Management.Base
{
    public interface IStudentManager
    {
        void AddStudent(Student student);
        void EditStudent(string StudentId, Student student);
        void DeleteStudent(string StudentId);
        List<Student> GetAllStudents();
        Student FindById(string StudentId);

        void LoadFromFile();
    }
}
