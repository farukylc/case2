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
            int[] kurtDizisi = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

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

        foreach (int kurtID in kurtDizisi)
        {
            if (tespitSayilari.ContainsKey(kurtID))
                tespitSayilari[kurtID]++;
            else
                tespitSayilari[kurtID] = 1;
        }

        int enCokTespitEdilenID = tespitSayilari
            .OrderByDescending(x => x.Value)
            .ThenBy(x => x.Key)
            .First().Key;

        return enCokTespitEdilenID;
    }
}