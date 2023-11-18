using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Dizi Boyutunu Girin: ");
        if (int.TryParse(Console.ReadLine(), out int n))
        {
            Console.Write("Kurt Türlerini Girin: ");
            string kurtGiris = Console.ReadLine();

            int[] kurtDizisi = kurtGiris.Replace(" ", "")
                .Select(c => int.Parse(c.ToString()))
                .ToArray();

            int sonuc = MostRepatedID(kurtDizisi);
            Console.WriteLine("En Çok Tespit Edilen En Küçük ID: " + sonuc);
        }
        else
        {
            Console.WriteLine("Geçersiz dizi boyutu. Lütfen bir tamsayı girin.");
        }
    }

    static int MostRepatedID(int[] kurtDizisi)
    {
        Dictionary<int, int> tespitSayilari = new Dictionary<int, int>();

        for (int i = 0; i < kurtDizisi.Length; i++)
        {
            int kurtID = kurtDizisi[i];

            if (tespitSayilari.ContainsKey(kurtID))
                tespitSayilari[kurtID]++;
            else
                tespitSayilari.Add(kurtID,1);
        }

        int enCokTespitEdilenID = tespitSayilari
            .OrderByDescending(x => x.Value)
            .ThenBy(x => x.Key)
            .First().Key;

        return enCokTespitEdilenID;
    }
}