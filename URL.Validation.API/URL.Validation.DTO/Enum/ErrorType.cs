using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URL.Validation.DTO.Enum
{
    /// <summary>
    /// enum to design error type
    /// </summary>
    public enum ErrorType
    {
        EmptyRequest,
        InvalidUrl,
        Exist,
        InternalServerError
    }
}
