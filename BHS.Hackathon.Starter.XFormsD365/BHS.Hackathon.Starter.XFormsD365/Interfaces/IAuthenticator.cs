using System.Threading.Tasks;
using BHS.Hackathon.Starter.XFormsD365.Models;

namespace BHS.Hackathon.Starter.XFormsD365.Interfaces
{
    /// <summary>
    /// Authentication Interface
    /// </summary>
    public interface IAuthenticator
    {
        Task<AuthenticationResultResp> Authenticate(string authority, string resource, string clientId, string returnUri);

        void ClearCookies();
    }
}