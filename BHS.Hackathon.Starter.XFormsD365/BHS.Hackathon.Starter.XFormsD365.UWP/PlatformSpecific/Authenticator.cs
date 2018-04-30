using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using BHS.Hackathon.Starter.XFormsD365.Helpers;
using BHS.Hackathon.Starter.XFormsD365.Interfaces;
using BHS.Hackathon.Starter.XFormsD365.Models;
using BHS.Hackathon.Starter.XFormsD365.UWP.PlatformSpecific;

[assembly: Dependency(typeof(Authenticator))]

namespace BHS.Hackathon.Starter.XFormsD365.UWP.PlatformSpecific
{
    /// <summary>
    /// UWP Authenticator.
    /// </summary>
    internal class Authenticator : IAuthenticator
    {
        /// <summary>
        /// Authenticate UWP.
        /// </summary>
        /// <param name="authority"></param>
        /// <param name="resource"></param>
        /// <param name="clientId"></param>
        /// <param name="returnUri"></param>
        /// <returns></returns>
        public async Task<AuthenticationResultResp> Authenticate(string authority, string resource, string clientId, string returnUri)
        {
            var authResultResp = new AuthenticationResultResp();
            try
            {
                var authContext = new AuthenticationContext(authority);
                var platformParams = new PlatformParameters(PromptBehavior.Auto, false);

                authResultResp.AuthenticationResult = await authContext.AcquireTokenAsync(resource, clientId, new Uri(returnUri), platformParams);
            }
            catch (AdalException ex)
            {
                authResultResp.ErrorMsg = ex.ErrorCode;
            }
            catch (Exception ex)
            {
                authResultResp.ErrorMsg = ex.Message;
            }

            return authResultResp;
        }

        /// <summary>
        /// Clear UWP Cookies.
        /// </summary>
        public void ClearCookies()
        {
            if (!string.IsNullOrWhiteSpace(Settings.AzureADAuthority))
            {
                var myFilter = new Windows.Web.Http.Filters.HttpBaseProtocolFilter();
                var cookieManager = myFilter.CookieManager;
                var myCookieJar = cookieManager.GetCookies(new Uri(Settings.AzureADAuthority));
                foreach (var cookie in myCookieJar)
                {
                    cookieManager.DeleteCookie(cookie);
                }
            }
        }
    }
}