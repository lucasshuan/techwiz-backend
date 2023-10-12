namespace Techwiz.Errors
{
    public class BaseError
    {
        public string Error { get; set; }
        public string? Message { get; set; }

        public BaseError(string error, string message)
        {
            Error = error;
            Message = message;
        }
    }
}