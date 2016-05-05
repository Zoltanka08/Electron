using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml;

namespace Services.Helpers
{
    public class XmlWriter<T> where T : class
    {
        public static void WriteFile(IEnumerable<object> entities, string fileName, string title)
        {
       //     FileStream text = new FileStream(fileName, FileMode.Create, FileAccess.Write);

            CreateXmlWrite(fileName, title);
            foreach (object entity in entities)
            {
                Insert(entity, fileName);
            }
        }

        private static void CreateXmlWrite(string fileName, string title)
        {
            string nodeName = typeof(T).Name;
            XmlTextWriter textWrite = new XmlTextWriter(fileName, null);
            textWrite.WriteStartDocument();
            textWrite.WriteStartElement(nodeName + "s");
            textWrite.WriteEndElement();
            textWrite.Close();
        }

        public static XmlElement CreateXMLElement(XmlDocument xmlDoc, string name, string value)
        {
            XmlElement xmlElement = xmlDoc.CreateElement(name);
            XmlText xmlText = xmlDoc.CreateTextNode(value);
            xmlElement.AppendChild(xmlText);
            return xmlElement;
        }

        private static void Insert(object entity, string fileName)
        {
            try
            {
                // Create the XML docment by loading the file
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);

                string nodeName = typeof(T).Name;

                // Creating User node
                XmlElement subNode = xmlDoc.CreateElement(nodeName);

                Type type = typeof(T);
                foreach (PropertyInfo propertyInfo in type.GetProperties())
                {
                    string name = propertyInfo.Name;
                    object value = propertyInfo.GetValue(entity, null);
                    if (value != null)
                    {
                        subNode.AppendChild(CreateXMLElement(xmlDoc, name, value.ToString()));
                        xmlDoc.DocumentElement.AppendChild(subNode);
                    }
                    else
                    {
                        subNode.AppendChild(CreateXMLElement(xmlDoc, name, ""));
                        xmlDoc.DocumentElement.AppendChild(subNode);
                    }
                }

                xmlDoc.Save(fileName);
            }
            catch (Exception ex)
            {
                throw new IOException(ex.Message);
            }
        }
    }
}