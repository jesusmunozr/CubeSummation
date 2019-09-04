namespace CubeSummation.Services
{
    public interface IOperationCreator
    {
        OperationBase CreateOperation(string operation);
    }
}
