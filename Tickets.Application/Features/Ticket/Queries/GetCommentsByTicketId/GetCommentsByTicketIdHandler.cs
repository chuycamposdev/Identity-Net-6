using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.Abstractions.Messaging;
using Tickets.Application.Dtos.Ticket;
using Tickets.Application.Interfaces.Repositories;
using Tickets.Application.Models;

namespace Tickets.Application.Features.Ticket.Queries.GetCommentsByTicketId
{
    public class GetCommentsByTicketIdHandler : IQueryHandler<GetCommentsByTicketIdQuery, List<TicketCommentDto>>
    {
        private readonly IRepository<Domain.Entities.TicketComment> _repository;
        private readonly IMapper _mapper;

        public GetCommentsByTicketIdHandler(IRepository<Domain.Entities.TicketComment> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public Task<OperationResult<List<TicketCommentDto>>> Handle(GetCommentsByTicketIdQuery request, CancellationToken cancellationToken)
        {
            var commentsDto = _mapper.ProjectTo<TicketCommentDto>(_repository.GetByCondition(x => x.TicketId == request.TicketId)).ToList();
            return Task.FromResult(OperationResult<List<TicketCommentDto>>.Success(commentsDto));
        }
    }
}
