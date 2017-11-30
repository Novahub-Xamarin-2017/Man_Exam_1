using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinExam.Models.EasyModels;

namespace XamarinExam.Models
{
    public class Score : EasyModels.EasyModels
    {
        public int CourseId { get; set; }
        public int StudenId { get; set; }
        public double StudentScore { get; set; }

        public Score(int id, int courseId, int studentId, double studentScore)
        {
            Id = id;
            CourseId = courseId;
            StudenId = studentId;
            StudentScore = studentScore;
        }

    }
}
