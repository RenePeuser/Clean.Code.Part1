using Extensions.Pack;

namespace Clean.Code.Part1.Samples
{
    public static class AddCustomMapperExtension
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingletonIfNotExists<CustomMapper>();
        }
    }

    public class CustomMapper
    {
        private readonly ILogger<CustomMapper> _logger;

        public CustomMapper(ILogger<CustomMapper> logger)
        {
            _logger = logger;
        }

        // Is a extension now a good solution ?
        // - What happens when we need https://www.nuget.org/packages/AutoMapper or another service for a complex mapping ?
        // - What if we want to log mapping infos anywhere, imagine enum mappings, undefined and more ?
        // => With extensions you are not able to consume registered services ! Without any dirty hacks !
        public ObjectB ToObjectB(ObjectA source)
        {
            // just sample, can be azure insights log etc.
            if (source.PropertyA == "undefined")
            {
                _logger.LogInformation("Mapping from ObjectA to ObjectB undefined values detected, fallback value XY will be used");
            }

            return new ObjectB()
            {
                PropertyA = source.PropertyB,
                PropertyB = source.PropertyA
            };
        }
    }
}
