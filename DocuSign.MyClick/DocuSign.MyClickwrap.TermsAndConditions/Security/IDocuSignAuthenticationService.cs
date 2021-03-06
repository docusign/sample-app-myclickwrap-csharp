using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace DocuSign.MyClickwrap.TermsAndConditions.Security
{
    public interface IDocuSignAuthenticationService
    {
        (ClaimsPrincipal, AuthenticationProperties) AuthenticateFromJwt();
        string GetConsentUrl(string redirectUrl);
    }
}