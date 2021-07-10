using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml;

namespace XmlParse
{
    /*class Person
    {
        private string _name;
        private int _age;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Age
        {
            get => _age;
            set => _age = value;
        }
    }*/
    
    internal class Program
    {
        public static void Main(string[] args)
        {
             /*XmlTextWriter writer = null;
             using (writer = new XmlTextWriter("buses.xml", Encoding.Unicode))
             {
                 writer.Formatting = Formatting.Indented;
                 writer.Indentation = 4;
                 
                 writer.WriteStartDocument();
                 writer.WriteStartElement("Buses");
                 
                 writer.WriteStartElement("Bus");
                 writer.WriteAttributeString("image","bus1.jpg");
                 writer.WriteElementString("Mark", "Mercedes");
                 writer.WriteElementString("Model", "Big");
                 writer.WriteElementString("Color", "Yellow");
                 writer.WriteElementString("Speed", "120");
                 writer.WriteEndElement();
                 
                 writer.WriteStartElement("Bus");
                 writer.WriteAttributeString("image","bus2.jpg");
                 writer.WriteElementString("Mark", "Man");
                 writer.WriteElementString("Model", "Small");
                 writer.WriteElementString("Color", "White");
                 writer.WriteElementString("Speed", "150");
                 writer.WriteEndElement();
                 
                 writer.WriteEndElement();
                 writer.WriteEndDocument();
             }*/

             /*XmlTextReader reader = null;
             try
             {
                 using (reader = new XmlTextReader("buses.xml"))
                 {
                     while (reader.Read())
                     {
                         reader.WhitespaceHandling = WhitespaceHandling.None;
                         Console.WriteLine($"Type: {reader.NodeType}\tName: {reader.Name}\tValue: {reader.Value}");
                         if (reader.AttributeCount > 0)
                         {
                             while (reader.MoveToNextAttribute())
                             {
                                 Console.WriteLine($"Type: {reader.NodeType}\tName: {reader.Name}\tValue: {reader.Value}");
                             }
                         }
                     }
                 }
             }
             catch (Exception e)
             {
                 Console.WriteLine(e.Message);
             }*/

             /*List<Person> list = new List<Person>();
             list.Add(new Person(){Name = "Vasya", Age = 19});
             list.Add(new Person(){Name = "Masha", Age = 12});
             list.Add(new Person(){Name = "Alex", Age = 56});
             list.Add(new Person(){Name = "Andrew", Age = 21});
             list.Add(new Person(){Name = "Jacob", Age = 31});

             XmlTextWriter writer = null;
             using (/*var#1# writer = new XmlTextWriter("Person.xml", Encoding.Unicode))
             {
                 writer.Formatting = Formatting.Indented;
                 
                 writer.WriteStartDocument();
                 writer.WriteStartElement("People");

                 foreach (var person in list)
                 {
                     writer.WriteStartElement("Person");
                     writer.WriteElementString("Name", person.Name);
                     writer.WriteElementString("Age", person.Age.ToString());
                     writer.WriteEndElement();
                 }
                 
                 writer.WriteEndElement();
                 writer.WriteEndDocument();
             }*/

             WeatherForecast weatherForecast = new WeatherForecast();
             weatherForecast.GetForecast();

             int i = 123;
             object o = i;
             Console.WriteLine(o);

        }
    }
}