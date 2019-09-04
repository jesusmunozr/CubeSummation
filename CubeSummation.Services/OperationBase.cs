using CubeSummation.Services.Values;
using System.Collections.Generic;

namespace CubeSummation.Services
{
    public abstract class OperationBase
    {
        public abstract long Execute(string[] parts, int[,,] matrix, List<Position> positionsUsed);
    }
}