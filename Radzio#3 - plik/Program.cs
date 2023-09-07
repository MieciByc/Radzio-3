using System;
using System.Collections.Generic;
using System.IO; // Do obsługi operacji na plikach

class Program
{
    static void Main()
    {
        List<string> MojaListaDefault = WczytajListeZRoznegoPliku("C:\\Users\\Przemysław Molenda\\source\\repos\\Radzio#3 - plik\\Text-ListaDodatkow.txt");

        if (MojaListaDefault == null)
        {
            Console.WriteLine("Błąd wczytywania pliku.");
            return;
        }

        int licznik = MojaListaDefault.Count;
        Console.WriteLine("Lista rzeczy:");

        // Wyświetl dostępne rzeczy z listy
        for (int lp = 0; lp < MojaListaDefault.Count; lp++)
        {
            Console.WriteLine($"{lp + 1}. {MojaListaDefault[lp]}");
        }

        List<int> WyboryKlienta = new List<int>();

        while (true)
        {
            Console.Write("Wybierz Dodatek lub wpisz 'koniec' aby zakończyć: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "koniec")
            {
                break; // Zakończ pętlę, jeśli użytkownik wpisał "koniec".
            }

            if (int.TryParse(input, out int liczba) && liczba <= licznik)
            {
                WyboryKlienta.Add(liczba);
                Console.WriteLine($"Dodano dodatek {MojaListaDefault[liczba - 1]} do listy.");
            }
            else if (liczba > licznik)
            {
                Console.WriteLine("Podałeś błędną liczbę");
            }
            else
            {
                Console.WriteLine("Wpisz nr dodatku, nie jego nazwę. Spróbuj ponownie.");
            }
        }

        // Wyświetlenie zawartości listy:
        Console.WriteLine("Twoje Dodatki to:");
        foreach (int liczba in WyboryKlienta)
        {
            Console.WriteLine(MojaListaDefault[liczba - 1]);
        }
    }

    static List<string> WczytajListeZRoznegoPliku(string sciezkaDoPliku)
    {
        try
        {
            // Odczytaj wszystkie linie z pliku
            string[] linie = File.ReadAllLines(sciezkaDoPliku);
            return new List<string>(linie);
        }
        catch (IOException)
        {
            return null; // W razie błędu zwróć null
        }
    }
}
