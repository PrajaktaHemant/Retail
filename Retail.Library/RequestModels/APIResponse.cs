using System;
namespace Retail.Infrastructure.RequestModels
{
    public class APIResponse
    {
        public APIResponse()
        {

        }

        public dynamic Data { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }

        public APIResponse(dynamic data, int status, string message, string errorMessage = "")
        {
            this.Data = data;
            this.Status = status;
            this.Message = message;
            this.ErrorMessage = errorMessage;

        }
    }
}
