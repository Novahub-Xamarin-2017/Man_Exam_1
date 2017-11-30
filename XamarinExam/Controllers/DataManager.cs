using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
