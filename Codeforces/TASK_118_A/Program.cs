using System;
using System.Collections.Generic;
using System.Text;

namespace TASK_118_A
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = Console.ReadLine();

            var sb = new StringBuilder();
            var chars = new HashSet<char>() { 'A', 'O', 'Y', 'E', 'U', 'I' };

            foreach (var c in str)
            {
                var u = char.ToUpper(c);
                if (chars.Contains(u)) continue;

                sb.Append('.');
                sb.Append(char.ToLower(c));
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
