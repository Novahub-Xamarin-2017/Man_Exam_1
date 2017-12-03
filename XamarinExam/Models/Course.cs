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
    public class Course : EasyModels.EasyModels
    {
        [PrompDisplay("Ten khoa hoc")]
        public string Name { get; set; }
        [IgnoreInput]
        public int SubjectId { get; set; }
        [IgnoreInput]
        public int TeacherId { get; set; }
        [IgnoreInput]
        public int ClassId { get; set; }

        public Course()
        {
        }

        public Course(int id, string name, int subjectId, int teacherId)
        {
            Id = id;
            Name = name;
            SubjectId = subjectId;
            TeacherId = teacherId;
        }

        public new void Input()
        {
            base.Input();
            Console.WriteLine("Chon mon hoc: ");
            ConsoleTable.From(DataManager.GetInstance.Subjects).Write();
            Console.Write("Nhap ID mon hoc : ");
            SubjectId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Chon lop: ");
            ConsoleTable.From(DataManager.GetInstance.Classes).Write();
            Console.Write("Nhap ID lop : ");
            ClassId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Chon giao vien");
            ConsoleTable.From(DataManager.GetInstance.Teachers).Write();
            Console.Write("Nhap ID giao vien : ");
            TeacherId = Convert.ToInt32(Console.ReadLine());
        }
    }
}
