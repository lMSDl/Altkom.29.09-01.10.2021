using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApi.Handlers
{
    public class AgeHandler : AuthorizationHandler<AgeHandler>, IAuthorizationRequirement
    {
        private int _minAge;

        public AgeHandler(int minAge)
        {
            _minAge = minAge;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AgeHandler requirement)
        {
            if (context.User.HasClaim(x => x.Type == ClaimTypes.DateOfBirth))
            {
                var date = DateTime.Parse(context.User.FindFirst(x => x.Type == ClaimTypes.DateOfBirth).Value);
                var age = DateTime.Now.Year - date.Year;
                if (age >= _minAge)
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}
