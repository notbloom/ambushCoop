using System.Collections.Generic;

namespace Ambush
{
    public class HexOperations
    {
        public static List<Hex> Circle(Hex center, int radius)
        {
            var result = new List<Hex>();
            for (int i = 0; i <= radius; i++)
            {
                result.AddRange(Ring(center, i));
            }
            return result;
        }

        public static List<Hex> Ring(Hex center, int radius)
        {
            var result = new List<Hex>();
            if (radius <= 0)
            {
                result.Add(center);
                return result;
            }

            var hex = center + Hex.Scale(Hex.Direction(4), radius);
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < radius; j++)
                {
                    result.Add(hex);
                    hex = hex.Neighbour(hex, i);
                }   
            }
            return result;
        }
    }
}