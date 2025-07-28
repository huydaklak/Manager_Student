using System;
using System.Text;
using Project_Student_Management.Base;

namespace Project_Student_Management
{
    internal class Menu
    {
        public void Select()
        {
            IStudentManager manager = new StudentManager();
            string filePath = "Student.txt";
            manager.LoadFromFile(filePath);

            Console.OutputEncoding = Encoding.UTF8;

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
                        Console.Write("Nhập mã sinh viên: ");
                        var id = Console.ReadLine();

                        Console.Write("Nhập họ tên: ");
                        var name = Console.ReadLine();

                        Console.Write("Nhập ngày sinh (dd/MM/yyyy): ");
                        DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                        Console.Write("Nhập giới tính: ");
                        var gender = Console.ReadLine();

                        Console.Write("Nhập lớp học: ");
                        var cls = Console.ReadLine();

                        Console.Write("Nhập GPA: ");
                        var gpa = double.Parse(Console.ReadLine());

                        var newStudent = new Student
                        {
                            StudentId = id,
                            FullName = name,
                            DateOfBirth = dob,
                            Gender = gender,
                            ClassName = cls,
                            GPA = gpa
                        };
                        manager.AddStudent(newStudent);
                        manager.SaveToFile(filePath);
                        Console.WriteLine(" Thêm sinh viên thành công!");

                        break;

                    case "2":
                        var allStudents = manager.GetAllStudents();
                        if (allStudents.Count == 0)
                        {
                            Console.WriteLine("Danh sách sinh viên trống.");
                        }
                        else
                        {
                            Console.WriteLine("Danh sách sinh viên:");
                            foreach (var s in allStudents)
                            {
                                s.DisplayInfo();
                            }
                        }
                        break;

                    case "3":
                        Console.Write("Nhập mã sinh viên cần tìm: ");
                        var findId = Console.ReadLine();
                        var svFind = manager.FindById(findId);
                        if (svFind != null)
                        {
                            Console.WriteLine("Thông tin sinh viên tìm được:");
                            svFind.DisplayInfo();
                        }
                        else
                        {
                            Console.WriteLine("Không tìm thấy sinh viên có mã: " + findId);
                        }
                        break;

                    case "4":
                        Console.Write("Nhập mã sinh viên cần xóa: ");
                        var delId = Console.ReadLine();
                        var svDel = manager.FindById(delId);
                        if (svDel != null)
                        {
                            manager.DeleteStudent(delId);
                            Console.WriteLine(" Đã xóa sinh viên thành công.");
                        }
                        else
                        {
                            Console.WriteLine("Không tìm thấy sinh viên cần xóa.");
                        }
                        break;

                    case "5":
                        manager.SaveToFile(filePath);
                        Console.WriteLine($"Đã lưu danh sách vào file: {filePath}");
                        break;

                    case "6":
                        manager.LoadFromFile(filePath);
                        Console.WriteLine($"Đã đọc danh sách từ file: {filePath}");
                        break;

                    case "0":
                        Console.WriteLine("Thoát chương trình.");
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng nhập lại.");
                        break;
                }
            }
        }
    }
}
