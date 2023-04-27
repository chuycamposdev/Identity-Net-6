
namespace Tickets.Application.Models
{
    public class OperationResult
    {
        public bool Succeeded { get; set; } = true;
        public string? Message { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public static OperationResult Error(string errorMessage)
        {
            return new OperationResult { Succeeded = false, Message = errorMessage };
        }

        public static OperationResult Success()
        {
            return new OperationResult();
        }
    }
}
