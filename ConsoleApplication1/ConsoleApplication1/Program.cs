using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Dizi Boyutunu Girin: ");
            if (int.TryParse(Console.ReadLine(), out int arraySize))
            {
                Console.Write("Kurt Türlerini Girin: ");
                string wolfInput = Console.ReadLine();
                char[] charList = wolfInput.Replace(" ", "").ToCharArray();
                byte[] wolfArray = new byte[charList.Length];
                if (wolfArray.Length != arraySize)
                {
                    Console.WriteLine($"Girilen kurt türü sayısı {arraySize} ile eşleşmiyor. Lütfen doğru sayıda kurt türü girin.");
                    return;
                }

                for (int i = 0; i < charList.Length; i++)
                {
                    if (!byte.TryParse(charList[i].ToString(), out byte wolfID))
                    {
                        Console.WriteLine("Hatalı giriş");
                        System.Threading.Thread.Sleep(2000);
                        Environment.Exit(0);
                    }

                    wolfArray[i] = wolfID;
                }

                byte result = MostRepeatedID(wolfArray);
                Console.WriteLine("En Çok Tespit Edilen En Küçük ID: " + result);
            }
            else
            {
                Console.WriteLine("Geçersiz dizi boyutu. Lütfen pozitif bir tamsayı girin.");
            }
        }

        static byte MostRepeatedID(byte[] wolfArray)
        {
            Dictionary<byte, byte> detectionCounts = new Dictionary<byte, byte>();

            foreach (byte wolfID in wolfArray)
            {
                if (detectionCounts.ContainsKey(wolfID))
                    detectionCounts[wolfID]++;
                else
                    detectionCounts.Add(wolfID, 1);
            }

            byte mostDetectedID = detectionCounts
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .First().Key;

            return mostDetectedID;
        }
    }
}
