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


        public static ServiceResult SuccessResult(string message = "Success") =>
            new() { Success = true, Message = message };

        public static ServiceResult FailureResult(string message = "An error occurred.") =>
            new() { Success = false, Message = message };
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T? Data { get; set; }

        public static ServiceResult<T> SuccessResult(T data, string message = "Success") =>
            new()
            {
                Success = true,
                Message = message,
                Data = data
            };

        public static ServiceResult<T> FailureResult(string message = "An error occurred.") =>
            new()
            {
                Success = false,
                Message = message,
                Data = default
            };
    }

   

}

/* public class ServiceResult
   {
       public bool Success { get; set; }
       public string? Message { get; set; }
   }*/
