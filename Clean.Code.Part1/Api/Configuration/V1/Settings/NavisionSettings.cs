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
            var companiesAsArray = companiesAsString.Split(";");


            var navisionSettings = new NavisionSettings()
            {
                Companies = companiesAsArray.ToImmutableList()
            };

            services.AddSingletonIfNotExists(navisionSettings);
        }
    }


    public record NavisionSettings
    {
        public IImmutableList<string> Companies { get; init; }
    }


    // What we do not have in our code :)
    // Data classes which knows how to transform values
    public record NavisionSettingsBadPractice
    {
        private string _companiesAsString;

        public string CompaniesAsStringAsString
        {
            // Mixing => and {} in 1 scope not nice to read
            get
            {
                return _companiesAsString;
            }

            set
            {
                if (_companiesAsString.NotEqualsTo(value))
                {
                    Companies = _companiesAsString.Split(";").ToImmutableList();
                }
            }
        }

        public IImmutableList<string> Companies { get; private set; }
    }
}
