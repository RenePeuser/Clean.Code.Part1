using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Code.Part1.Api.Users.V1
{
    [AllowAnonymous]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/users")]
    public class UsersController : ControllerBase
    {
        // Problems:
        // - Response type is fix and not extendable - without breaking the Api !
        // - Returning a Generic type at interfaces should not be used have to be avoided
        // - Directly implementation in the controller it self
        //   -> When extending logic the controller which is only a wrapper/gateway for http requests will changed (Open-Close)
        // --------------------------- Non clean code specific problems --------------------------------------------------------
        // - Security Auth-Scopes are missing
        // - Produce/Response types missing
        // - Swagger operation id's 
        // - many more predefined api specifications
        [HttpGet]
        public IEnumerable<string> GetAllUsersAsync()
        {
            yield return "Bart Simpsons";
            yield return "Son Goku";
        }
    }
}