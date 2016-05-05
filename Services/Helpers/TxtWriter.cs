using ElectronRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace Services.Helpers
{
    public class TxtWriter<T> where T : class
    { 
        public static void WriteFile(IEnumerable<object> entities, string fileName, string title)
        {
            FileStream text = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(text);

            writer.WriteLine(title);
            writer.WriteLine();

            foreach (object entity in entities)
            {
                string formattedData = FromatData(entity);
                writer.WriteLine(formattedData);
            }
            writer.Close();
        }

        private static string FromatData(object entity)
        {
            StringBuilder stringBuilder = new StringBuilder();

            Type type = typeof(T);
            foreach (PropertyInfo propertyInfo in type.GetProperties())
            {
                string name = propertyInfo.Name;
                object value = propertyInfo.GetValue(entity, null);
                if(value != null)
                    stringBuilder.AppendLine(name + " = " + value.ToString());
                else
                    stringBuilder.AppendLine(name + " = " + "null");
            }
            stringBuilder.Append(Environment.NewLine);

            return stringBuilder.ToString();
        }
    }
}