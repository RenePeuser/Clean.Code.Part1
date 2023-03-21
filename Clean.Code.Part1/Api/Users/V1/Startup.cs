using AspNetCore.Simple.Sdk.Mediator;

namespace Clean.Code.Part1.Api.Users.V1
{
    internal static class AddUsersV1Extension
    {
        internal static void AddUsersV1(this IServiceCollection services)
        {
            services.AddMediator();
        }
    }
}
