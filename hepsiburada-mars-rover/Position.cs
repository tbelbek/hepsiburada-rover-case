using System;
using System.Collections.Generic;
using System.Linq;

namespace hepsiburada_mars_rover
{
    public class Mover : IMover
    {
        public int XCoord { get; set; }
        public int YCoord { get; set; }
        public Directions Direction { get; set; }

        public Mover()
        {
            XCoord = YCoord = 0;
            Direction = Directions.North;
        }

        private void Rotate90Left()
        {
            var index = GetEnumList().IndexOf(this.Direction) - 1 < 0
                ? GetEnumList().ToList().Count - 1
                : GetEnumList().IndexOf(this.Direction) - 1;
            this.Direction = GetEnumList()[index];
        }

        private void Rotate90Right()
        {
            var index = GetEnumList().IndexOf(this.Direction) + 1 > GetEnumList().ToList().Count - 1
                ? 0
                : GetEnumList().IndexOf(this.Direction) + 1;
            this.Direction = GetEnumList()[index];
        }

        private void MoveOne()
        {
            switch (this.Direction)
            {
                case Directions.North:
                    this.YCoord += 1;
                    break;
                case Directions.South:
                    this.YCoord -= 1;
                    break;
                case Directions.East:
                    this.XCoord += 1;
                    break;
                case Directions.West:
                    this.XCoord -= 1;
                    break;
            }
        }

        public void Go(KeyValuePair<int, int> maxPoints, string moves)
        {
            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'M':
                        this.MoveOne();
                        break;
                    case 'L':
                        this.Rotate90Left();
                        break;
                    case 'R':
                        this.Rotate90Right();
                        break;
                    default:
                        Console.WriteLine($"Wrong input. {move}");
                        break;
                }

                if (this.XCoord >= 0 && this.XCoord <= maxPoints.Key && this.YCoord >= 0 && this.YCoord <= maxPoints.Value) continue;

                throw new Exception($"You're trying to get out? You should be inside coordinates (0 , 0) and ({maxPoints.Key} , {maxPoints.Value})");
            }
        }

        public List<Directions> GetEnumList()
        {
            return Enum.GetValues(typeof(Directions)).Cast<Directions>().ToList();
        }
    }
}
