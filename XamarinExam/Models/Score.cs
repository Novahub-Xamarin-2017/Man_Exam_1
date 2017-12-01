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
        public int ClassId { get; set; }
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
            base.Input();
            Console.WriteLine("Chon lop");
            ConsoleTable.From(DataManager.GetInstance.Classes).Write();
            ClassId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Chon khoa hoc");
            ConsoleTable.From(DataManager.GetInstance.Courses).Write();
            CourseId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Chon hoc sinh");
            ConsoleTable.From(DataManager.GetInstance.Students).Write();
            StudenId = Convert.ToInt32(Console.ReadLine());
        }
    }
}
