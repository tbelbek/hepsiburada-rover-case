using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;

namespace hepsiburada_mars_rover
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var boundaries = new KeyValuePair<int, int>(Convert.ToInt32(text?.Trim().Split(' ')[0]),
                Convert.ToInt32(text?.Trim().Split(' ')[1]));

            while (true)
            {
                var regMatchCoord = new Regex($"[0-{boundaries.Key}]\\s[0-{boundaries.Value}]\\s[NSWEnswe]");
                var regMatchMove = new Regex("[MLR]");

                var startPositions = Console.ReadLine();
                var moves = Console.ReadLine()?.ToUpper();

                if (string.IsNullOrEmpty(startPositions) || !regMatchCoord.IsMatch(startPositions))
                {
                    Console.WriteLine($"{startPositions} is invalid for start position.");
                }
                else if (string.IsNullOrEmpty(startPositions) || !regMatchMove.IsMatch(moves))
                {
                    Console.WriteLine($"{moves} contains invalid moves.");
                }
                else
                {
                    var mover = new Mover
                    {
                        XCoord = Convert.ToInt32(startPositions.Split(' ')[0]),
                        YCoord = Convert.ToInt32(startPositions.Split(' ')[1]),
                        Direction = Enum.GetValues(typeof(Directions))
                            .Cast<Directions>()
                            .FirstOrDefault(v => v.GetDescription() == startPositions.ToUpper().Split(' ')[2])
                    };

                    mover.Go(boundaries, moves);

                    Console.WriteLine($"{mover.XCoord} {mover.YCoord} {mover.Direction.GetDescription()}");
                }
            }
        }
    }
}
