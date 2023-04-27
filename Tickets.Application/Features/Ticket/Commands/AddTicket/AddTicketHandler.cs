
using Tickets.Application.Abstractions.Messaging;
using Tickets.Application.Interfaces.Repositories;
using Tickets.Application.Models;

namespace Tickets.Application.Features.Ticket.Commands.AddTicket
{
    public class AddTicketHandler : ICommandHandler<AddTicketCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Domain.Entities.Ticket> _ticketRepository; 

        public AddTicketHandler(IUnitOfWork unitOfWork, IRepository<Domain.Entities.Ticket> ticketRepository)
        {
            _unitOfWork = unitOfWork;
            _ticketRepository = ticketRepository;   
        }

        public async Task<OperationResult> Handle(AddTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = new Domain.Entities.Ticket { Nombre = request.Nombre };
            _ticketRepository.Insert(ticket);
            _unitOfWork.Commit();
            return OperationResult.Success();
        }

    }
}
