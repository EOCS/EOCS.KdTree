using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOCS.KdTree.Data.Interfaces
{
    public interface IDistance
    {
        double DistanceBetween(Embedding e1, Embedding e2);

        double DistanceBetween(double d1, double d2);
    }
}
