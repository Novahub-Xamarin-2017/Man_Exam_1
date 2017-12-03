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
    public class Class : EasyModels.EasyModels
    {
        [PrompDisplay("Ten lop: ")]
        public string Name { get; set; }
        [IgnoreInput]
        public int TeacherId { get; set; }
        
        public Class()
        {
            
        }

        public Class(int id, string name, int teacherId)
        {
            Id = id;
            Name = name;
            TeacherId = teacherId;
        }

        public new void Input()
        {
            base.Input();
            Console.WriteLine("Chon giao vien: ");
            ConsoleTable.From(DataManager.GetInstance.Teachers).Write();
            Console.Write("Nhap ID giao vien: ");
            TeacherId = Convert.ToInt32(Console.ReadLine());
        }
    }
}
