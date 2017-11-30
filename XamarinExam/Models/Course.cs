using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinExam.Models
{
    public class Course : EasyModels.EasyModels
    {
        public string Name { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }

        public Course(int id, string name, int subjectId, int teacherId)
        {
            Id = id;
            Name = name;
            SubjectId = subjectId;
            TeacherId = teacherId;
        }
    }
}
