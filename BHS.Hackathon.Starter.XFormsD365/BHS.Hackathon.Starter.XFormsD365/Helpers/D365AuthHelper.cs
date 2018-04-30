using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using BHS.Hackathon.Starter.XFormsD365.Interfaces;

namespace BHS.Hackathon.Starter.XFormsD365.Helpers
{   /// <summary>
    /// D365 Authentication
    /// </summary>
    public static class D365AuthHelper
    {
        /// <summary>
        /// Gets D365 Authorization Header used for Authenticating.
        /// </summary>
        /// <param name="useAuthLogin"></param>
        /// <returns>Auth Header.</returns>
        public static async Task<string> GetAuthorizationHeader()
        {
            string authHeader = null;

            var authResp = await DependencyService.Get<IAuthenticator>().Authenticate(Settings.AzureADAuthority, Settings.D365URL, Settings.AzureADClientId, Settings.AzureADReturnURL);
            if (authResp == null || !string.IsNullOrEmpty(authResp.ErrorMsg))
            {
                throw new Exception("Error connecting to Dynamics 365: " + authResp.ErrorMsg);
            }
            else
            {
                Settings.AzureADUserInfo = authResp.AuthenticationResult.UserInfo;
                authHeader = authResp.AuthenticationResult.CreateAuthorizationHeader();
            }

            return authHeader;
        }
    }
}