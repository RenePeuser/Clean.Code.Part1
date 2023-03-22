using AspNetCore.Simple.Sdk.Mediator;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Code.Part1.Api.Configuration.V1
{
    [AllowAnonymous]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/companies")]
    public class ConfigurationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConfigurationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Sample: Over engineered sample

        // Hint: ACL -> AntiCorruptionLayer
        //       Simple but it is. If we would just give our NavisionSettings out and it would change automatically API 
        //       would have new infos. Yeah stupid sample but you know what we want to say :)
        //       ACL - Describes more to avoid returning objects and types from 3rd parties or other not under our control
        //       code parts :)
        [HttpGet]
        public Task<GetAllCompaniesResponse> GetAllCompanies()
        {
            return _mediator.SendAsync(new GetAllCompanies());
            // Alternative :)
            // return _navisionSettings.Companies; 
        }
    }
}
