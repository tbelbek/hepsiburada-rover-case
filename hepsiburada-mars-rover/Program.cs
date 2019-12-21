using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace hepsiburada_mars_rover
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var boundaries = Mover.CreateBoundaries(text);

            while (true)
            {
                var startPositions = Console.ReadLine();
                var moves = Console.ReadLine()?.ToUpper();

                if (!Mover.CheckInputPattern(startPositions,
                    $"[0-{boundaries.Key}]\\s[0-{boundaries.Value}]\\s[NSWEnswe]"))
                {
                    Console.WriteLine($"{startPositions} is invalid for start position.");
                }
                else if (Mover.CheckInputPattern(moves, "[^MLR]"))
                {
                    Console.WriteLine($"{moves} contains invalid moves.");
                }
                else
                {
                    Mover.MoveProcess(startPositions, boundaries, moves);
                }
            }
        }


    }
}
