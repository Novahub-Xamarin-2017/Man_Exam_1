using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinExam.Models.EasyModels
{
    public class PrompDisplayAttribute : Attribute
    {
        public string Display { get; set; }

        public PrompDisplayAttribute(string display)
        {
            Display = display;
        }
    }
}
