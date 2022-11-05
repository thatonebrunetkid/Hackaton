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

        [Route("Last/Amount/{AccountId}")]
        [HttpGet]
        public async Task<ActionResult<GetLastTransactionAmountDTO>> GetLastDonateAmount(string AccountId)
        {
            var result = await Mediator.Send(new GetLastTransactionAmountQuerieRequest { AccountNumber = AccountId });
            return Ok(result);
        }

        [Route("Last/Title/{AccountId}")]
        [HttpGet]
        public async Task<ActionResult<GetLastTransactionTitleDTO>> GetLastDonateTitle(string AccountId)
        {
            var result = await Mediator.Send(new GetLastTransactionTitleQuerieRequest { AccountNumber = AccountId });
            return Ok(result);
        }
    }
}
