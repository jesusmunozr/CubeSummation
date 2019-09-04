using System.ComponentModel.DataAnnotations;

namespace CubeSummation.Models
{
    public class ExecuteTestCaseModel
    {
        [Required(ErrorMessage = "Empty content is not allowed")]
        public string Content { get; set; }
    }
}