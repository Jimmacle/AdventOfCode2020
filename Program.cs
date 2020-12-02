using System;
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
    }

    class Program
    {
        static void Main(string[] args)
        {
            var days = typeof(Program).Assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(Day))).OrderBy(x => x.Name).ToArray();

            Console.WriteLine(string.Join("\n", days.Select(x => x.Name)));
            Console.WriteLine("Select Day: ");
            var type = days[int.Parse(Console.ReadLine()) - 1];
            ((Day)Activator.CreateInstance(type)).Run();
        }
    }
}