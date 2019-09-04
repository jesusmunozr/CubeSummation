using System.Collections.Generic;

namespace CubeSummation.Services
{
    public interface ITestCaseService
    {
        List<long> Execute(string content);
    }
}
