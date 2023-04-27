using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.Models;

namespace Tickets.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<OperationResult<TResponse>>
    {
    }
}
