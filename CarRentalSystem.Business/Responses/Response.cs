using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Responses
{
    public class Response<T>:IDataResponse<T>
    {
        public T Data { get; private set; }
        public bool IsSuccesful { get; private set; }
        public string Message { get; set; }

        public List<string> Errors { get; set; }

        public static Response<T> Success(T data, string message)
        {
            return new Response<T> { Data = data, IsSuccesful = true };
        }
        public static Response<T> Success(T data)
        {
            return new Response<T> { Data = data, IsSuccesful = true };
        }
        


        public static Response<T> Fail(string message, T data, List<string> errors)
        {
            return new Response<T>
            {
                Message = message,
                IsSuccesful = false,
                Data = data,
                Errors = errors
            };
        }


        public static Response<T> Fail(T data, List<string> errors)
        {
            return new Response<T>
            {
                Data = data,
                Errors = errors,
                IsSuccesful = false

            };
        }
        

    }


    public class Response:IResponse
    {
        public bool IsSuccesful { get; private set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }

        public static Response Success() 
        {
            return new Response { IsSuccesful = true };
        
        }
        public static Response Success(string message)
        {
            return new Response { IsSuccesful = true, Message = message };

        }
        public static Response Fail(List<string> errors)
        {
            return new Response { IsSuccesful = false, Errors = errors };

        }
        public static Response Fail(string message, List<string> errors)
        {
            return new Response { IsSuccesful = false, Message = message, Errors = errors };

        }
        public static Response Fail(string message)
        {
            return new Response { IsSuccesful = false, Message = message };

        }

    }
}
