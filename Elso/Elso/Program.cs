using System; //ami a Java-ban import, az itt using ormában használatos
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elso //ami a Java-ban package, az itt névtérként határozódik meg
{
    internal class Program //a program uúgy, mint a javában egy statikus Main metódussal rendelkező osztály
    {
        static void Main(string[] args) //Main itt nagybetűs, string[] itt kisbetűs
        {
            Datumbeolvaso();
            Console.Write("Felhasználói név: "); //a Console statikus osztály(: példányosítás nélkül használható) egyik túlterhelt(: többféle paraméterezéssel is használható) metódusa a Write
            string uname = Console.ReadLine();
            //Console.WriteLine(uname);
            Console.Write("Jelszó: ");
            string passw = "";
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                {
                    break;
                }
                passw += cki.KeyChar;
            }
            Console.WriteLine($"\n{uname}/{passw}");   //$ - megengedi az összefűzést, nem kell ++-okal leírni
            Console.ReadKey(true);
            //Console.WriteLine((new Program()).Lottoszamok());
            /*for(int i=0;i< (new Program()).Lottoszamok().Length;i++)
            {
                Console.WriteLine((new Program()).Lottoszamok()[i]);
            }*/
            Program p = new Program();
            int[] lsz = p.Lottoszamok();
            for (int i=0;i < lsz.Length; i++) 
            {
                Console.Write(lsz[i] + ",");
            }
            Console.ReadKey();
        
            
            //(new Program()).Lottoszamok  // egy névtelen példányt hozunk létre a Program állományból
            
        }
        /*
         Console osztály egyidejűleg testesíti meg azt, ami a Java-ban elkülönül Console.ReadXXX <=> System.in.readXXX továbbá
        Console.WriteXXX <=> System.out.println
        $ kezdetű string pedig olyan, mint Python f kezdetű karaktersorozata
         */

        int[] Lottoszamok()
        {
            int[] lsz = new int[5];
            //return new int[5] { 17, 32, 53, 78, 83 };
            Random r=new Random();
            /*for (int i=0; i<lsz.Length; i++ ) 
            {
                lsz[i] = r.Next(1, 90);    //alsó és felső határérték megadás
            }*/
            int db = 0;
            while (db < 5) 
            {
                int szam = r.Next(1, 90);
                lsz[db] = szam;
                bool van = false;
                for (int i=db-1; i>=0;i--) 
                {
                    if(szam == lsz[i]) 
                    {
                        van = true;
                        break;
                    }
                }
                if(!van)   //ha hamis maradt a van változó értéke
                {
                    lsz[db++] = szam;
                }
            }
            return lsz;
        }
        /*
         Amennyiben a metódus vagy osztályváltozó előtt nem szerepel a static minősítés, akkor az dinamikus, és így csakis
        példányosítás után használható:

        Esetünkben: Program.Main (mivel statikus, nem igényel példányosítást
        hivatkozhatunk az ilyenekre az osztály/class nevét minősítésként használva.
        Ellenben a (new Program
         */
        static string Datumbeolvaso()
        {
            
            Console.Write("Kérek egy dátumot (éééé-hh--nn): ");
            string datum = "";
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.KeyChar == '1' || cki.KeyChar == '2')
                {
                    Console.Write(cki.KeyChar);
                    datum += cki.KeyChar;
                    break;
                }
            }
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (datum[0]=='1' && cki.KeyChar == '9' || datum[0] == '2' && cki.KeyChar == '0')
                {
                    Console.Write(cki.KeyChar);
                    datum += cki.KeyChar;
                    break;
                }
            }
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                //if (datum[1] == '9' && cki.KeyChar >= '2' && cki.KeyChar<='9' || datum[1] == '0' && cki.KeyChar >= '0' && cki.KeyChar <= '2')
                if (cki.KeyChar == '-')
                 {
                    Console.Write(cki.KeyChar);
                    datum += cki.KeyChar;
                    break;
                }
            }
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.KeyChar == '0' || cki.KeyChar == '1')
                {
                    Console.Write(cki.KeyChar);
                    datum += cki.KeyChar;
                    break;
                }
            }
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (datum[5] == '0' && cki.KeyChar >= '1' && cki.KeyChar >= '9' || datum[5] == '1' && cki.KeyChar >= '0' && cki.KeyChar >= '2')
                {
                    Console.Write(cki.KeyChar);
                    datum += cki.KeyChar;
                    break;
                }
            }
            return datum;
        }
    }
}
