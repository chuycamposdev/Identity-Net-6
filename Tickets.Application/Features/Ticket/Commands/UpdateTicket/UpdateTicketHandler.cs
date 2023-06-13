using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.Interfaces.Repositories;
using Tickets.Application.Models;

namespace Tickets.Application.Features.Ticket.Commands.UpdateTicket
{
    public class UpdateTicketHandler : IRequestHandler<UpdateTicketCommand, OperationResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        IRepository<Domain.Entities.Ticket> _ticketRepository;

        public UpdateTicketHandler(IUnitOfWork unitOfWork, IRepository<Domain.Entities.Ticket> ticketRepository)
        {
            _unitOfWork = unitOfWork;
            _ticketRepository = ticketRepository;
        }

        public async Task<OperationResult> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = _ticketRepository.GetByCondition(x => x.TicketId == request.Id).FirstOrDefault();
            if (ticket == null) throw new Exception();

            ticket.Nombre = request.Name;
            _unitOfWork.Commit();
            return new OperationResult();
        }
    }
}
