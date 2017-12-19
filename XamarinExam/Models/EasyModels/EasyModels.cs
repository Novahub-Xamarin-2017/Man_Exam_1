using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XamarinExam.Models.EasyModels
{
    public class EasyModels
    {
        [IgnoreInput]
        public int Id { get; set; }
        private readonly List<PropertyInfo> propertyInfos;

        public EasyModels()
        {
            propertyInfos = GetType().GetProperties().ToList();
        }

        public void Input()
        {
            foreach (var propertyInfo in propertyInfos)
            {
                var prompDisplay = GetAttributeValue<PrompDisplayAttribute>(propertyInfo);

                var ignoreInput = GetAttributeValue<IgnoreInputAttribute>(propertyInfo);

                if (ignoreInput == null)
                {
                    Console.Write($"Nhap {prompDisplay?.Display ?? propertyInfo.Name}: ");
                    switch (Type.GetTypeCode(propertyInfo.PropertyType))
                    {
                        case TypeCode.String:
                            propertyInfo.SetValue(this, Console.ReadLine());
                            break;
                        case TypeCode.Int16:
                            propertyInfo.SetValue(this, Convert.ToInt16(Console.ReadLine()));
                            break;
                        case TypeCode.Int32:
                            propertyInfo.SetValue(this, Convert.ToInt32(Console.ReadLine()));
                            break;
                        case TypeCode.DateTime:
                            propertyInfo.SetValue(this, DateTime.Parse(Console.ReadLine()));
                            break;
                        case TypeCode.Double:
                            propertyInfo.SetValue(this, Convert.ToDouble(Console.ReadLine()));
                            break;
                    }
                }
            }
        }

        public override string ToString()
        {
            return string.Join(", ", propertyInfos
                .Where(x => x.CanRead)
                .Select(x => $"{x.Name}: {x.GetValue(this)}"));
        }

        private static T GetAttributeValue<T>(PropertyInfo propertyInfo) where T : Attribute
        {
            return propertyInfo.GetCustomAttributes(typeof(T), true).FirstOrDefault() as T;
        }
    }
}
