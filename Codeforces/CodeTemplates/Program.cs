using System;
using System.Linq;

namespace CodeTemplates
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static int[] ReadArray()
        {
            return Console
                .ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
