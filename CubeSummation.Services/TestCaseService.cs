using CubeSummation.Services.Values;
using System;
using System.Collections.Generic;
using System.IO;

namespace CubeSummation.Services
{
    public class TestCaseService : ITestCaseService
    {
        List<Position> used = new List<Position>();
        List<long> result;
        IOperationCreator creator;

        public TestCaseService(IOperationCreator creator)
        {
            this.result = new List<long>();
            this.creator = creator;
        }

        public List<long> Execute(string content)
        {
            if (String.IsNullOrEmpty(content))
            {
                throw new ArgumentException("Content is empty.");
            }

            using (StringReader sr = new StringReader(content))
            {
                var testCases = Convert.ToInt32(sr.ReadLine());
                var testCaseConfig = sr.ReadLine();
                var testCaseConfigValues = testCaseConfig.Split(' ');
                var n = Convert.ToInt32(testCaseConfigValues[0]);
                var m = Convert.ToInt32(testCaseConfigValues[1]);

                for (var i = 1; i <= testCases; i++)
                {
                    int[,,] matrix = new int[n, n, n];

                    for (var q = 1; q <= m; q++)
                    {
                        var query = sr.ReadLine().Split(' ');
                        var operationToExecute = this.creator.CreateOperation(query[0]); // CreateOperation(query[0]);
                        if (query[0].ToUpper() == "QUERY")
                        {
                            this.result.Add(operationToExecute.Execute(query, matrix, this.used));
                        }
                        else
                        {
                            operationToExecute.Execute(query, matrix, this.used);
                        }
                    }
                    used.Clear();
                    testCaseConfig = sr.ReadLine();
                    if (!String.IsNullOrEmpty(testCaseConfig))
                    {
                        testCaseConfigValues = testCaseConfig.Split(' ');
                        n = Convert.ToInt32(testCaseConfigValues[0]);
                        m = Convert.ToInt32(testCaseConfigValues[1]);
                    }
                }
                return this.result;
            }
        }
    }
}