using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using Newtonsoft.Json;
using XamarinExam.Controllers;
using XamarinExam.Models;

namespace XamarinExam
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.Unicode;
            DataManager dataManager = DataManager.GetInstance;
            Menu menu = new Menu(dataManager);
            menu.DrawMenu();
            Console.ReadKey();
        }
        

    }
}
