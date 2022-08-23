namespace ContactList.Shared
{
    public class BoolMessage
    {
        public bool Success { get; set; }
        public string? Message { get; set; } = string.Empty;

        public BoolMessage(bool success, string? message = null)
        {
            Success = success;
            Message = message;
        }
    }
}
