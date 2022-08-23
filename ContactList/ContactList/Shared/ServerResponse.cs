namespace ContactList.Shared
{
    public class ServerResponse<T>
    {
        public bool Success { get; set; } = true;
        public string? Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public ServerResponse()
        {
        }

        public ServerResponse(bool success, string? message)
        {
            Success = success;
            Message = message;
        }

        public ServerResponse(bool success, string? message, T? data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
