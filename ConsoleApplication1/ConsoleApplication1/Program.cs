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

            byte[] kurtDizisi = kurtGiris.Replace(" ", "")
                .Select(c => Convert.ToByte(c.ToString()))
                .ToArray();
            if (kurtDizisi.Length != n)
            {
                Console.WriteLine($"Girilen kurt türü sayısı {n} ile eşleşmiyor. Lütfen doğru sayıda kurt türü girin.");
                return;
            }

            byte sonuc = MostRepeatedID(kurtDizisi);
            Console.WriteLine("En Çok Tespit Edilen En Küçük ID: " + sonuc);
        }
        else
        {
            Console.WriteLine("Geçersiz dizi boyutu. Lütfen pozitif bir tamsayı girin.");
        }
    }

    static byte MostRepeatedID(byte[] kurtDizisi)
    {
        Dictionary<byte, byte> tespitSayilari = new Dictionary<byte, byte>();

        for (byte i = 0; i < kurtDizisi.Length; i++)
        {
            byte kurtID = kurtDizisi[i];

            if (tespitSayilari.ContainsKey(kurtID))
                tespitSayilari[kurtID]++;
            else
                tespitSayilari.Add(kurtID, 1);
        }

        byte enCokTespitEdilenID = tespitSayilari
            .OrderByDescending(x => x.Value)
            .ThenBy(x => x.Key)
            .First().Key;

        return enCokTespitEdilenID;
    }
}