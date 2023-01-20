using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Domain.Settings
{
    public class AccountSetting
    {
        public string Url { get; set; }
        public string Endpoint { get; set; }
        public string Subject { get; set; }
        public string RegisterPathTemplate { get; set; }
    }
}
