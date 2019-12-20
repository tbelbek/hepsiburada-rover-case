using System.ComponentModel;

namespace hepsiburada_mars_rover
{
    public enum Directions
    {
        [Description("N")]
        North = 0,
        [Description("E")]
        East = 1,
        [Description("S")]
        South = 2,
        [Description("W")]
        West = 3
    }
}