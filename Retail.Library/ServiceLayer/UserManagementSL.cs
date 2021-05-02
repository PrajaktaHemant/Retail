using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Retail.Infrastructure.DataServices;
using Retail.Infrastructure.Hepler;
using Retail.Infrastructure.Models;
using Retail.Infrastructure.RequestModels;
using Retail.Infrastructure.ResponseModels;

namespace Retail.Infrastructure.ServiceLayer
{
    public class UserManagementSL
    {
        public async Task<ReceiveContext<PersonLoginResponse>> ValidateUser(LoginRequest loginRequest)
        {
            return await WebServiceUtils<ReceiveContext<PersonLoginResponse>>.PostData(ServiceEndPoints.Login, loginRequest);
        }

        public async Task<ReceiveContext<PersonLoginResponse>> Register(PersonRegisterRequest person)
        {
            return await WebServiceUtils<ReceiveContext<PersonLoginResponse>>.PostData(ServiceEndPoints.Register, person);
        }


        public async Task<ReceiveContext<string>> ChangePassword(PasswordRequestModel password)
        {
            return await WebServiceUtils<ReceiveContext<string>>.PostData(ServiceEndPoints.ChangePassword, password);
        }



        public async Task<ReceiveContext<PersonLoginResponse>> ForgotPassword(ForgotPasswordRequest email)
        {
            return await WebServiceUtils<ReceiveContext<PersonLoginResponse>>.PostData(ServiceEndPoints.ForgotPasswordOTP, email);
        }

        public async Task<ValidateTokenResponse> UserTokenValidate(UserTokenValidateReq userToken)
        {
            return await WebServiceUtils<ValidateTokenResponse>.PostData(ServiceEndPoints.UserToken, userToken);
        }



        public async Task<ValidateTokenResponse> VerifyEmailMobileTokenForgetPassword(UserTokenValidateReq userToken)
        {
            return await WebServiceUtils<ValidateTokenResponse>.PostData(ServiceEndPoints.VerifyEmailMobileTokenForgetPassword, userToken);
        }

        public async Task<APIResponse> ResendOTP(string UserId)
        {
            return await WebServiceUtils<APIResponse>.PostData(ServiceEndPoints.ResendOTP + UserId, null);
        }



    }
}
