using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace BHS.Hackathon.Starter.XFormsD365.Models
{
    /// <summary>
    /// Authentication Result Response.
    /// </summary>
    public class AuthenticationResultResp
    {
        public AuthenticationResult AuthenticationResult { get; set; }
        public string ErrorMsg { get; set; }
    }
}