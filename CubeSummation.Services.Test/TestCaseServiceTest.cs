using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CubeSummation.Services.Test
{
    public class TestCaseServiceTest
    {
        [Fact]
        public void Execute_with_empty_content_will_fail()
        {
            var creator = new Mock<IOperationCreator>();
            creator.Setup(x => x.CreateOperation("UPDATE")).Returns(new UpdateOperation());
            creator.Setup(x => x.CreateOperation("QUERY")).Returns(new QueryOperation());

            var service = new TestCaseService(creator.Object);
            var ex = Assert.Throws<ArgumentException>(() => service.Execute(""));

            Assert.Equal("Content is empty.", ex.Message);
        }

        [Fact]
        public void Execute_test_case_with_correct_content_is_ok()
        {
            var content = new StringBuilder();
            content.AppendLine("2");
            content.AppendLine("4 5");
            content.AppendLine("UPDATE 2 2 2 4");
            content.AppendLine("QUERY 1 1 1 3 3 3");
            content.AppendLine("UPDATE 1 1 1 23");
            content.AppendLine("QUERY 2 2 2 4 4 4");
            content.AppendLine("QUERY 1 1 1 3 3 3");
            content.AppendLine("2 4");
            content.AppendLine("UPDATE 2 2 2 1");
            content.AppendLine("QUERY 1 1 1 1 1 1");
            content.AppendLine("QUERY 1 1 1 2 2 2");
            content.AppendLine("QUERY 2 2 2 2 2 2");

            var expectedResult = new List<long> { 4, 4, 27, 0, 1, 1 };

            var creator = new Mock<IOperationCreator>();
            creator.Setup(x => x.CreateOperation("UPDATE")).Returns(new UpdateOperation());
            creator.Setup(x => x.CreateOperation("QUERY")).Returns(new QueryOperation());

            var service = new TestCaseService(creator.Object);
            var result = service.Execute(content.ToString());

            Assert.Equal(expectedResult, result);
        }
    }
}
