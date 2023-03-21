using AspNetCore.Simple.Sdk.Mediator;
using Clean.Code.Part1.Api.Configuration.V1.Settings;

namespace Clean.Code.Part1.Api.Configuration.V1
{
    internal static class AddAddConfigurationExtension
    {
        internal static void AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddNavisionSettings(configuration);
        }
    }
}
