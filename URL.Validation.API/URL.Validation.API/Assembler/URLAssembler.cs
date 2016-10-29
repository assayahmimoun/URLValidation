using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using URL.Validation.API.Models;

namespace URL.Validation.API.Assembler
{
    public static class URLAssembler
    {
        public static ValidationMessage ToValidationMessage(this DTO.Messages.ValidationMessage message)
        {
            if (message == null)
                return null;


            ValidationMessage result = new ValidationMessage()
            {
                OperationSuccess = message.OperationSuccess,
            };

            Enum.ErrorType errorType;
            if (message.ErrorType.HasValue && System.Enum.TryParse(message.ErrorType.Value.ToString(), out errorType))
                result.ErrorType = errorType;

            return result;
        }
    }
}