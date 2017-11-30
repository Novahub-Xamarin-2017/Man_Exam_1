using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XamarinExam.Models.EasyModels;

namespace XamarinExam.Models
{
    public class Student : EasyModels.EasyModels
    {
        [PrompDisplay("Name")]
        public string Name { get; set; }
        [PrompDisplay("Class Id")]
        public int ClassId { get; set; }
        [PrompDisplay("Address")]
        public string Address { get; set; }
        [PrompDisplay("Birthday")]
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
    }
}
