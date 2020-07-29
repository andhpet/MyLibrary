using System;
using System.Collections.Generic;
using MyLibrary;

namespace MultiMapRider
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Alan Turing!");

            MyDictionary<int, int> mdFirst = new MyDictionary<int, int>(7, 8);
            mdFirst.Add(7, 15);
            mdFirst.Add(7, 3);
            MyDictionary<int, int> mdSecond = new MyDictionary<int, int>(17, 18);
            var mdTrd = mdFirst.Union(mdSecond);

            var list = mdFirst.Get(7);

            List<int> interVal = mdTrd.IntersectValues(7,17);
            list = mdFirst.Get(7);
            //.......
        }
    }
}
