using AspNetCore.Simple.Sdk.Startups;
using Clean.Code.Part1.Api.Configuration.V1;
using Clean.Code.Part1.Api.Users;

namespace Clean.Code.Part1
{
    public sealed class Startup : SimpleStartup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment) :
            base(configuration, webHostEnvironment, new PathString("/api/clean-code"))
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddUsers();
            services.AddConfiguration(Configuration);
        }
    }
}