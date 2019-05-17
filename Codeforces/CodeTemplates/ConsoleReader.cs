using System;
using System.Linq;

namespace CodeTemplates
{
    public class ConsoleReader
    {
        public static int[] ReadArray()
        {
            return Console
                .ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        public static int ReadOne()
        {
            return int.Parse(Console.ReadLine());
        }
    }
}
