using System;
using System.Text;
using Project_Student_Management.Base;

namespace Project_Student_Management
{
    internal class Menu
    {
        public void Select()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            StudentManager studentManager = new StudentManager();
            IStudentManager manager = studentManager;
            IStudentConsoleUI ui = studentManager;
            manager.LoadFromFile();

            //IStudentManager manager = new StudentManager();
            //IStudentConsoleUI ui = (IStudentConsoleUI)manager;


            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("========= MENU QUẢN LÝ SINH VIÊN =========");
            Console.WriteLine(" ");
            Console.WriteLine("1.  Thêm sinh viên ");
            Console.WriteLine("2.  Hiển thị danh sách sinh viên ");
            Console.WriteLine("3.  Tìm sinh viên theo mã số ");
            Console.WriteLine("4.  Xóa sinh viên theo mã số ");
            Console.WriteLine("5.  Ghi danh sách vào file Student.txt");
            Console.WriteLine("6.  Đọc danh sách từ file Student.txt");
            Console.WriteLine("0.  Thoát");
            Console.WriteLine(" ");
            Console.WriteLine("==========================================");

            while (true)
            {
                Console.WriteLine("Nhập lựa chon của ban từ (0 -> 9) :");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ui.AddStudent();
                        break;

                    case "2":
                        ui.DisplayAllStudents();
                        break;

                    case "3":
                        ui.FindStudentById();
                        break;

                    case "4":
                        ui.DeleteStudentById();
                        break;

                    case "5":
                        ui.SaveToFile();
                        break;

                    case "6":
                        ui.LoadFromFile();
                        break;

                    case "0":
                        Console.WriteLine("Thoát chương trình.");
                        ui.SaveToFile();
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng nhập lại.");
                        break;
                }
            }
        }
    }
}
