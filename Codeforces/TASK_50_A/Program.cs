using System;
using System.Linq;

namespace TASK_50_A
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console
                .ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine((numbers[0] * numbers[1]) / 2);
        }
    }
}
