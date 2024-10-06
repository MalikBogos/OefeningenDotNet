using System;
using System.Linq;

public class Omkeren
    {
        public static void Main()
        {

            Console.WriteLine("Geef een tekst in:");
            string woord = Console.ReadLine();

            Console.WriteLine("Welke iteratiemethode wenst u te gebruiken?");
            Console.WriteLine("Optie 1: for-loop");
            Console.WriteLine("Optie 2: while-loop");
            Console.WriteLine("Optie 3: do-while-loop");
            Console.WriteLine("Optie 4: recursie");

            int keuze = Convert.ToInt32(Console.ReadLine());
            while(keuze < 1 ||  keuze > 4)
            {
                Console.WriteLine("Geef een getal in van 1 tot 4!");
                keuze = Convert.ToInt32(Console.ReadLine());
            }
            switch (keuze)
            {

            case 1:
            forLoop(woord);
            break;

            case 2:
            whileLoop(woord);
            break;

            case 3:
            doWhileLoop(woord);
            break;

            case 4:
            recursie(woord);
            break;

            default:
                Console.WriteLine("Ongeldige keuze");
                break;
            }
        }

        static void forLoop(string woord)
        {
        int lengte = woord.Length;
        for (int i = lengte - 1; i >= 0; i--)
        {
            Console.Write(woord[i]);
            lengte--;
        }
        Console.WriteLine();
        Console.ReadKey();
        }

        static void whileLoop(string woord)
        {
        int lengte = woord.Length;
        int i = lengte - 1;

        while(i >=  0)
        {
            Console.Write(woord[i]);
            i--;
        }
        Console.WriteLine();
        Console.ReadKey();
        }

        static void doWhileLoop(string woord) { 
        int lengte = woord.Length;
        int i = lengte - 1;

        do
        {
            Console.Write(woord[i]);
            i--;
        } while (i >= 0);
        Console.WriteLine();
        Console.ReadKey();
        }
        
        static void recursie(string woord)
        {
        if (woord.Length == 0)
        {
            Console.WriteLine();
            Console.ReadKey();
            return;
        }
        Console.Write(woord[woord.Length - 1]);

        recursie(woord.Substring(0, woord.Length - 1));
        }
}