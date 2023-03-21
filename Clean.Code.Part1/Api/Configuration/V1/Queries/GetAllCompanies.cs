using System.Collections.Immutable;
using AspNetCore.Simple.Sdk.Mediator;
using Clean.Code.Part1.Api.Configuration.V1.Settings;

namespace Clean.Code.Part1.Api.Configuration.V1
{
    public sealed record GetAllCompaniesResponse(IImmutableList<string> Companies);

    internal sealed record GetAllCompanies : IQuery<GetAllCompaniesResponse>;

    internal sealed class GetAllCompaniesHandler : IQueryHandler<GetAllCompanies, GetAllCompaniesResponse>
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
