using System.Collections.Generic;

namespace Project_Student_Management.Base
{
    public interface IFileHandler<Student>
    {
        List<Student> LoadDataList(string filePath);
        void SaveFromList(string filePath, List<Student> data);
    }
}
