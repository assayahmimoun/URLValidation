using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using URL.Validation.API.Enum;

namespace URL.Validation.API.Models
{
    public class ValidationMessage
    {
        public ErrorType? ErrorType { get; set; }

        public bool OperationSuccess { get; set; }
    }
}