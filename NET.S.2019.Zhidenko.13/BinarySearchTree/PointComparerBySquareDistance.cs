using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class PointComparerBySquareDistance : IComparer<Point>
    {
        /// <summary> Compare two points.</summary>
        /// <param name="firstPoint"> First point. </param>
        /// <param name="secondPoint"> Second point. </param>
        /// <returns> Comparison result. </returns>
        public int Compare(Point firstPoint, Point secondPoint)
        {
            if (firstPoint.SquareDistanceFromStartPoint() < secondPoint.SquareDistanceFromStartPoint())
            {
                return -1;
            }

            if (firstPoint.SquareDistanceFromStartPoint() > secondPoint.SquareDistanceFromStartPoint())
            {
                return 1;
            }

            return 0;
        }
    }
}
