using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.Dtos.Email;
using Tickets.Application.Models;

namespace Tickets.Application.Interfaces.Email
{
    public interface IEmailService
    {
        Task SendPlainTextEmailAsync(EmailModel request);
        Task SendHTMLEmailAsync(EmailModel request);
    }
}
