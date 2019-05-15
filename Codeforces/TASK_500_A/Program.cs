using System;
using System.Linq;

namespace TASK_500_A
{
    class Program
    {
        static void Main(string[] args)
        {
            var l1 = ReadArray();
            var target = l1[1];

            var array = ReadArray();

            bool visited = false;


            for (var i = 0; i < array.Length;)
            {
                if (target == (i + 1)) visited = true;
                if (target == (i + 1 + array[i])) visited = true;
                i += array[i];

                if (visited) break;
            }

            Console.WriteLine(visited ? "YES" : "NO");
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
