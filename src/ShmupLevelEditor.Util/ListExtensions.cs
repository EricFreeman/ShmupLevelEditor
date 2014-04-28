using System.Collections.Generic;
using System.Linq;

namespace ShmupLevelEditor.Util
{
    public static class ListExtensions
    {
        public static bool IsInOrder(this List<float> l)
        {
            for (int i = 0; i < l.Count() - 1; i++)
            {
                if (l[i] > l[i + 1]) return false;
            }

            return true;
        }
    }   
}
