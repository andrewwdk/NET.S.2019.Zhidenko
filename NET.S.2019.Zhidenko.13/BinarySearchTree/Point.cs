using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        /// <summary> Calculate square distance from start point (0, 0).</summary>
        /// <returns> Square distance. </returns>
        public int SquareDistanceFromStartPoint()
        {
            return (this.X * this.X) + (this.Y * this.Y);
        }
    }
}
