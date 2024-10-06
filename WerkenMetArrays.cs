using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OefeningenDotNet
{
    internal class WerkenMetArrays
    {
        public static void Main()
        {
            arrayVullen();

        }
        static void arrayVullen()
        {
            int[] eersteArray = new int[4];
            int index = 0;

            Console.WriteLine("Vul de array met 4 waarden:");
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"Waarde {i + 1}: ");
                eersteArray[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Wilt u een nieuwe waarde toevoegen? (ja/nee)");
            string keuze = Console.ReadLine();

            while (keuze.Equals("ja"))
            {
                Console.Write("Geef een waarde in voor een extra element: ");
                int nieuweWaarde = int.Parse(Console.ReadLine());

                int[] nieuweArray = new int[eersteArray.Length + 1];


                for (int j = 0; j < eersteArray.Length; j++)
                {
                    nieuweArray[j] = eersteArray[j];
                }

                nieuweArray[nieuweArray.Length - 1] = nieuweWaarde;

                eersteArray = nieuweArray;

                Console.WriteLine("Elementen in array: ");

                foreach (int n in eersteArray)
                {
                    Console.WriteLine(n);
                }

                Console.WriteLine("Wilt u nog een element toevoegen?");
                keuze = Console.ReadLine();
            }
        }
    }
}
