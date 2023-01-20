using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Application.Dtos.Authorization
{
    public record RegisterModel(
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        string Password
    );
}
