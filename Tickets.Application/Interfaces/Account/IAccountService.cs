using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.Dtos.Authorization;
using Tickets.Application.Models;

namespace Tickets.Application.Interfaces.Account
{
    public interface IAccountService
    {
        Task<string> RegisterAccountAsync(RegisterModel request);
        Task<UserDto> LoginAsync(LoginModel requestModel);
        Task<RefreshTokenDto> RefreshToken(RefreshTokenDto refreshTokenDto);
        Task<string> GenerateConfirmationTokenAsync(string userID);
        Task<bool> ConfirmateAccount(string confirmationToken, string email);
    }
}
