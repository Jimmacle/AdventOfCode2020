using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020.Day01
{
    public class Day01 : Day
    {
        private List<int> _numbers = new List<int>();
        
        /// <inheritdoc />
        public override void Run()
        {
            using var f = File.OpenText(InputFile());
            string s;
            while ((s = f.ReadLine()) != null)
                _numbers.Add(int.Parse(s));
            
            Part1();
            Part2();
        }

        void Part1()
        {
            for (var i = 0; i < _numbers.Count; i++)
            for (var j = i + 1; j < _numbers.Count; j++)
            {
                if (_numbers[i] + _numbers[j] == 2020)
                {
                    Console.WriteLine(_numbers[i] * _numbers[j]);
                    return;
                }
            }
        }

        void Part2()
        {
            for (var i = 0; i < _numbers.Count; i++)
            for (var j = i + 1; j < _numbers.Count; j++)
            for (var k = j + 1; k < _numbers.Count; k++)
            {
                if (_numbers[i] + _numbers[j] + _numbers[k] == 2020)
                {
                    Console.WriteLine(_numbers[i] * _numbers[j] * _numbers[k]);
                    return;
                } 
            }
        }
    }
}