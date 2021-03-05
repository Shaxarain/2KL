using System;

namespace _2KL
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas = new int[10] {3, 8, 7, 23, 17, 24, 10, 9, 55, 13};
            int sum = 0;
            for(int i = 0; i<mas.Length; i++)
            {
                isPrime(mas[i]);
                isEven(mas[i]);
                sum += mas[i];
            }
            Console.WriteLine("Сумма чисел массива = " + sum);
        }
        public static void isPrime(int x)
        {
            var prime = true;
            for (int i = 2; i < x; i++)
            {
                if (x % i == 0)
                {
                    Console.WriteLine(x + " is not prime");
                    prime = false;
                    break;
                }
            }
            if (prime == true)
            {
                Console.WriteLine(x + " is prime");
            }
        }
        public static void isEven(int y)
        {
            if (y % 2 == 0)
            {
                Console.WriteLine(y + " is even");
            }
            else
            {
                Console.WriteLine(y + " is not even");
            }
        }
    }
}
