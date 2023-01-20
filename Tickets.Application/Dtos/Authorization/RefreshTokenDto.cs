using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Application.Dtos.Authorization
{
    public record RefreshTokenDto(string RefreshToken, string Token, string UserId);
}
