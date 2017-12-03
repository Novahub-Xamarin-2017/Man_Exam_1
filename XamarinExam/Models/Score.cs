using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using XamarinExam.Controllers;
using XamarinExam.Models.EasyModels;

namespace XamarinExam.Models
{
    public class Score : EasyModels.EasyModels
    {
        [IgnoreInput]
        public int CourseId { get; set; }
        [IgnoreInput]
        public int StudenId { get; set; }
        [IgnoreInput]
        public double StudentScore { get; set; }

        public Score()
        {
            
        }

        public Score(int id, int courseId, int studentId, double studentScore)
        {
            Id = id;
            CourseId = courseId;
            StudenId = studentId;
            StudentScore = studentScore;
        }

        public new void Input()
        {
            StudentScore = -1;
            do
            {
                Console.Write("Nhap diem: ");
                StudentScore = Convert.ToDouble(Console.ReadLine());
            } while (StudentScore > 10 || StudentScore < 0);

            Console.WriteLine("Chon lop : ");
            ConsoleTable.From(DataManager.GetInstance.Classes).Write();
            Console.Write("Nhap ID lop : ");
            var classId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Chon khoa hoc : ");
            ConsoleTable.From(DataManager.GetInstance.Courses.Where(x => x.ClassId == classId)).Write();
            Console.Write("Nhap ID khoa hoc : ");
            CourseId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Chon hoc sinh : ");
            ConsoleTable.From(DataManager.GetInstance.Students.Where(x => x.ClassId == classId)).Write();
            Console.Write("Nhap ID hoc sinh : ");
            StudenId = Convert.ToInt32(Console.ReadLine());
        }
    }
}
