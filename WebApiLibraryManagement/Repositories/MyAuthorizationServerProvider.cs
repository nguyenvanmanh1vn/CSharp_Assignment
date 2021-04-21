using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApiLibraryManagement.Repositories
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        protected readonly UsersRepository _repo;
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var user = _repo.ValidateUser(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant", "Provided username and password is incorrect");
                return;
            }
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Role, user.Role.UserRoles));
            identity.AddClaim(new Claim("Email", user.Email));

            context.Validated(identity);
        }
    }
}