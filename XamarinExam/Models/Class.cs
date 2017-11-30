using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinExam.Models
{
    public class Class : EasyModels.EasyModels
    {
        public string Name { get; set; }
        public int TeacherId { get; set; }

        public Class(int id, string name, int teacherId)
        {
            Id = id;
            Name = name;
            TeacherId = teacherId;
        }
    }
}
