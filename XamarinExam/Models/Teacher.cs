using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinExam.Models
{
    public class Teacher : EasyModels.EasyModels
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int SubjectId { get; set; }

        public Teacher(int id, string name, string address, int subjectId)
        {
            Id = id;
            Name = name;
            Address = address;
            SubjectId = subjectId;
        }
    }
}
