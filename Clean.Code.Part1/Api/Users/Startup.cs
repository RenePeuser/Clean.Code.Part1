using Clean.Code.Part1.Api.Users.V1;
using Clean.Code.Part1.Api.Users.V2;

namespace Clean.Code.Part1.Api.Users
{
    internal static class AddUsersExtension
    {
        internal static void AddUsers(this IServiceCollection services)
        {
            services.AddUsersV1();
            services.AddUsersV2();
        }
    }
}
