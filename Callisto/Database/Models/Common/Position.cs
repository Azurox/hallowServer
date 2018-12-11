using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Database.Models.Common
{
    public class Position
    {
        public int X;
        public int Y;

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + X.GetHashCode();
            hash = (hash * 7) + Y.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            return obj is Position other && other.X == this.X && other.Y == this.Y;
        }
    }
}
