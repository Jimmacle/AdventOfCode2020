using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day03
{
    public struct Slope
    {
        public Slope(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public int X;
        public int Y;
    }
    
    public class Day03 : Day
    {
        private List<string> _lines;
        private const int LINE_LENGTH = 31;
        
        /// <inheritdoc />
        public override void Run()
        {
            _lines = InputLines().ToList();

            Part1();
            Part2();
        }

        public int CountTrees(Slope slope)
        {
            var x = 0;
            var y = 0;
            var trees = 0;

            while (y < _lines.Count)
            {
                var current = _lines[y][x % LINE_LENGTH];
                if (current == '#')
                    trees++;

                x += slope.X;
                y -= slope.Y;
            }

            return trees;
        }
        
        public void Part1()
        {
            Console.WriteLine(CountTrees(new Slope(3, -1)));
        }

        public void Part2()
        {
            var slopes = new[]
            {
                new Slope(1, -1),
                new Slope(3, -1),
                new Slope(5, -1),
                new Slope(7, -1),
                new Slope(1, -2),
            };
            
            var result = 1L;
            foreach (var slope in slopes)
            {
                result *= CountTrees(slope);
            }
            
            Console.WriteLine(result);
        }
    }
}