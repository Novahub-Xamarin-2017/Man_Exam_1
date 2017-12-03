using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace XamarinExam.Controllers.SubMenus
{
    public class DisplayMenu
    {
        public DataManager DataManager { get; set; }

        public DisplayMenu()
        {
            
        }

        public DisplayMenu(DataManager dataManager)
        {
            DataManager = dataManager;
        }

        public void ShowDisplayMenu()
        {
            int choice;
            Console.Clear();
            Console.WriteLine("1. Danh sach mon hoc.");
            Console.WriteLine("2. Danh sach giao vien.");
            Console.WriteLine("3. Danh sach lop hoc.");
            Console.WriteLine("4. Danh sach sinh vien theo tung lop.");
            Console.Write("Nhap vao lua chon cua ban : ");
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                ShowDisplayMenu();
                throw;
            }
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Danh sach mon hoc : ");
                    ConsoleTable.From(DataManager.Subjects).Write();
                    break;
                case 2:
                    ShowTeachers();
                    break;
                case 3:
                    ShowClasses();
                    break;
                case 4:
                    ShowStudents();
                    break;
                default:
                    ShowDisplayMenu();
                    break;
            }
            Console.WriteLine("1. Quay lai menu .");
            Console.WriteLine("2. Quay lai menu chinh.");
            Console.WriteLine("3. Thoat.");
            int secondChoice = Convert.ToInt32(Console.ReadLine());
            switch (secondChoice)
            {
                case 1:
                    ShowDisplayMenu();
                    break;
                case 2:
                    var menu = new Menu(DataManager);
                    menu.DrawMenu();
                    break;
            }
        }

        public void ShowStudents()
        {
            var students = DataManager.Students.Join(DataManager.Classes, x => x.ClassId, c => c.Id,
                (x, c) => new {x.Id, x.Name, x.Address, Class = c.Name});
            var studentsOfEachClass = from student in students
                           group student by student.Class
                           into newGroup
                           orderby newGroup.Key
                           select newGroup;
            foreach (var item in studentsOfEachClass)
            {
                Console.WriteLine(item.Key);
                ConsoleTable.From(item).Write();
            }
            Console.Write("Nhap ID sinh vien muon xem bang diem : ");
            var studentId = Convert.ToInt32(Console.ReadLine());

            var scoresOfStudent = DataManager.Scores.Where(x => x.StudenId == studentId)
                .Join(DataManager.Courses, s => s.CourseId, c => c.Id,
                    (s, c) => new {s.Id, s.StudenId, s.StudentScore, Course = c.Name})
                .Join(DataManager.Students, x => x.StudenId, s => s.Id,
                    (x, s) => new {Student = s.Name, x.StudentScore, x.Course});
            ConsoleTable.From(scoresOfStudent).Write();
        }

        public void ShowClasses()
        {
            Console.WriteLine("Danh sach lop hoc : ");
            var classes = DataManager.Classes.Join(DataManager.Teachers, x => x.TeacherId, t => t.Id,
                (x, t) => new
                {
                    x.Id,
                    x.Name,
                    Teacher = t.Name,
                    NumberOfStudents = DataManager.Students.Where(s => s.ClassId == x.Id).Count()
                });
            ConsoleTable.From(classes).Write();
            Console.Write("Chon ID lop muon hien thi danh sach khoa hoc : ");
            var classId = Convert.ToInt32(Console.ReadLine());
            var courses = DataManager.Courses.Where(x => x.ClassId == classId).Select(x => new {x.Id, x.Name});
            ConsoleTable.From(courses).Write();
            Console.Write("Nhap ID khoa hoc muon xem diem : ");
            var courseId = Convert.ToInt32(Console.ReadLine());
            ConsoleTable.From(DataManager.Scores.Where(x => x.CourseId == courseId)
                    .Select(x => new { x.StudenId, x.StudentScore })
                    .Join(DataManager.Students, x => x.StudenId, s => s.Id, (x, s) => new { StudentName = s.Name, x.StudentScore }))
                .Write();

        }
        public void ShowTeachers()
        {
            Console.WriteLine("Danh sach giao vien: ");
            var teachers = (from t in DataManager.Teachers
                            join c in DataManager.Classes on t.Id equals c.TeacherId
                            into ts
                            from tc in ts.DefaultIfEmpty()
                            select new
                            {
                                t.Id,
                                t.Name,
                                t.Address,
                                t.SubjectId,
                                Class = tc == null ? "None" : tc.Name
                            }).Join(DataManager.Subjects, t => t.SubjectId, s => s.Id, (t, s) => new {t.Id, t.Name, t.Address, t.Class, Subject = s.Name});
            ConsoleTable.From(teachers).Write();
            Console.Write("Nhap ID giao vien muon xem danh sach khoa hoc : ");
            var teacherId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Danh sach khoa hoc : ");
            var classes = DataManager.Classes.Where(x => x.TeacherId == teacherId);
            foreach (var c in classes)
            {
                ConsoleTable.From(DataManager.Courses.Where(x => x.ClassId == c.Id).Select(x => new {x.Id, x.Name})).Write();
            }

            Console.WriteLine("Nhap ID khoa hoc muon xem bang diem : ");
            var courseId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Bang diem : ");
            ConsoleTable.From(DataManager.Scores.Where(x => x.CourseId == courseId)
                                                .Select(x => new {x.StudenId, x.StudentScore})
                                                .Join(DataManager.Students, x => x.StudenId, s => s.Id, (x, s) => new {StudentName = s.Name, x.StudentScore}))
                        .Write();
        }
    }
}
