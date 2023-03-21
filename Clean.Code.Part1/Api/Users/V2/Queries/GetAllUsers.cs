using System.Collections.Immutable;
using AspNetCore.Simple.Sdk.Mediator;

namespace Clean.Code.Part1.Api.Users.V2
{
    internal sealed record GetAllUsers : IQuery<GetAllUsersResponse>;

    internal sealed class GetAllUsersHandler : IQueryHandler<GetAllUsers, GetAllUsersResponse>
    {
        public Task<GetAllUsersResponse> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            var users = GetUsers().ToImmutableList();
            var response = new GetAllUsersResponse(users);

            return Task.FromResult(response);
        }


        // Is this right ??
        // And explanation why it is currently right but not for the future :)  
        private IEnumerable<User> GetUsers()
        {
            yield return new User("Bart", "Simpsons");
            yield return new User("Son", "Goku");
        }
    }

    public record GetAllUsersResponse(IImmutableList<User> Users);
}
