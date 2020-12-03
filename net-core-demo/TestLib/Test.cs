using System;
using System.Diagnostics;

namespace TestLib
{
    public class Test
    {
        public static void Print(string msg)
        {
            Debug.WriteLine(msg);

            Console.WriteLine(msg);
        }
    }
}
