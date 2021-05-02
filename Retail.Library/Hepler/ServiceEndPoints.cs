using System;
namespace Retail.Infrastructure.Hepler
{
    public static class ServiceEndPoints
    {
        public static Uri StagingServerUri => new Uri("http://devsrv01.panasonic.ae:82/api/");
        public static Uri LiveServerUri => new Uri("https://prism.panasonic.ae/smartcareApi/api/");

        public static Uri ServerBaseUri { get { return StagingServerUri; } }

        #region Account
        public static string Login => "Login";
        public static string Register => "Login/Register";
        public static string UserToken => "UserToken/VerifyEmailMobileToken";
        public static string SavePersonProfilePicture => "People/SavePersonProfilePicture/";
        //  /api/
        public static string VerifyEmailMobileTokenForgetPassword => "UserToken/VerifyEmailMobileTokenForgetPassword";

        public static string ChangePassword => "Login/ChangePassword";
        public static string ForgotPassword => "Login/ForgotPassword";
        public static string UpdatePersonDetails => "People/UpdatePersonDetails/";
        public static string ResendOTP => "Login/ResendOTP?UserID=";
        public static string ForgotPasswordOTP => "Login/ForgotPasswordOTP";
        public static string GetWarrantyCard => "Products/GetWarrantyCard/";
        ///api/Login/ForgotPasswordOTP
        ///GetWarrantyCard
        #endregion




    }



}