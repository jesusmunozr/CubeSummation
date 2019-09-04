using CubeSummation.Services.Values;
using System;
using System.Collections.Generic;

namespace CubeSummation.Services
{
    public class UpdateOperation : OperationBase
    {
        public override long Execute(string[] parts, int[,,] matrix, List<Position> positionsUsed)
        {
            var x1 = Convert.ToInt32(parts[1]);
            var y1 = Convert.ToInt32(parts[2]);
            var z1 = Convert.ToInt32(parts[3]);
            var w = Convert.ToInt32(parts[4]);

            matrix[x1 - 1, y1 - 1, z1 - 1] = w;
            var val = new Position() { x = x1, y = y1, z = z1 };
            var index = positionsUsed.IndexOf(val);
            if (index == -1)
            {
                positionsUsed.Add(new Position() { x = x1, y = y1, z = z1 });
            }

            return w;
        }
    }
}