using System;
using System.Collections.Generic;

class Carte
{
    public string Titlu, Autor, ISBN;
    public Carte(string t, string a, string i) => (Titlu, Autor, ISBN) = (t, a, i);
}
class Biblioteca
{
    private readonly List<Carte> carti = new List<Carte>();
    public void AdaugaCarte() => carti.Add(new Carte(Read("Titlu"), Read("Autor"), Read("ISBN")));
    public void EliminaCarte()
    {
        string isbn = Read("ISBN de eliminat");
        int removed = carti.RemoveAll(c => c.ISBN == isbn);
        Console.WriteLine(removed > 0 ? $"Cartea cu ISBN-ul {isbn} a fost eliminată." : $"Cartea cu ISBN-ul {isbn} nu a fost găsită.");
    }

    public void AfiseazaCarti() => carti.ForEach(c => Console.WriteLine($"{c.Titlu} ({c.Autor})"));

    private static string Read(string prompt) { Console.Write($"Introduceți {prompt}: "); return Console.ReadLine(); }
}
class Program
{
    static void Main()
    {
        Biblioteca biblioteca = new Biblioteca();
        while (true)
        {
            Console.WriteLine("Ce doriți să executați?\n1) Adaugă o carte?\n2) Elimină o carte?\n3) Afișează cărțile din bibliotecă?\n4) Termină");
            switch (Console.ReadLine())
            {
                case "1": biblioteca.AdaugaCarte(); break;
                case "2": biblioteca.EliminaCarte(); break;
                case "3": biblioteca.AfiseazaCarti(); break;
                case "4": Environment.Exit(0); break;
                default: Console.WriteLine("Opțiune invalidă. Introduceți un număr valid."); break;
            }
            Console.Write("Doriți să continuați? (da/nu): ");
            if (Console.ReadLine().ToLower() == "nu") Environment.Exit(0);
        }
    }
}