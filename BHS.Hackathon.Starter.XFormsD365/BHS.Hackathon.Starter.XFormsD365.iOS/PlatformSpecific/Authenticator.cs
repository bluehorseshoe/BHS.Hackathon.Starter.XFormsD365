using Foundation;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;
using BHS.Hackathon.Starter.XFormsD365.Interfaces;
using BHS.Hackathon.Starter.XFormsD365.iOS.PlatformSpecific;
using BHS.Hackathon.Starter.XFormsD365.Models;

[assembly: Dependency(typeof(Authenticator))]

namespace BHS.Hackathon.Starter.XFormsD365.iOS.PlatformSpecific
{
    public class Authenticator : IAuthenticator
    {
        public async Task<AuthenticationResultResp> Authenticate(string authority, string resource, string clientId, string returnUri)
        {
            var authResultResp = new AuthenticationResultResp();
            try
            {
                var authContext = new AuthenticationContext(authority);
                var platformParams = new PlatformParameters(UIApplication.SharedApplication.KeyWindow.RootViewController);
                authResultResp.AuthenticationResult = await authContext.AcquireTokenAsync(resource, clientId, new Uri(returnUri), platformParams);
            }
            catch (AdalException ex)
            {
                authResultResp.ErrorMsg = ex.ErrorCode;
            }

            return authResultResp;
        }

        public void ClearCookies()
        {
            var CookieStorage = NSHttpCookieStorage.SharedStorage;

            foreach (var cookie in CookieStorage.Cookies)
            {
                CookieStorage.DeleteCookie(cookie);
            }
        }
    }
}