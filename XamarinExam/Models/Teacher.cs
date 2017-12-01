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
    public class Teacher : EasyModels.EasyModels
    {
        public string Name { get; set; }
        public string Address { get; set; }
        [IgnoreInput]
        public int SubjectId { get; set; }

        public Teacher()
        {
        }


        public Teacher(int id, string name, string address, int subjectId)
        {
            Id = id;
            Name = name;
            Address = address;
            SubjectId = subjectId;
        }

        public new void Input()
        {
            base.Input();
            Console.WriteLine("Chon mon hoc");
            ConsoleTable.From(DataManager.GetInstance.Subjects).Write();
            SubjectId = Convert.ToInt32(Console.ReadLine());
        }
    }
}
