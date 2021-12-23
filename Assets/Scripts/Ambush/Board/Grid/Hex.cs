using System;
using System.Drawing;
using UnityEngine;

namespace Ambush
{
    // struct Orientation {
    //     const double f0, f1, f2, f3;
    //     const double b0, b1, b2, b3;
    //     const double start_angle; // in multiples of 60°
    //     Orientation(double f0_, double f1_, double f2_, double f3_,
    //         double b0_, double b1_, double b2_, double b3_,
    //         double start_angle_)
    //         : f0(f0_), f1(f1_), f2(f2_), f3(f3_),
    //     b0(b0_), b1(b1_), b2(b2_), b3(b3_),
    //     start_angle(start_angle_) {}
    // };
    public struct Hex : IEquatable<Hex>
    {
        public int q; //y
        public int r; //x
        public int s => -q - r;

        public Hex(int q, int r)
        {
            this.q = q;
            this.r = r;
        }
        public Hex(int q, int r, int s)
        {
            //todo validate s?
            this.q = q;
            this.r = r;
        }
        public Vector2Int ToVector2Int() => new Vector2Int(q, r);

        public float Width(float size = 1f) => 2f * size;
        public float Height(float size = 1f) => Mathf.Sqrt(3) * size;
        
        public Vector3 FlatToVector3(float size = 1f)
        {
            var x = size * (3f / 2f * q);
            var y = size * (Mathf.Sqrt(3) / 2f * q + Mathf.Sqrt(3) * r);
            return new Vector3(x,0, y);
        }
        
        public static Hex[] Directions = new Hex[]{ new Hex(1, 0, -1), new Hex(1, -1, 0), new Hex(0, -1, 1),
        new Hex(-1, 0, 1), new Hex(-1, 1, 0), new Hex(0, 1, -1)
        };

        public static Hex Direction(int i)
        {
            if (i >= 0 && i < 6)
            {
                return Directions[i];
            }
            //todo send error;
            return Directions[0];
        }

        public Hex Neighbour(Hex hex, int direction) {
             return hex + Direction(direction);
        }

        public static Hex Scale(Hex hex, int factor)
        {
            return new Hex(hex.q * factor, hex.r * factor, hex.s * factor);
        }

        #region Operators
    
    public static Hex operator +(Hex a) => a;
    public static Hex operator +(Hex a, Hex b) => new Hex(a.q + b.q , a.r + b.r);
    
    public static Hex operator -(Hex a) => new Hex(-a.q, -a.r);
    public static Hex operator -(Hex a, Hex b) => new Hex(a.q - b.q , a.r - b.r);
    
    public static Hex operator *(Hex a, int i) => new Hex(a.q * i, a.r * i);    
        
    public int Length() => (int) ((Mathf.Abs(q) + Mathf.Abs(r) + Mathf.Abs(s)) / 2f);

    public static int Distance(Hex a, Hex b) => (a - b).Length();
     
        
        public bool Equals(Hex other)
        {
            return q == other.q && r == other.r;
        }

        public override bool Equals(object obj)
        {
            return obj is Hex other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (q * 397) ^ r;
            }
        }
        #endregion
    }
}