using System.Globalization;

namespace Day02
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Tugas 1 ~ Remove Dupicate");
            Console.Write("Masukan Kata : ");
            string word = Console.ReadLine();
            RemoveDupicate(word);

            Console.WriteLine("Tugas 2 ~ Capitalize");
            Console.Write("Masukan Kata : ");
            string word2 = Console.ReadLine();
            Capitalize(word2);
        }

        private static void RemoveDupicate(string word)
        {
            Char[] chars = word.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                bool isDuplicate = false;

                for (int j = i + 1; j < chars.Length; j++)
                {
                    if (chars[i] == chars[j])
                    {
                        isDuplicate = true;
                        break;
                    }
                }
                if (!isDuplicate)
                {
                    Console.WriteLine(chars[i]);
                }
            }
        }

        private static void Capitalize(string word)
        {
            string lowerCaseWord = word.ToLower();
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            Console.WriteLine(textInfo.ToTitleCase(lowerCaseWord));
        }
    }
}