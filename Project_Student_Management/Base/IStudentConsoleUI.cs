namespace Project_Student_Management.Base
{
    public interface IStudentConsoleUI
    {
        void AddStudent();
        void DisplayAllStudents();
        void FindStudentById();
        void DeleteStudentById();
        void SaveToFile();
        void LoadFromFile();
        void Exit();
    }
}
