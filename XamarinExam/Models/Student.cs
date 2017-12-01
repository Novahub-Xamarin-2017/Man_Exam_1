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
        [PrompDisplay("Name")]
        public string Name { get; set; }
        [IgnoreInput]
        public int ClassId { get; set; }
        public string Address { get; set; }
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
            Console.WriteLine("Chon lop");
            ConsoleTable.From(DataManager.GetInstance.Classes).Write();
            ClassId = Convert.ToInt32(Console.ReadLine());
        }
    }
}
