using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using XamarinExam.Controllers;
using XamarinExam.Models.EasyModels;

namespace XamarinExam.Models
{
    public class Student : EasyModels.EasyModels
    {
        [PrompDisplay("Ten hoc sinh: ")]
        public string Name { get; set; }
        [IgnoreInput]
        public int ClassId { get; set; }
        [PrompDisplay("Dia chi: ")]
        public string Address { get; set; }
        [PrompDisplay("Ngay sinh: ")]
        public DateTime Birthday { get; set; }

        public Student()
        {
        }

        public Student(int id, string name, int classId, string address, DateTime birthday)
        {
            Id = id;
            Name = name;
            ClassId = classId;
            Address = address;
            Birthday = birthday;
        }

        public new void Input()
        {
            base.Input();
            Console.WriteLine("Chon lop: ");
            ConsoleTable.From(DataManager.GetInstance.Classes).Write();
            Console.Write("Nhap ID lop: ");
            ClassId = Convert.ToInt32(Console.ReadLine());
        }
    }
}
