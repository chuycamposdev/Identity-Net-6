using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.Abstractions.Messaging;
using Tickets.Application.Dtos.Ticket;
using Tickets.Application.Exceptions;
using Tickets.Application.Interfaces.Repositories;
using Tickets.Application.Models;

namespace Tickets.Application.Features.Ticket.Commands.GetTicketById
{
    public class GetTicketByIdQueryHandler : IQueryHandler<GetTicketByIdQuery, TicketDto>
    {
        private readonly IRepository<Domain.Entities.Ticket> _ticketRepository;
        private readonly IMapper _mapper;


        public GetTicketByIdQueryHandler(IRepository<Domain.Entities.Ticket> ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<TicketDto>> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
        {
            var ticket = _ticketRepository.GetByCondition(x => x.Id == request.Id).FirstOrDefault();
            if (ticket == null)
                throw new NotFoundException();
            var ticketDto = _mapper.Map<TicketDto>(ticket);
            return OperationResult<TicketDto>.Success(ticketDto);
        }
    }
}
