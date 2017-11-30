using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XamarinExam.Controllers
{
    public class Menu
    {
        public DataManager DataManager { get; set; }

        public Menu(DataManager dataManager)
        {
            DataManager = dataManager;
        }

        public void DrawMenu()
        {
            int choice;
            Console.Clear();
            Console.WriteLine("1. Nhap du lieu.");
            Console.WriteLine("2. Hien thi du lieu.");
            Console.WriteLine("3. Tim kiem du lieu.");
            Console.WriteLine("4. Bao cao.");
            Console.Write("Nhap vao lua chon cua ban : ");
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                DrawMenu();
                throw;
            }
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Nhap du lieu");
                    break;
                case 2:
                    Console.WriteLine("Hien thi du lieu");
                    break;
                case 3:
                    Console.WriteLine("Tim kiem du lieu");
                    break;
                case 4:
                    Console.WriteLine("Bao cao");
                    break;
                default:
                    Console.WriteLine("Nhap sai, vui long nhap lai: ");
                    DrawMenu();
                    break;
            }
        }
    }
}
