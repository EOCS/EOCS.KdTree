using EOCS.KdTree.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOCS.KdTree.Data.Distances
{
    public class EuclidianDistance : IDistance
    {
        public double DistanceBetween(Embedding e1, Embedding e2)
        {
            var dimension = e1.Records.Length; var distance = 0.0;
            for (var i = 0; i < dimension; i++)
            {
                distance = distance + Math.Pow(e1.Records[i]-e2.Records[i], 2);
            }

            return distance;
        }

        public double DistanceBetween(double d1, double d2)
        {
            return Math.Pow(d1-d2, 2);
        }
    }
}
