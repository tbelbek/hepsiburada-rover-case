using System.Collections.Generic;

namespace hepsiburada_mars_rover
{
    public interface IMover
    {
        void Go(KeyValuePair<int, int> maxPoints, string moves);
    }
}