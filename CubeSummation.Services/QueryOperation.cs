using CubeSummation.Services.Values;
using System;
using System.Collections.Generic;

namespace CubeSummation.Services
{
    public class QueryOperation : OperationBase
    {
        public override long Execute(string[] parts, int[,,] matrix, List<Position> positionsUsed)
        {
            var x1 = Convert.ToInt32(parts[1]);
            var y1 = Convert.ToInt32(parts[2]);
            var z1 = Convert.ToInt32(parts[3]);
            var x2 = Convert.ToInt32(parts[4]);
            var y2 = Convert.ToInt32(parts[5]);
            var z2 = Convert.ToInt32(parts[6]);

            long sum = 0;

            foreach (var p in positionsUsed)
            {
                if ((p.x >= x1 && p.x <= x2) && (p.y >= y1 && p.y <= y2) && (p.z >= z1 && p.z <= z2))
                {
                    sum += matrix[p.x - 1, p.y - 1, p.z - 1];
                }
            }

            return sum;
        }
    }
}