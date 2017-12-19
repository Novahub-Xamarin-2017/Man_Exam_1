using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XamarinExam.Controllers.SubMenus;

namespace XamarinExam.Controllers
{
    public class Menu
    {
        public DataManager DataManager { get; set; }
        public  InputMenu InputMenu { get; set; }
        public DisplayMenu DisplayMenu { get; set; }
        public SearchMenu SearchMenu { get; set; }
        public ReportMenu ReportMenu { get; set; }

        public Menu()
        {
            
        }

        public Menu(DataManager dataManager)
        {
            DataManager = dataManager;
            DataManager.LoadData();
            InputMenu = new InputMenu(DataManager);
            DisplayMenu = new DisplayMenu(DataManager);
            SearchMenu = new SearchMenu(DataManager);
            ReportMenu = new ReportMenu(DataManager);
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
                    InputMenu.ShowInputMenu();
                    DrawMenu();
                    break;
                case 2:
                    DisplayMenu.ShowDisplayMenu();
                    break;
                case 3:
                    SearchMenu.ShowSearchMenu();
                    break;
                case 4:
                    ReportMenu.ShowReportMenu();
                    break;
                default:
                    Console.WriteLine("Nhap sai, vui long nhap lai: ");
                    DrawMenu();
                    break;
            }
        }
    }
}
