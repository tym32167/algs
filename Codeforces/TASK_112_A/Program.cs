using System;
namespace TASK_112_A
{
    class Program
    {
        static void Main(string[] args)
        {
            var l1 = Console.ReadLine();
            var l2 = Console.ReadLine();


            for (var i = 0; i < l1.Length; i++)
            {
                var ret = char.ToLower(l1[i]).CompareTo(char.ToLower(l2[i]));
                if (ret != 0)
                {
                    Console.WriteLine(ret < 0 ? -1 : 1);
                    return;
                }
            }

            Console.WriteLine(0);

        }
    }
}
