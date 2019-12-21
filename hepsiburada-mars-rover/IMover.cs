using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace hepsiburada_mars_rover
{
    public interface IMover
    {
        bool Go(KeyValuePair<int, int> maxPoints, string moves);
        List<Directions> GetEnumList();
    }
}