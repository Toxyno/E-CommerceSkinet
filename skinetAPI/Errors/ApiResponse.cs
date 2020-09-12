using System;

namespace skinetAPI.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string statusMessage=null)
        {
            StatusCode = statusCode;
            StatusMessage = statusMessage??GetDefaultMessageforStatusCode(statusCode);

        }

        // private string GetDefaultMessageforStatusCode(int statusCode) => statusCode switch
        // {
        //     400 => "A bad request you have made",
        //     401 => "Authorized, you are not",
        //     404 => "Resource found, it is not",
        //     500 => "Errors are the path to the dark side, Errors lead to ander, Anger leads to  hate. Hate leads to career change",
        //     _ => null

        // };

        private string GetDefaultMessageforStatusCode(int statusCode)
        {
            return statusCode switch 
            {
                400 => "A bad request you have made",
                401 => "Authorized, you are not",
                404 => "Resource found, it is not",
                500 => "Errors are the path to the dark side, Errors lead to ander, Anger leads to  hate. Hate leads to career change",
                _ => null
              
            };
        }

        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
    }
}