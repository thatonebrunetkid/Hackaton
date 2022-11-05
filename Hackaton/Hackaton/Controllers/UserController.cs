using Application.UserTypes.Handlers.Queries;
using Domain.User.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hackaton.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator Mediator;

        public UserController(IMediator Mediator)
        {
            this.Mediator = Mediator;
        }


        [Route("{UserId}/Data/All")]
        [HttpGet]
        public async Task<ActionResult<GetUserDataDTO>> GetUserData(int UserId)
        {
            var result = await Mediator.Send(new GetUserDataQuerieRequest { UserId = UserId });
            if (result is null) return NotFound();
            return Ok(result);
        }


    }
}
