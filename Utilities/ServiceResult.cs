using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }


        public static ServiceResult SuccessResult(string message = "Success", int statusCode = 200) =>
            new() { Success = true, Message = message , StatusCode = statusCode };

        public static ServiceResult FailureResult(string message = "An error occurred.", int statusCode = 400) =>
            new() { Success = false, Message = message ,StatusCode = statusCode };
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T? Data { get; set; }

        public static ServiceResult<T> SuccessResult(T data, string message = "Success") =>
            new()
            {
                Success = true,
                Message = message,
                StatusCode = 200,
                Data = data
            };

        public static ServiceResult<T> FailureResult(string message = "An error occurred.") =>
            new()
            {
                Success = false,
                Message = message,
                StatusCode = 400,
                Data = default
            };
    }

   

}

