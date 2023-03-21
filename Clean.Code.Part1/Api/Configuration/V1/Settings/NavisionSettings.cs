using System.Collections.Immutable;
using Extensions.Pack;

namespace Clean.Code.Part1.Api.Configuration.V1.Settings
{
    // ToDo: Sample to separate logic for configuration as well :) 
    //       Data objects are pure data classes and logic are in functions :) 
    public static class AddNavisionSettingsExtension
    {
        public static void AddNavisionSettings(this IServiceCollection services, IConfiguration configuration)
        {
            if (services.IsAlreadyRegistered<NavisionSettings>())
            {
                return;
            }

            // org value is separted with ";"
            var companiesAsString = configuration.GetSection("NavisionSettings:Companies").Value;

            var companiesAsArray = companiesAsString.IsNull() ? Array.Empty<string>() : companiesAsString.Split(";");
            var navisionSettings = new NavisionSettings()
            {
                Companies = companiesAsArray.ToImmutableList()
            };

            services.AddSingletonIfNotExists(navisionSettings);
        }
    }


    // This is what we want
    public record NavisionSettings
    {
        public IImmutableList<string> Companies { get; init; } = ImmutableList<string>.Empty;
    }
}
