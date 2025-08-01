using System.Collections.Generic;

namespace Project_Student_Management.Base
{
    public interface IFileHandler<Student>
    {
        List<Student> LoadDataList();
        void SaveFromList(List<Student> data);
    }
}
