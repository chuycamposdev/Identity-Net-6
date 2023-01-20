using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.Interfaces.Email;
using Tickets.Application.Models;
using Tickets.Domain.Settings;

namespace Tickets.Application.Facades
{
    public class EmailFacade
    {
        private readonly IEmailService _emailService;
        private readonly AccountSetting _accountSetting;

        public EmailFacade(IEmailService emailService, IOptions<AccountSetting> settings)
        {
            _emailService = emailService;
            _accountSetting = settings.Value;
        }

        public async Task SendRegistrationEmailAsync(string email, string username, string confirmationToken)
        
        {
            string message = SetRegistrationEmailTemplate();
            message = message.Replace("{{UserName}}", username);
            message = message.Replace("{{UrlEndpointConfirmation}}", string.Concat(_accountSetting.Url, _accountSetting.Endpoint,
                                                                    $"?Email={email}&confirmationToken={confirmationToken}"));
            await _emailService.SendHTMLEmailAsync(new EmailModel(email, "Email account confirmation", message));
        }

        private string SetRegistrationEmailTemplate()
        {
            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _accountSetting.RegisterPathTemplate);
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            string aseembly = AppDomain.CurrentDomain.BaseDirectory;
            string eee = AppContext.BaseDirectory;
            string emailBody = File.ReadAllText(fullPath);
            return emailBody;
        }


    }
}
