using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml; 

namespace TestXML
{
   class Job
    {
        public void read()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\\Users\v-yuhaoluan\Desktop\code\csharp\ReadXml\jobConfig.xml");
            XmlNode use_shell = doc.SelectSingleNode("/Job/Configuration/UseShell");
            XmlNode size = doc.SelectSingleNode("/Job/Configuration/Size");
            XmlNode encoding = doc.SelectSingleNode("/Job/Configuration/EncodingString");
            Configuration config = new Configuration();
            config.UseShell = Convert.ToBoolean(use_shell.InnerText) ;
            config.size = Convert.ToInt32(size.InnerText);
            config.endcoding_string = encoding.InnerText;
            DataPath data = new DataPath();
            XmlNode input = doc.SelectSingleNode("/Job/DataPath/Input");
            XmlNode output = doc.SelectSingleNode("/Job/DataPath/Output");
            data.input = input.InnerText;
            data.output = output.InnerText;
            Console.WriteLine(data.input + " " + data.output);
        } 
    }
    class Configuration
    {
        public bool UseShell;
        public int size;
        public string endcoding_string; 
    }
    class DataPath
    {
        public string input;
        public string output;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Job job = new Job();
            job.read();
            Console.ReadKey();
        }
    }
}
