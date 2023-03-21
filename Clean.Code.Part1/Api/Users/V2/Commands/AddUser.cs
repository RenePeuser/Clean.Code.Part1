using AspNetCore.Simple.Sdk.Mediator;

namespace Clean.Code.Part1.Api.Users.V2.Commands
{
    public sealed record AddUserResponse(User User);

    internal sealed record AddUser(User User) : ICommand<AddUserResponse>;

    internal sealed class AddUserHandler : ICommandHandler<AddUser, AddUserResponse>
    {
        // Sample: This is a domain command AddUser
        // - It will orchestrate the business flow
        // - It will know all implementation details about databases, sql or anything else
        // - It just orchestrates the needed flow !
        public Task<AddUserResponse> Handle(AddUser request, CancellationToken cancellationToken)
        {
            // 1. Check if user already exists

            // 2. Do any other things what is to do

            // 3. Save or add new user into the system, database, file, or any other domain specific store

            // 4. Return the created user
            return Task.FromResult(new AddUserResponse(request.User));
        }
    }

}
