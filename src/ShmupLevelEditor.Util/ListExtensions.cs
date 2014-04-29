using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ShmupLevelEditor.Util
{
    public static class ListExtensions
    {
        public static bool IsInOrder(this IList<float> l)
        {
            for (int i = 0; i < l.Count() - 1; i++)
            {
                if (l[i] > l[i + 1]) return false;
            }

            return true;
        }

        public static bool IsNotInOrder(this List<float> l)
        {
            return !l.IsInOrder();
        }

        public static ObservableCollection<T> MoveUp<T>(this ObservableCollection<T> l, T item)
        {
            var curri = l.IndexOf(item);

            if (curri == 0)
                return l; // do nothing since it's already at top

            var source = l[curri];
            var dest = l[curri - 1];

            l[curri] = dest;
            l[curri - 1] = source;

            return l;
        }

        public static ObservableCollection<T> MoveDown<T>(this ObservableCollection<T> l, T item)
        {
            var curri = l.IndexOf(item);

            if (curri == l.Count - 1)
                return l; // do nothing since it's already at top

            var source = l[curri];
            var dest = l[curri + 1];

            l[curri] = dest;
            l[curri + 1] = source;

            return l;
        }
    }   
}
