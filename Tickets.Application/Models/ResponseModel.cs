using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Application.Models
{
    public class ResponseModel<T>
    {
        public bool Succeeded { get; set; } = true;
        public string? Message { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public T? Data { get; set; }

        public ResponseModel()
        {
        }

        public ResponseModel(T? data, string? message = "")
        {
            Message = message;
            Data = data;
        }

        public ResponseModel(string? message)
        {
            Succeeded = false;
            Message = message;
        }
    }
}
