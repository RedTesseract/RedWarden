using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace RedWarden
{
    public class KeyGenerator
    {

        //metoda za generiranje nasumičnog niza znakova
        //ako je predani tip = 1, onda će u nizu biti i mala i velika slova. Ako je 2, onda će biti samo brojke

        public static string GetUniqueKey(int maxSize, int tip)
        {
            char[] chars = new char[62];
            if (tip == 1) chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            if (tip == 2) chars = "1234567890".ToCharArray();
            byte[] data = new byte[maxSize];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                //kriptografski siguran način generiranja bajtova
                // POGLEDATI ŠTO JE PSEUDO RANDOM BROJ
                crypto.GetNonZeroBytes(data);
            }
            
            StringBuilder result = new StringBuilder(maxSize);
            
            foreach (byte b in data)
            {
                //pretvaranje bajta u odgovarajući char i dodavanje u niz
                result.Append(chars[b % (chars.Length)]);
            }
            
            return result.ToString();
        }
    }
}
