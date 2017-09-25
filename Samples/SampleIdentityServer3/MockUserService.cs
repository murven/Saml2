using IdentityServer3.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityServer3.Core.Models;
using System.Threading.Tasks;
using System.Security.Claims;

namespace SampleIdentityServer3
{
    public class MockUserService : IUserService
    {
        public async Task AuthenticateExternalAsync(ExternalAuthenticationContext context)
        {
        }

        public async Task AuthenticateLocalAsync(LocalAuthenticationContext context)
        {
            var user = Users.Get()
                .Where(u => u.Username == context.UserName && u.Password == context.Password)
                .FirstOrDefault();
            if (user != null)
            {
                context.AuthenticateResult =
                    new AuthenticateResult(
                        subject: user.Subject
                        , name: user.Username);
            }
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
        }

        public async Task PostAuthenticateAsync(PostAuthenticationContext context)
        {
        }

        public async Task PreAuthenticateAsync(PreAuthenticationContext context)
        {
        }

        public async Task SignOutAsync(SignOutContext context)
        {
        }
    }
}