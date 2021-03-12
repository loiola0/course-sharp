using System;

namespace api_rest.Communication
{
    public abstract class BaseResponse
    {
        public bool Success {get;protected set;}

        public string Message {get; protected set;}

        public BaseResponse(bool success,string message){
            Success = success;
            Message = message;
        }


    }
}