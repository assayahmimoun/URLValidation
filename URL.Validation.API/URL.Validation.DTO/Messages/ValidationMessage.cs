using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URL.Validation.DTO.Enum;

namespace URL.Validation.DTO.Messages
{
    public class ValidationMessage
    {
        public ErrorType? ErrorType { get; set; }

        public bool OperationSuccess { get; set; }
    }
}
