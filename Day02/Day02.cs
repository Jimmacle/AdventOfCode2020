using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Day02
{
    struct PasswordPolicy
    {
        public int MinRepeat;
        public int MaxRepeat;
        public char Character;
        public string Password;
    }
    
    public class Day02 : Day
    {
        private List<PasswordPolicy> _passwords = new List<PasswordPolicy>();

        /// <inheritdoc />
        public override void Run()
        {
            foreach (var line in InputLines())
            {
                var password = new PasswordPolicy();
                var colonSplit = line.Split(':');
                password.Password = colonSplit[1].Trim();
                var spaceSplit = colonSplit[0].Split(' ');
                password.Character = spaceSplit[1][0];
                var tacSplit = spaceSplit[0].Split('-');
                password.MinRepeat = int.Parse(tacSplit[0]);
                password.MaxRepeat = int.Parse(tacSplit[1]);
                _passwords.Add(password);
            }
            
            Part1();
            Part2();
        }

        void Part1()
        {
            var valid = 0;
            foreach (var password in _passwords)
            {
                var count = 0;
                foreach (var ch in password.Password)
                {
                    if (ch == password.Character)
                        count++;
                }

                if (count >= password.MinRepeat && count <= password.MaxRepeat)
                    valid++;
            }
            
            Console.WriteLine(valid);
        }

        void Part2()
        {
            var valid = 0;
            foreach (var password in _passwords)
            {
                var count = 0;
                if (password.Password[password.MinRepeat - 1] == password.Character)
                    count++;
                if (password.Password[password.MaxRepeat - 1] == password.Character)
                    count++;

                if (count == 1)
                    valid++;
            }

            Console.WriteLine(valid);
        }
    }
}