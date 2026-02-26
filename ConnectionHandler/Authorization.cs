using Utilities;
using DTO.Response;
using DTO.MFAccountsRentAPI.Response;

namespace ConnectionHandler
{
    /// <summary>
    /// Created on : 29-Mar-2022
    /// Created By : Nithin - 100367
    /// Description: Authorization
    /// </summary>
    public class Authorization
    {
        public string Status;
        public string Message;

        public Authorization(string v)
        {
            
            PublicConfigManager appConfigManager = new PublicConfigManager();
            var response = new ApiManager().InvokeGetHttpClientWithoutRequest<Response<TokenValidatorResponse>>(appConfigManager.getaccountsRentApiUrl + "api/accounts/TokenValidator", v);
            if (response.Data == null)
            {
                this.Status = "0";
                this.Message = "Invalid Authentication";
            }
            else
            {
                this.Status = response.Data.status;
                this.Message = response.Data.message;
            }

        }

    }
}

