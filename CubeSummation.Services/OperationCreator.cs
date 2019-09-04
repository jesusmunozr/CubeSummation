using System;

namespace CubeSummation.Services
{
    public class OperationCreator : IOperationCreator
    {
        public OperationBase CreateOperation(string operation)
        {
            switch (operation.ToUpper())
            {
                case "QUERY":
                    return new QueryOperation();
                //break;
                case "UPDATE":
                    return new UpdateOperation();
                //break;
                default:
                    throw new ArgumentException("Operation not supported.");
            }
        }
    }
}
