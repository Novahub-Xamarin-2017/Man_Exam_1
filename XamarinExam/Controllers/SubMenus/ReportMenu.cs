using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace XamarinExam.Controllers.SubMenus
{
    public class ReportMenu
    {
        public DataManager DataManager { get; set; }

        public ReportMenu()
        {
            
        }

        public ReportMenu(DataManager dataManager)
        {
            DataManager = dataManager;
        }
        public void ShowReportMenu()
        {
            int choice;
            Console.Clear();
            Console.WriteLine("1. Danh sach hoc sinh gioi.");
            Console.WriteLine("2. Diem trung binh theo lop.");
            Console.WriteLine("3. Top 10 sinh vien.");
            Console.WriteLine("4. Top 3 lop co sinh vien gioi nhieu nhat.");
            Console.WriteLine("5. Top 3 lop co diem trung binh cao nhat.");
            Console.WriteLine("6. Top 3 giao vien.");
            Console.Write("Nhap vao lua chon cua ban: ");
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                ShowReportMenu();
                throw;
            }
            switch (choice)
            {
                case 1:
                    ExcellentStudents();
                    break;
                case 2:
                    AverageScoreByClass();
                    break;
                case 3:
                    TopStudents();
                    break;
                case 4:
                    TopClasses();
                    break;
                case 5:
                    TopClassesHaveHighAverageScore();
                    break;
                default:
                    ShowReportMenu();
                    break;
            }
            Console.WriteLine("1. Quay lai menu bao cao.");
            Console.WriteLine("2. Quay lai menu chinh.");
            Console.WriteLine("3. Thoat.");
            int secondChoice = Convert.ToInt32(Console.ReadLine());
            switch (secondChoice)
            {
                case 1:
                    ShowReportMenu();
                    break;
                case 2:
                    var menu = new Menu(DataManager);
                    menu.DrawMenu();
                    break;
            }
        }

        public void TopClasses()
        {
            var classes = DataManager.Classes
                .Select(x =>
                    new {x.Id, x.Name, NumberOfExcellentStudents = DataManager.CountExcellentStudentsInClass(x.Id)})
                .OrderByDescending(x => x.NumberOfExcellentStudents)
                .Take(3);
            ConsoleTable.From(classes).Write();
        }

        public void TopClassesHaveHighAverageScore()
        {
            var classes = DataManager.Classes
                .Select(x =>
                    new {x.Id, x.Name, AverageScore = DataManager.CalculateAverageScoreOfClass(x.Id)})
                .OrderByDescending(x => x.AverageScore)
                .Take(3);
            ConsoleTable.From(classes).Write();
        }
        public void ExcellentStudents()
        {
            Console.WriteLine("Danh sach hoc sinh gioi: ");
            var students = DataManager.Students.Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.ClassId,
                    Score = DataManager.CalculateAverageScore(x.Id)
                }).Where(x => x.Score >= 8)
                .Join(DataManager.Classes, x => x.ClassId, c => c.Id,
                    (x, c) => new { x.Id, x.Name, Class = c.Name, x.Score })
                .OrderBy(x => x.Class)
                .ThenBy(x => x.Name)
                .ThenBy(x => x.Score);
            ConsoleTable.From(students).Write();
        }

        public void AverageScoreByClass()
        {
            var classes = DataManager.Classes.Select(x => new {x.Id, x.Name});
            ConsoleTable.From(classes).Write();
            Console.WriteLine("Nhap ID lop muon xem bang diem: ");
            var classId = Convert.ToInt32(Console.ReadLine());
            var students = DataManager.Students
                .Where(x => x.ClassId == classId)
                .Join(DataManager.Classes, x => x.ClassId, c => c.Id,
                    (x, c) => new {x.Id, x.Name, Class = c.Name, Score = DataManager.CalculateAverageScore(x.Id)});
            ConsoleTable.From(students).Write();
            var averageScore = students.Select(x => x.Score).Sum() / students.Count();
            Console.WriteLine("Diem trung binh ca lop : " + averageScore);
        }

        public void TopStudents()
        {
            var students = DataManager.Students
                .Select(x => new {x.Id, x.Name, x.ClassId, Score = DataManager.CalculateAverageScore(x.Id)})
                .Join(DataManager.Classes, x => x.ClassId, c => c.Id,
                    (x, c) => new {x.Id, x.Name, Class = c.Name, x.Score}).OrderByDescending(x => x.Score)
                .ThenByDescending(x => x.Class).ThenByDescending(x => x.Name)
                .Take(10);
            ConsoleTable.From(students).Write();
        }
    }
}
