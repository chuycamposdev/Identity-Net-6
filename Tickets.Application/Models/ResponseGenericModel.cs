using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Application.Models
{
    public class ResponseGenericModel<T> : ResponseModel
    {
        public T? Data { get; set; }

        public ResponseGenericModel(T? data, string message = null)
        {
            Message = message;
            Data = data;
        }
    }
}
