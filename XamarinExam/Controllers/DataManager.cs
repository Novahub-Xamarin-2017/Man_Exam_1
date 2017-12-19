using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using Newtonsoft.Json;
using XamarinExam.Models;

namespace XamarinExam.Controllers
{
    public class DataManager
    {

        private static DataManager instance;

        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }
        public List<Score> Scores { get; set; }
        public List<Class> Classes { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Teacher> Teachers { get; set; }

        private DataManager()
        {
            Students = new List<Student>();
            Courses = new List<Course>();
            Classes = new List<Class>();
            Teachers = new List<Teacher>();
            Subjects = new List<Subject>();
            Scores = new List<Score>();
        }

        public static DataManager GetInstance => instance ?? (instance = new DataManager());

        public static void SaveJson<T>(List<T> data, string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var fileName = $"{typeof(T).Name}s.json";
            var filePath = Path.Combine(directory, fileName);
            var json = JsonConvert.SerializeObject(data);
            File.WriteAllText(filePath, json);
        }
        public static List<T> ReadJson<T>(string directory)
        {
            var fileName = $"{typeof(T).Name}s.json";
            var filePath = Path.Combine(directory, fileName);
            var data = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(data);
        }

        public void LoadData()
        {
            Students = ReadJson<Student>("Data");
            Classes = ReadJson<Class>("Data");
            Courses = ReadJson<Course>("Data");
            Scores = ReadJson<Score>("Data");
            Teachers = ReadJson<Teacher>("Data");
            Subjects = ReadJson<Subject>("Data");
        }
        public void WriteData()
        {
            SaveJson(Students, "Data");
            SaveJson(Classes, "Data");
            SaveJson(Courses, "Data");
            SaveJson(Scores, "Data");
            SaveJson(Teachers, "Data");
            SaveJson(Subjects, "Data");
        }

        public double CalculateAverageScore(int studentId)
        {
            var scores = Scores.Where(x => x.StudenId == studentId)
                .Select(x => new { x.StudentScore, x.CourseId })
                .Join(Courses, x => x.CourseId, c => c.Id, (x, c) => new { x.StudentScore, c.SubjectId })
                .Join(Subjects, x => x.SubjectId, s => s.Id, (x, s) => new { x.StudentScore, s.Coefficient });
            return scores.Sum(a => a.StudentScore * a.Coefficient) / scores.Sum(a => a.Coefficient);
        }

        public int CountExcellentStudentsInClass(int classId)
        {
            return (Students.Where(x => x.ClassId == classId)
                .Select(x => new {x.Id, x.Name, Score = CalculateAverageScore(x.Id)})
                .Where(x => x.Score >= 8))
                .Count();
        }

        public double CalculateAverageScoreOfClass(int classId)
        {
            var students = Students.Where(x => x.ClassId == classId)
                .Select(x => new {x.Id, Score = CalculateAverageScore(x.Id)});
            return students.Select(x => x.Score).Sum() / students.Count();
        }

        public double CalculateAverageScorePerCourse(int courseId)
        {
            var scores = Scores.Where(x => x.CourseId == courseId)
                .Select(x => new { x.Id, x.CourseId, x.StudentScore })
                .Join(Courses, x => x.CourseId, c => c.Id,
                    (x, c) => new { x.Id, x.StudentScore, c.SubjectId })
                .Join(Subjects, x => x.SubjectId, s => s.Id, (x, s) => new { x.StudentScore, s.Coefficient });
            return scores.Sum(x => x.StudentScore * x.Coefficient) / scores.Count();
        }
    }
}
