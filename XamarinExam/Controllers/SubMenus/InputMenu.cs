using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinExam.Extension;

namespace XamarinExam.Controllers.SubMenus
{
    public class InputMenu
    {
        public DataManager DataManager { get; set; }

        public InputMenu()
        {

        }

        public InputMenu(DataManager dataManager)
        {
            DataManager = dataManager;
            DataManager.LoadData();
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
            Console.WriteLine("1. Quay lai menu nhap du lieu.");
            Console.WriteLine("2. Quay lai menu chinh.");
            Console.WriteLine("3. Thoat.");
            int secondChoice = Convert.ToInt32(Console.ReadLine());
            switch (secondChoice)
            {
                case 1:
                    ShowInputMenu();
                    break;
                case 2:
                    var menu = new Menu(DataManager);
                    menu.DrawMenu();
                    break;
            }
        }
    }
}
