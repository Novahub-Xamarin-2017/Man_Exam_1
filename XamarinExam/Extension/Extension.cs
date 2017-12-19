using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinExam.Models;
using XamarinExam.Models.EasyModels;

namespace XamarinExam.Extension
{
    public static class Extension
    {
        public static void Input<T>(this List<T> list) where T : EasyModels, new()
        {
            Console.Write("Nhap so luong : ");
            var count = Convert.ToInt32(Console.ReadLine());
            for (var i = 0; i < count; i++)
            {
                var item = new T();
                if (item is Teacher)
                {
                    (item as Teacher).Input();
                }
                else if (item is Course)
                {
                    (item as Course).Input();
                }
                else if (item is Class)
                {
                    (item as Class).Input();
                }
                else if (item is Student)
                {
                    (item as Student).Input();
                }
                else if (item is Score)
                {
                    (item as Score).Input();
                }
                else
                {
                    item.Input();
                }
                item.Id = list.Count + 1;
                list.Add(item);
            }
        }
    }
}
