using IdentityServer4.Validation;
using System.Collections.Generic;
using System.Security.Claims;

namespace Portal.IdentityServer.Security
{
    public class UserValidator : IResourceOwnerPasswordValidator
    {
        private readonly Dictionary<string, string> Users;

        public UserValidator() 
        {
            Users = new Dictionary<string, string>
            {
                {"username", "password"}
            };
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if (this.Users.Any(x => x.Key == context.UserName && x.Value == context.Password))
            {
                context.Result = new GrantValidationResult(
                    subject: context.UserName,
                    authenticationMethod: "password",
                    claims: new Claim[]
                    {

                    }
                    );
            }
            //throw new NotImplementedException();
        }
    }
}
