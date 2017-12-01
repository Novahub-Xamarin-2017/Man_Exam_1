using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using Newtonsoft.Json;
using XamarinExam.Controllers;
using XamarinExam.Extension;
using XamarinExam.Models;

namespace XamarinExam
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataManager = DataManager.GetInstance;
            dataManager.LoadData();
            Menu menu = new Menu(dataManager);
            menu.DrawMenu();
            Console.ReadKey();
        }
        

        

    }
}
