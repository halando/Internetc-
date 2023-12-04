using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ablakos=System.Windows.Forms;
using System.Windows.Forms;

namespace Objektumok
{
    internal class Program
    {
        static Jarmu[] jarmuvek;
        static ablakos.Timer idozito;
        static void Main(string[] args)
        {
            Vezerles();
            return;
            string auto = "A-1";
            int vizsz = 67;
            int fugg = 28;
            Console.SetCursorPosition(vizsz, fugg);
            Console.Write(auto);
            // Console.ReadKey(true);    //true ott van megjelenik a leütött karakter, ha nics,akkor nem 
            ConsoleKeyInfo cki = Console.ReadKey(true);
            if(cki.Key == ConsoleKey.Enter)
            {
                while (true) 
                {
                    if(Console.KeyAvailable) 
                    {
                        cki= Console.ReadKey(true);
                        if (cki.Key == ConsoleKey.Escape) 
                        {
                            break;
                        }
                    }
                    if (vizsz > 3)      //3-asával csökkentés, amíg el nem éri a 3-at
                    {
                        vizsz -= 3;
                    }
                    Console.Clear();
                    Console.SetCursorPosition(vizsz, fugg);
                    Console.Write(auto);
                    Thread.Sleep(1000/16);     //Thread, mint szál, egy önálló folyamat része    //késleltetés millisecundumban, azaz 1 mmp-ig késleltet
                    /* az egyszerű animáció mp-enként egymástól valamenyire eltérő
                     * 16 képet tesznek láthatóvá, ami viszont az érzékelésünk következtében összemosódik,
                     * folytonos mozgás érzetét keltve 
                     */
                }
            }
            Auto a = new Auto();  //amennyiben egy osztály dinamikus, abból előbb egy példányt létre kell hozni
            a.Mozog();
        }
                static void Vezerles() 
        {
            /*for (int i = 0; i < Console.WindowWidth; i++) 
            {
                Console.Write(i % 10);
            }*/
            jarmuvek = new Jarmu[30];
            for(int i = 0; i < jarmuvek.Length; i++) 
            {
                jarmuvek[i] = new Jarmu("A-1");
                jarmuvek[i].Mutat();
            }
            idozito= new ablakos.Timer();
            idozito.Interval = 1000;  //thick eseménykezelő minden mp-ben megnézi
            idozito.Enabled = true;
            idozito.Tick += new EventHandler(Mozgatas);
            //idozito.Start();
            while(true)
            {
                //Thread.Sleep(10);
                Application.DoEvents();   //ilyesmire szükség lehet akkor is, amikor egy adatbázisból egy terjedelmes lekérdezési eredményhalmazt akarunk grafikus mezőben láttatni
                if (Console.KeyAvailable) 
                {
                    if(Console.ReadKey(true).Key == ConsoleKey.Escape) 
                    {
                        break;
                    }
                }
            }

        }
        static void Mozgatas(object sender,EventArgs e)
        { 
            idozito.Enabled = false;
            Console.Clear ();
            Console.SetCursorPosition(1, 1);
            Console.Write("*");
            for (int i = 0; i < jarmuvek.Length;i++) 
            {
                jarmuvek[i].Mozgat();
                jarmuvek[i].Mutat();
            }
            idozito.Enabled=true;
        }
    }
    class Auto  //mivel nincs sehol static szó, ez mindenképpen dinamikus
    {
        int sebesseg = 3;  //amennyiben sem public, sem private, sem protected minősítés nem szerepel, a 
        string rendszam = "A-1";    //ugyanez a Java-ban ún. package public, vagyis az egy packageben lévő osztályok hozzáérhetnek
        public void Mozog() 
        {
            Console.WriteLine("mozgok...");
        }
    }
    struct Helyzet   //Érték típus - a Stack/Verem memóriában tárolódik
    {
        int x;
        int y;
        public Helyzet(int x, int y) 
        {
            this.x= x;
            this.y= y;
        }
        public int X    // Az ilyen ún. property az osztályoknál is használható ellenőrzött módon
        {
            get         //tesszük lehetővé a privát tartalom lekérdezését(get) vagy beállítását (set)
            {
                return x;
            }
        }
        public int Y        //A Java csak ún. setter és getter metódusokat enged alkalmazni
        {
            get
            {
                return y;
            }
        }
    }
    class Jarmu     //Cím típus/Referencia típus - a Heap/Halom/szabad memória területen kerül elhelyezésre
    {
        Helyzet helyzet;        //deklarációk
        int sebesseg;
        string rendszam;
        static int peldanyszamlalo = 0;  //0 kezdőértéket adunk neki
        static Random vszg = new Random();
        public Jarmu(string rendszam)       //KONSTRUKTOR, amit a new műveletnél hasztnálunk fel az
        {
            helyzet = new Helyzet(vszg.Next(1,Console.WindowWidth), vszg.Next(1, 30));   //véletlenszám generátor
            sebesseg = vszg.Next(1, 5);
            //peldanyszamlalo++;
            this.rendszam = rendszam +(++peldanyszamlalo);  //prefix - előbb megnöveljük eggyel, aztán vesszük igyelembe
        }
        public void Mutat() 
        {
            Console.SetCursorPosition(helyzet.X, helyzet.Y);
            Console.WriteLine(rendszam);
        }

        public void Mozgat() 
        {
            if (helyzet.X > sebesseg)
            {
                helyzet = new Helyzet(helyzet.X - sebesseg, helyzet.Y);
            }
            else 
            {
                helyzet=new Helyzet(Console.WindowWidth-rendszam.Length, helyzet.Y);
            }
        }
    }
}
