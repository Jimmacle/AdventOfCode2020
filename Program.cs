using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode2020
{
    public abstract class Day
    {
        public abstract void Run();

        protected string InputFile()
        {
            return $"{GetType().Name}\\input.txt";
        }

        protected IEnumerable<string> InputLines()
        {
            using var f = File.OpenText(InputFile());
            string s;
            while ((s = f.ReadLine()) != null)
                yield return s;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var days = typeof(Program).Assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(Day))).OrderBy(x => x.Name).ToArray();

            Console.WriteLine(string.Join("\n", days.Select(x => x.Name)));
            Console.Write("Select Day: ");
            var type = days[int.Parse(Console.ReadLine()) - 1];
            ((Day)Activator.CreateInstance(type)).Run();
        }
    }
}