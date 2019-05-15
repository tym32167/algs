using System;

namespace TASK_71_A
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var word = Console.ReadLine();

                if (word.Length > 10)
                    word = $"{word[0]}{word.Length - 2}{word[word.Length - 1]}";

                Console.WriteLine(word);
            }
        }
    }
}
