using System;

namespace Day01
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Tugas 1");
            Console.Write("masukan tinggi segitiga : ");
            int t = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Tugas 1 A");
            for (int i = t; i >= 1; i--)
            {
                for (int j = t; j >= i; j--)
                {
                    Console.Write(" ");
                }

                for (int k = 1; k <= i; k++)
                {
                    Console.Write("*");
                }

                Console.WriteLine(" ");
            }
            Console.WriteLine("Tugas 1 B");
            for (int i = t; i >= 1; i--)
            {
                for (int j = i - 1; j >= 1; j--)
                {
                    Console.Write(" ");
                }

                for (int k = t; k >= i; k--)
                {
                    Console.Write("*");
                }

                Console.WriteLine("");
            }

            Console.WriteLine("\nTugas 2");
            Console.Write("masukan angka maksimal : ");
            int maxNum = Convert.ToInt32(Console.ReadLine());

            for (int i = maxNum; i >= 1; i--)
            {
                for (int j = i; j >= 1; j--)
                {
                    Console.Write(j);
                    if (j == 1)
                    {
                        for (int k = 1 + 1; k <= i; k++)
                        {
                            Console.Write(k);
                        }
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine("\nTugas 3 ShowPrimeNumber");
            Console.Write("masukan jumlah angka : ");
            int maxNumb = Convert.ToInt32(Console.ReadLine());
            ShowPrimeNumber(maxNumb);

            Console.WriteLine("\n\nTugas 4 Find Divisor");
            Console.Write("masukan jumlah angka : ");
            int divided = Convert.ToInt32(Console.ReadLine());
            FindDivisor(divided);

            Console.WriteLine("\n\nTugas 5 Show Deret");
            Console.Write("masukan jumlah deret : ");
            int countNumb = Convert.ToInt32(Console.ReadLine());
            ShowDeret(countNumb);

            Console.WriteLine("\n\nTugas 6 Show Other Deret");
            Console.Write("masukan jumlah deret : ");
            int countNumb2 = Convert.ToInt32(Console.ReadLine());
            ShowDeret2(countNumb2);

            Console.WriteLine("\n\nTugas 7 Perfect Number");
            Console.Write("masukan angka : ");
            int numb = Convert.ToInt32(Console.ReadLine());
            PerfectNumber(numb);

            Console.WriteLine("\n\nTugas 8 Is Palindrome");
            Console.Write("masukan angka : ");
            int numbs = Convert.ToInt32(Console.ReadLine());
            IsPalindrome(numbs);
        }

        public static void ShowPrimeNumber(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                int isPrime = 0;

                // Check if i is prime
                for (int j = 1; j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime += 1;
                    }
                }

                // Print if prime

                if (isPrime == 2)
                {
                    Console.Write(i + " ");
                }
            }
        }

        public static void FindDivisor(int num)
        {
            for (int i = 1; i <= num/2; i++)
            {
                if (num % i == 0 )
                {
                    Console.Write(i + " ");
                }
            }
        }

        public static void ShowDeret(int num)
        {
            int x;
            x = num;
            int lim;
            for (int i = 1; i <= num; i++)
            {
                if (num % 2 != 0)
                {
                    lim = num / 2 + 1;
                }
                else
                {
                    lim = num / 2;
                }
                for (int j = 1; j <= lim; j++)
                {
                    Console.Write(i + " " + x + " ");
                }
                x--;
                Console.WriteLine();
            }
        }

        public static void ShowDeret2(int num)
        {
            int x;
            x = num;
            int lim;
            for (int i = 1; i <= num; i++)
            {
                if (num % 2 != 0)
                {
                    lim = num / 2 + 1;
                }
                else
                {
                    lim = num / 2;
                }
                for (int j = 1; j <= num; j++)
                {
                    if (i % 2 == 0 && j % 2 == 0)
                    {
                        Console.Write($"- ");
                    }
                    else if (i % 2 == 0 && j % 2 != 0)
                    {
                        Console.Write($"{j} ");
                    }
                    else if (i % 2 != 0 && j % 2 == 0)
                    {
                        Console.Write($"{j} ");
                    }
                    else
                    {
                        Console.Write($"- ");
                    }
                }
                x--;
                Console.WriteLine();
            }
        }

        public static void PerfectNumber(int num)
        {
            int val = 0;

            for (int i = 1; i <= num/2; i++)
            {
                if (num % i == 0)
                {
                    val += i;
                }
            }
            if (val == num)
            {
                Console.WriteLine($"{val} is perfect number");
            }
            else
            {
                Console.WriteLine($"{num} is NOT perfect number");
            }
        }

        static void IsPalindrome(int num)
        {
            int reversed = 0;
            int original = num;

            while (num > 0)
            {
                Console.WriteLine($"num : {num}");
                int remainder = num % 10;
                Console.WriteLine($"reminder = {remainder}");
                reversed = reversed * 10 + remainder;
                Console.WriteLine($"reversed : {reversed}");
                num /= 10;
                Console.WriteLine($"num : {num}");
            }

            if (reversed == original)
            {
                Console.WriteLine($"{original} is Palindrome");
            }
            else
            {
                Console.WriteLine($"{original} is NOT Palindrome");
            }
        }
    }
}