using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using URL.Validation.DTO.Messages;

namespace URL.Validation.Business.Services
{
    public static class URLService
    {
        public static ValidationMessage DomainNameAvailable(string url)
        {
            ValidationMessage message = new ValidationMessage() { OperationSuccess = false };
            if(string.IsNullOrWhiteSpace(url))
            {
                message.ErrorType = DTO.Enum.ErrorType.EmptyRequest;
            }
            else if(!CheckValidURL(url))
            {
                message.ErrorType = DTO.Enum.ErrorType.InvalidUrl;
            }
            else if(!IsDomainNameAvailable(url))
            {
                message.ErrorType = DTO.Enum.ErrorType.Exist;
            }

            message.OperationSuccess = true;
            return message;
        }

        private static bool CheckValidURL(string url)
        {
            Uri uriResult;
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        private static bool IsDomainNameAvailable(string domain)
        {
            HttpWebResponse response = null;
            var request = (HttpWebRequest)WebRequest.Create(domain);
            request.Method = "HEAD";
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
            }
            finally
            {
                // Don't forget to close your response.
                if (response != null)
                {
                    response.Close();
                }
            }

            if (response != null && response.StatusCode == HttpStatusCode.OK)
                return true;

            return false;
        }
    }
}
