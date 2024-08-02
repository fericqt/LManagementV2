using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace LManagement.Utility {
    public class AccountAccessHandler : AuthorizationHandler<RolesAuthorizationRequirement> {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RolesAuthorizationRequirement requirement) {
            if (context.User.IsInRole("Admin")) {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;  
        }
    }
}
