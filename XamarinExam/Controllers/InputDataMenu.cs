using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinExam.Extension;

namespace XamarinExam.Controllers
{
    public class InputDataMenu
    {
        public DataManager DataManager { get; set; }

        public InputDataMenu()
        {
            
        }

        public InputDataMenu(DataManager dataManager)
        {
            DataManager = dataManager;
        }

        public void ShowInputMenu()
        {
            int choice;
            Console.Clear();
            Console.WriteLine("1. Nhap danh sach mon hoc.");
            Console.WriteLine("2. Nhap danh sach giao vien.");
            Console.WriteLine("3. Nhap danh sach lop hoc.");
            Console.WriteLine("4. Nhap danh sach sinh vien.");
            Console.WriteLine("5. Nhap danh sach khoa hoc.");
            Console.WriteLine("6. Nhap danh sach diem so.");
            Console.Write("Nhap vao lua chon cua ban : ");
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                ShowInputMenu();
                throw;
            }
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Nhap danh sach mon hoc.");
                    DataManager.Subjects.Input();
                    break;
                case 2:
                    Console.WriteLine("Nhap danh sach giao vien.");
                    DataManager.Teachers.Input();
                    break;
                case 3:
                    Console.WriteLine("Nhap danh sach lop hoc.");
                    DataManager.Classes.Input();
                    break;
                case 4:
                    Console.WriteLine("Nhap danh sach sinh vien.");
                    DataManager.Students.Input();
                    break;
                case 5:
                    Console.WriteLine("Nhap danh sach khoa hoc.");
                    DataManager.Courses.Input();
                    break;
                case 6:
                    Console.WriteLine("Nhap danh sach diem so.");
                    DataManager.Scores.Input();
                    break;
                default:
                    ShowInputMenu();
                    break;
            }
            DataManager.WriteData();
        }
    }
}
