using System;
using System.Collections.Generic;
using System.Linq;

namespace TASK_230_B
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1000000;
            var numbers = new bool[n + 1];
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = true;

            numbers[0] = false;
            numbers[1] = false;

            for (int i = 2; i <= n; ++i)
            {
                if (numbers[i])
                {
                    for (int j = i * 2; j <= n; j += i)
                    {
                        numbers[j] = false;
                    }
                }
            }

            var set = new HashSet<long>();

            for (int i = 0; i < numbers.Length; i++)
                if (numbers[i])
                    set.Add(1L * i * i);

            ReadOne();
            var arr = ReadArray();
            foreach (var a in arr)
            {
                if (set.Contains(a)) Console.WriteLine("YES");
                else Console.WriteLine("NO");
            }
        }

        public static long[] ReadArray()
        {
            return Console
                .ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();
        }


        public static int ReadOne()
        {
            return int.Parse(Console.ReadLine());
        }
    }
}
