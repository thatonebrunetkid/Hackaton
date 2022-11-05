using Application.DonateTypes.Handlers;
using Application.TransactionTypes.Queries;
using Domain.Common.TransactionExecute.DTO;
using Domain.Donate.TransactionExecute.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Hackaton.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : Controller
    {
        private IMediator Mediator;

        public TransactionController(IMediator Mediator)
        {
            this.Mediator = Mediator;
        }

        [Route("Execute")]
        [HttpPost]
        public async Task<ActionResult<HttpStatusCode>> TransactionExecute([FromBody] TransactionExecuteDTO request)
        {
            try
            { 
                await Mediator.Send(new DonateHandlerRequest { TransactionExecuteDTO = request });
                return Ok();
            }catch(Exception)
            {
              return HttpStatusCode.InternalServerError;
            }
        }


        [Route("Last/Donate/{AccountId}")]
        [HttpGet]
        public async Task<ActionResult<GetLastDonateDTO>> GetLastDonate(string AccountId)
        {
            var result = await Mediator.Send(new GetLastDonateQuerieRequest { AccountId = AccountId });
            return Ok(result);
        }
    }
}
