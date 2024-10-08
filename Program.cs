using System;
public class Boek
{
    public string Isbn { get; set; }
    public string Naam { get; set; }
    public string Uitgever { get; set; }
    public decimal Prijs;

    public Boek(string isbn, string naam, string uitgever, decimal prijs)
    {
        Isbn = isbn;
        Naam = naam;
        Uitgever = uitgever;
        Prijs = prijs;
    }

    public override string ToString()
    {
        return $"ISBN: {Isbn}, Naam: {Naam}, Uitgever: {Uitgever}, Prijs: {Prijs} euro";
    }   
    public virtual void Lees()
    {
        Console.WriteLine($"Lees boek: {Naam}");
    }
}

public enum Verschijningsperiode
{
    Dagelijks,
    Wekelijks,
    Maandelijks
}

public class Tijdschrift : Boek
{
    public Verschijningsperiode Verschijningsperiode { get; set; }

    public Tijdschrift(string isbn, string naam, string uitgever, decimal prijs, Verschijningsperiode verschijningsperiode)
        : base(isbn, naam, uitgever, prijs)
    {
        Verschijningsperiode = verschijningsperiode;
    }

    public override string ToString()
    {
        return base.ToString() + $", Verschijningsperiode: {Verschijningsperiode}";
    }

    public override void Lees()
    {
        Console.WriteLine($"Lees tijdschrift: {Naam}");
    }
}

public class Bestelling<T>
{
    private static int idTeller = 1;
    private int id { get; set; }
    private T boek { get; set; }
    private DateTime datum { get; set; }
    private int aantal { get; set; }
    private string periode { get; set; }

    public Bestelling(T boek, int aantal, string periode)
    {
        id = idTeller++;
        this.boek = boek;
        this.aantal = aantal;
        this.periode = periode;
        this.datum = DateTime.Now;
    }

    public (string isbn, int aantal, decimal totaalprijs) Bestel()
    {
        string isbn = (boek as Boek)?.Isbn;
        decimal totaalprijs = (boek as Boek)?.Prijs * aantal ?? 0;
        return (isbn, aantal, totaalprijs);
    }   
}

public class BestellingService
{
    public event Action<string> BoekBesteld;

    public void PlaatsBestelling<T>(Bestelling<T> bestelling)
    {
        var info = bestelling.Bestel();
        BoekBesteld?.Invoke($"Bestelling geplaatst: ISBN: {info.isbn}, Aantal: {info.aantal}, Totale prijs: {info.totaalprijs} euro ");
    }
}

namespace Opdracht1
{
    public class Boekenwinkel
    {
        public static void Main(string[] args)
        {
            BestellingService bestellingService = new BestellingService();
            bestellingService.BoekBesteld += message => Console.WriteLine(message);

            Boek boek1 = new Boek("51321", "Het eerste boek", "Uitgever Jan", 25);
            Boek boek2 = new Boek("45489465", "Het tweede boek", "Uitgever Jos", 30);
            Boek boek50 = new Boek("12332", "Het vijfstigste boek", "Uitgever Malik", 60);

            Tijdschrift tijdschrift1 = new Tijdschrift("842115", "Het eerste tijdschrift", "Uitgever Bob", 10, Verschijningsperiode.Wekelijks);

            Bestelling<Boek> bestelling1 = new Bestelling<Boek>(boek1, 2, "tien dagen");
            bestellingService.PlaatsBestelling(bestelling1);

            Bestelling<Tijdschrift> bestelling2 = new Bestelling<Tijdschrift>(tijdschrift1, 1, "Maandelijks");
            bestellingService.PlaatsBestelling(bestelling2);

            Bestelling<Boek> bestelling50 = new Bestelling<Boek>(boek50, 50, "een");
            bestellingService.PlaatsBestelling(bestelling50);
            boek50.Lees();
            Console.ReadKey();
        }
    }
}
