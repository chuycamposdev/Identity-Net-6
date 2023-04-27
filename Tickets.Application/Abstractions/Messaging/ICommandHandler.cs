using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.Models;

namespace Tickets.Application.Abstractions.Messaging
{
    public  interface ICommandHandler<TCommand> : IRequestHandler<TCommand, OperationResult>
        where TCommand : ICommand
    {
    }

    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand,OperationResult<TResponse>>
        where TCommand : ICommand<TResponse>
    {
    }
}
