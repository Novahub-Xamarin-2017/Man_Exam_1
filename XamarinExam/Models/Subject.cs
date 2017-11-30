using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinExam.Models
{
    public class Subject : EasyModels.EasyModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Coefficient { get; set; }

        public Subject(int id, string name, int coefficient)
        {
            Id = id;
            Name = name;
            Coefficient = coefficient;
        }
    }
}
