using System.Collections.Generic;

namespace Ambush
{
    public static class Utilities
    {
        public static int[] FromTo(int from, int to)
        {
            var list = new List<int>();
            for (int i = from; i <= to; i++)
            {
                list.Add(i);
            }

            return list.ToArray();
        }

        public static ushort[] LeftColumn(int from, int to)
        {
            var list = new List<ushort>();
            for (int i = from; i <= to; i++)
            {
                if (i % 2 != 0)
                    continue;

                list.Add((ushort)i);
            }

            return list.ToArray();
        }
    }
}