using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using URL.Validation.API.Assembler;
using URL.Validation.API.Enum;
using URL.Validation.API.Models;
using URL.Validation.Business.Services;

namespace URL.Validation.API.Controllers
{
    public class URLController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="urlName"></param>
        /// <returns></returns>
        [HttpGet]
        public ValidationMessage CheckValidationURL(string url)
        {
            ValidationMessage message = new ValidationMessage() { OperationSuccess = false, ErrorType = ErrorType.EmptyRequest };
            if (string.IsNullOrWhiteSpace(url))
                return message;

            return URLService.UrlAvailable(url).ToValidationMessage();
        }
    }
}
