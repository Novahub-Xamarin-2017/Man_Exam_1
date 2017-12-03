using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace XamarinExam.Controllers.SubMenus
{
    public class SearchMenu
    {
        public DataManager DataManager { get; set; }

        public SearchMenu()
        {
            
        }

        public SearchMenu(DataManager dataManager)
        {
            DataManager = dataManager;
        }

        public void ShowSearchMenu()
        {
            int choice;
            Console.Clear();
            Console.WriteLine("1. Tim kiem hoc sinh.");
            Console.WriteLine("2. Tim kiem lop hoc.");
            Console.Write("Nhap vao lua chon cua ban: ");
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                ShowSearchMenu();
                throw;
            }
            switch (choice)
            {
                case 1:
                    SearchByStudentName();
                    break;
                case 2:
                    SearchByClassName();
                    break;
                default:
                    ShowSearchMenu();
                    break;
            }
            Console.WriteLine("1. Quay lai menu tim kiem.");
            Console.WriteLine("2. Quay lai menu chinh.");
            Console.WriteLine("3. Thoat.");
            int secondChoice = Convert.ToInt32(Console.ReadLine());
            switch (secondChoice)
            {
                case 1:
                    ShowSearchMenu();
                    break;
                case 2:
                    var menu = new Menu(DataManager);
                    menu.DrawMenu();
                    break;
            }
        }

        public void SearchByStudentName()
        {
            Console.Write("Nhap ten sinh vien : ");
            var name = Console.ReadLine();

            var students = DataManager.Students.Where(x => x.Name.ToLower().Contains(name.ToLower()))
                .Join(DataManager.Classes, x => x.ClassId, c => c.Id,
                    (x, c) => new {x.Id, x.Name, x.Address, x.Birthday, Class = c.Name});
            ConsoleTable.From(students).Write();
            Console.Write("Nhap ID sinh vien muon xem diem: ");
            var studentId = Convert.ToInt32(Console.ReadLine());

            var scoresOfStudent = DataManager.Scores.Where(x => x.StudenId == studentId)
                .Join(DataManager.Courses, s => s.CourseId, c => c.Id,
                    (s, c) => new { s.Id, s.StudenId, s.StudentScore, Course = c.Name })
                .Join(DataManager.Students, x => x.StudenId, s => s.Id,
                    (x, s) => new { Student = s.Name, x.StudentScore, x.Course });
            ConsoleTable.From(scoresOfStudent).Write();
        }

        public void SearchByClassName()
        {
            Console.Write("Nhap ten lop: ");
            var className = Console.ReadLine();
            var classes = DataManager.Classes.Where(x => x.Name.ToLower().Contains(className.ToLower()))
                .Join(DataManager.Teachers, x => x.TeacherId, t => t.Id,
                    (x, t) => new {x.Id, x.Name, Teacher = t.Name});
            ConsoleTable.From(classes).Write();
            Console.Write("Chon ID lop muon hien thi danh sach khoa hoc : ");
            var classId = Convert.ToInt32(Console.ReadLine());
            var courses = DataManager.Courses.Where(x => x.ClassId == classId).Select(x => new { x.Id, x.Name });
            ConsoleTable.From(courses).Write();
            Console.Write("Nhap ID khoa hoc muon xem diem : ");
            var courseId = Convert.ToInt32(Console.ReadLine());
            ConsoleTable.From(DataManager.Scores.Where(x => x.CourseId == courseId)
                    .Select(x => new { x.StudenId, x.StudentScore })
                    .Join(DataManager.Students, x => x.StudenId, s => s.Id, (x, s) => new { StudentName = s.Name, x.StudentScore }))
                .Write();
        }
    }
}
