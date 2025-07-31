using System;
using System.IO;

namespace Project_Student_Management.Base
{
    internal class TestFile
    {
        public void Test()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string filePath = "D:\\c#\\Project_Student_Management\\Project_Student_Management\\test.txt";
            string content = "Xin chào, đây là nội dung file!";

            File.WriteAllText(filePath, content);

            Console.WriteLine("Đã ghi nội dung vào file.");

        }
    }
}
