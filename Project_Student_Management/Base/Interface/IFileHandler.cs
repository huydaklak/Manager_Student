namespace Project_Student_Management.Base
{
    public interface IFileHandler
    {
        void SaveToFile(string filePath);
        void LoadFromFile(string filePath);

        void SaveToFile();
        void LoadFromFile();
    }
}
