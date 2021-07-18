using System;
using System.IO;
using System.Xml.Linq;

namespace FC.Generate.MD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ready to Crate Document");
            var xml = File.ReadAllText(args[0]);
            var doc = XDocument.Parse(xml);
            var md = doc.Root.ToMarkDown();
            Console.WriteLine(md);
            File.WriteAllText("Document.md", md);
            Console.WriteLine("Docuemnt Created");

        }
    }

}
