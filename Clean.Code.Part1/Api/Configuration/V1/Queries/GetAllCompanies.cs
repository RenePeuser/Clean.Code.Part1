using System.Collections.Immutable;
using AspNetCore.Simple.Sdk.Mediator;
using Clean.Code.Part1.Api.Configuration.V1.Settings;

namespace Clean.Code.Part1.Api.Configuration.V1
{
    public record GetAllCompaniesResponse(IImmutableList<string> Companies);

    internal record GetAllCompanies : IQuery<GetAllCompaniesResponse>;

    internal class GetAllCompaniesHandler : IQueryHandler<GetAllCompanies, GetAllCompaniesResponse>
    {
        private readonly NavisionSettings _navisionSettings;

        public GetAllCompaniesHandler(NavisionSettings navisionSettings)
        {
            _navisionSettings = navisionSettings;
        }

        public Task<GetAllCompaniesResponse> Handle(GetAllCompanies request, CancellationToken cancellationToken)
        {
            var result = new GetAllCompaniesResponse(_navisionSettings.Companies);

            return Task.FromResult(result);
        }
    }
}
