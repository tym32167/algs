using System;
using System.Text;

namespace TASK_281_A
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();
            var sb = new StringBuilder(line.Length);
            sb.Append(char.ToUpper(line[0]));
            for (var i = 1; i < line.Length; i++) sb.Append(line[i]);
            Console.WriteLine(sb.ToString());
        }
    }
}
