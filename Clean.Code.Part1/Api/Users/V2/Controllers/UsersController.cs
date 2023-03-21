using AspNetCore.Simple.Sdk.Mediator;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Code.Part1.Api.Users.V2
{
    [AllowAnonymous]
    [ApiController]
    [ApiVersion("2.0")]
    [Route("v{version:apiVersion}/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Hint: We ignore any open api specific mandatory infos here we are focused to the code itself :)
        // Solutions:
        // - We have a semantic type response
        //   -> No generic interface
        //   -> Extendable without breaking the interface
        //   -> When extending logic, data it will not effect the controllers implementations !
        [HttpGet]
        public Task<GetAllUsersResponse> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            return _mediator.SendAsync(new GetAllUsers(), cancellationToken);
        }
    }
}