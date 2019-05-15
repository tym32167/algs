using System;

namespace TASK_231_A
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = ReadOne();
            var ret = 0;

            for (int i = 0; i < n; i++)
            {
                int cnt = 0;
                var str = Console.ReadLine();
                if (str[0] == '1') cnt++;
                if (str[2] == '1') cnt++;
                if (str[4] == '1') cnt++;

                if (cnt >= 2) ret++;
            }

            Console.WriteLine(ret);
        }

        public static int ReadOne()
        {
            return int.Parse(Console.ReadLine());
        }
    }
}
