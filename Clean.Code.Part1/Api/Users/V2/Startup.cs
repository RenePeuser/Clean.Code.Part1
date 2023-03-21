using AspNetCore.Simple.Sdk.Mediator;
using Clean.Code.Part1.Api.Users.V2.Validations;

namespace Clean.Code.Part1.Api.Users.V2
{
    internal static class AddUsersV2Extension
    {
        internal static void AddUsersV2(this IServiceCollection services)
        {
            services.AddMediator();
            services.AddAddUserValidator();
        }
    }
}
