using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinExam.Models.EasyModels;

namespace XamarinExam.Models
{
    public class Subject : EasyModels.EasyModels
    {
        [PrompDisplay("Ten mon hoc: ")]
        public string Name { get; set; }
        [PrompDisplay("Trong so: ")]
        public int Coefficient { get; set; }

        public Subject()
        {
            
        }
        public Subject(int id, string name, int coefficient)
        {
            Id = id;
            Name = name;
            Coefficient = coefficient;
        }
    }
}
