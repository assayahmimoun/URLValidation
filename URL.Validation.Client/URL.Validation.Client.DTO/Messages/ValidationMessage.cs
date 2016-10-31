using System;
using URL.Validation.Client.DTO.Enum;

namespace URL.Validation.Client.DTO.Messages
{
    public class ValidationMessage
    {
        public ErrorType? ErrorType { get; set; }

        public bool OperationSuccess { get; set; }
    }
}
