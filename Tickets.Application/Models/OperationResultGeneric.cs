using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Application.Models
{
    public class OperationResult<T> : OperationResult
    {
        public T? Data { get; set; }

        public static OperationResult<T> Success(T value)
        {
            return new OperationResult<T> { Data = value };
        }

        public static OperationResult<T> Error(string error)
        {
            return new OperationResult<T> { Succeeded = false, Message = error };
        }
    }
}
