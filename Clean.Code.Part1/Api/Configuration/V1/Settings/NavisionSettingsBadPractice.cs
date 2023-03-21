using Extensions.Pack;
using System.Collections.Immutable;

namespace Clean.Code.Part1.Api.Configuration.V1.Settings
{
    public static class AddNavisionSettingsBadPracticeExtension
    {
        public static void AddNavisionSettingsBadPractice(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingletonOption<NavisionSettingsBadPractice>(configuration);
        }
    }

    // What we do not have in our code :)
    // Data classes which knows how to transform values
    public record NavisionSettingsBadPractice
    {
        private string _companiesAsString = string.Empty;

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
                    _companiesAsString = value;
                    Companies = _companiesAsString.Split(";").ToImmutableList();
                }
            }
        }

        public IImmutableList<string> Companies { get; private set; } = ImmutableList<string>.Empty;
    }
}
