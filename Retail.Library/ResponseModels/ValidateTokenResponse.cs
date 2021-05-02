using System;
namespace Retail.Infrastructure.ResponseModels
{
    public class ValidateTokenResponse
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }

        public bool TokenFound { get; set; }
        public bool TokenExpired { get; set; }
    }
}
