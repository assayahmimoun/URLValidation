using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URL.Validation.Client.Common.Helper;
using URL.Validation.Client.DTO.Messages;

namespace URL.Validation.Client.Business.Services
{
    public static class URLService
    {
        public static ValidationMessage CheckDomainIsAvailable(string url)
        {
            WSCaller<ValidationMessage> caller = new WSCaller<ValidationMessage>();
            string urlAPI = $"{Constant.APIUrlActionCheckDomain}?url={url}";
            return caller.Get(ConfigurationManagerHelper.URLValidationAPIHost, urlAPI);
        }
    }
}
