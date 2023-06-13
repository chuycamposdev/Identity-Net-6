using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.Dtos.Ticket;
using Tickets.Domain.Entities;

namespace Tickets.Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Ticket, TicketDto>();

            CreateMap<TicketComment, TicketCommentDto>()
                .ForMember(dest => dest.TicketName, opt => opt.MapFrom(x => x.Ticket.Nombre))
                .ForMember(dest => dest.TicketCommentId, opt => opt.MapFrom(x => x.TicketCommentId))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(x => x.Comment));
        }
    }
}
