using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffineCipher
{
    class Program
    {
        public static char[] Alphabet = "aąbcćdeęfghijklłmnńoópqrsśtuvwyzźż".ToCharArray();

        private static List<char> Code = new List<char>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("a: ");
                int a = int.Parse(Console.ReadLine());
                Console.Write("b: ");
                int b = int.Parse(Console.ReadLine());
                Console.Write("Text to cipher: ");
                string s = Console.ReadLine();
                Code = GenerateCode(a, b, Alphabet);

                Console.WriteLine("Coded:" + Cipher(s,Alphabet,Code));

                Console.WriteLine("Decoded: " +  Decipher(s,Alphabet,Code));

                Console.ReadKey();
                Console.Clear();
            }


        }

        private static string Cipher(string text, char[] alphabet, List<char> code)
        {
            var b = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (' ' == char.Parse(text.Substring(i, 1)))
                    b.Append(" ");
                else
                {
                    char c = char.Parse(text.Substring(i, 1));
                    for (int j = 0; j < alphabet.Length; j++)
                    {
                        if (c == alphabet[j])
                            b.Append(code[j]);
                    }
                }
            }
            return b.ToString();
        }

        private static string Decipher(string text, char[] alphabet, List<char> code)
        {
            var b = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (' ' == char.Parse(text.Substring(i, 1)))
                    b.Append(" ");
                else
                {
                    char c = char.Parse(text.Substring(i, 1));
                    for (int j = 0; j < alphabet.Length; j++)
                    {
                        if (c == code[j])
                            b.Append(code[j]);
                    }
                }
            }
            return b.ToString();
        }

        private static List<char> GenerateCode(int a, int b, char[] alphabet)
        {
            var set = new HashSet<char>();

            for (int i = 0; i < alphabet.Length; i++)
            {
                set.Add(alphabet[((a * i) + b) % alphabet.Length]);
            }
            return set.ToList();
        }

    }
}
