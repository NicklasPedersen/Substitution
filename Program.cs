using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypte
{
    class Program
    {
        public static string RotateLetters(string str, int rotateAmount)
        {
            int alphabetlength = 'Z' - 'A';
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                // ascii characters from the non-extended set is < 128
                if (char.IsLetter(c) && c < 128)
                {
                    char encrypted = (char)((char.ToLower(c) + rotateAmount - 'a') % alphabetlength + 'a');
                    if (char.IsUpper(c))
                    {
                        encrypted = char.ToUpper(encrypted);
                    }
                    sb.Append(encrypted);
                }
                else // the value is not an ascii character so we just append it to the output
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
        public static string Encrypt(string plaintext, int rotateAmount)
        {
            // this method is just for clarity
            return RotateLetters(plaintext, rotateAmount);
        }
        public static string Decrypt(string encryptedStr, int rotateBackAmount)
        {
            int alphabetlength = 'Z' - 'A';
            // rotating back n is the same as rotating forward (length - n) % length and it also doesn't result in a negative value
            int rotate = alphabetlength - rotateBackAmount;
            return RotateLetters(encryptedStr, rotate);
        }
        static void Main(string[] args)
        {
            string start = "Testing, this is a testy test that is testing the eNcrypTiOn aNd deCryption meThods";
            string encrypted = Encrypt(start, 10);
            string decrypted = Decrypt(encrypted, 10);
            Console.WriteLine(start);
            Console.WriteLine(encrypted);
            Console.WriteLine(decrypted);
            Console.ReadLine();
        }
    }
}
