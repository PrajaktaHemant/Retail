using System;
namespace Retail.Infrastructure.Enums
{
    public enum TokenContextEnum
    {
        /// <summary>
        /// Verify email context
        /// </summary>
        EmailVerification = 1,
        /// <summary>
        /// Verify phone context
        /// </summary>
        OneTimePassword,
        /// <summary>
        /// Reset password context
        /// </summary>
        ResetPassword
    }
}
