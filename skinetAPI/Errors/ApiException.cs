namespace skinetAPI.Errors
{
    public class ApiException : ApiResponse
    {
        public ApiException(int statusCode, string statusMessage = null,string details = null) : base(statusCode, statusMessage)
        {
            Details = details;
        }

        public string Details { get; set; }
    }
}