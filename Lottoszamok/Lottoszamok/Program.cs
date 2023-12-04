using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Lottoszamok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int db = 0;
            while (true)
            {
                Console.Clear();//képernyő tartalmának törlése
                Console.Write("Hány tipp szükséges :");
                try
                {
                    db = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    continue;
                }
            }
           
          
            int db = Console.Read();
            Console.WriteLine(db);
            Random rand = new Random();
            for(int i= 1; i<=db;i++)
            {
                int[] lottoszamok = new int[5];
                Console.Write($"{i,2}.:");
                for (int j = 1; j <= 5; j++)
                {
                    int lsz = rand.Next(1, 90);
                    if (!lottoszamok.Contains(lsz))
                    {
                        Console.Write($"{lsz,3}");
                        lottoszamok[j - 1] = lsz;
                    }
                    else
                    {
                        j--;
                    }
                    
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
