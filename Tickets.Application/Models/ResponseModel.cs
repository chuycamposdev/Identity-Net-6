using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Application.Models
{
    public class ResponseModel
    {
        public bool Succeeded { get; set; } = true;
        public string? Message { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    

        public ResponseModel()
        {
        }

        //It should by invoked just for middleware exception
        public ResponseModel(string message)
        {
            Succeeded = false;
            Message = message;
        }
    }
}
