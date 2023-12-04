using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Internet_Terkep
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.Write("URL: ");
            String url = Console.ReadLine();    
            WebRequest keres = WebRequest.Create(url);
            /*keres.Method = "PUT";
            StreamWriter sw2 = new StreamWriter(keres.GetRequestStream());
            sw2.Write("...|...|...");
            sw2.Flush();*/
            WebResponse valasz = keres.GetResponse();
            StreamReader sr = new StreamReader(valasz.GetResponseStream());
            StreamWriter sw = new StreamWriter("index.html");
            Regex joSor = new Regex("^.*<a.*href= \".*$");
            while (!sr.EndOfStream)
            {
               // Console.WriteLine(sr.ReadLine());
              // sw.Write(sr.ReadLine());
              string sor = sr.ReadLine();
                if(joSor.IsMatch(sor))
                {
                    Regex helyettesito = new Regex("^.*<a.*href= \"");
                    sor = helyettesito.Replace(sor, "");
                    helyettesito = new Regex("\".*");
                    sor = helyettesito.Replace(sor, "");
                    Console.WriteLine(sor); 
                }
            }
            Console.ReadKey();
        }
    }
}
