using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
using System.Xml;
using System.IO;


namespace TomskASUtp
{
    class Program
    {
        static string inpxml = "";

        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            Check();
            doc.Load(inpxml);
            string outjson2 = JsonConvert.SerializeObject(doc, Newtonsoft.Json.Formatting.Indented);
            Console.Write("Введите имя файла для записи" + "\n");
            string name = Console.ReadLine() + ".json";
            FileStream file = new FileStream(name, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(file);
            sw.Write(outjson2);
            sw.Close();
            Console.Write("\n" + "Файл записан");
            Console.ReadKey();
        }

        static void Check()
        {
            Console.Write("Введите имя файла " + "\n");
            string inpname = Console.ReadLine() ;
            inpxml = inpname + ".xml";
            if (File.Exists(inpxml))
            {
                Console.Write("\nДанные верны" + "\n");
            }
            else
            {
                Console.Write(" ERROR: Файл не существует" + "\n");
                Check();
            }
            
        }
    }
}
