using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tickets.Application.Features.Ticket.Commands.AddTicket;
using Tickets.Application.Features.Ticket.Commands.GetTicketById;
using Tickets.Application.Features.Ticket.Commands.UpdateTicket;

namespace API.Controllers
{


    public class TicketController : BaseApiController
    {
       

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetTicketByIdQuery{ Id = id};
            return Ok(await Mediator.Send(query));  
        }

        [HttpPost]
        public async Task<IActionResult> InsertTicket(AddTicketCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTicket(UpdateTicketCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
