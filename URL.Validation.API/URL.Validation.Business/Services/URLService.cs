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
        public static ValidationMessage UrlAvailable(string url)
        {
            ValidationMessage message = new ValidationMessage() { OperationSuccess = false };
            if (string.IsNullOrWhiteSpace(url))
            {
                message.ErrorType = DTO.Enum.ErrorType.EmptyRequest;
            }
            else if (!CheckValidURL(url))
            {
                message.ErrorType = DTO.Enum.ErrorType.InvalidUrl;
            }
            else
            {
                bool? isUrlAvailable = IsUrlAvailable(url);
                if (!isUrlAvailable.HasValue)
                    message.ErrorType = DTO.Enum.ErrorType.InternalServerError;
                else if (isUrlAvailable.Value)
                    message.ErrorType = DTO.Enum.ErrorType.Exist;
                else
                    message.OperationSuccess = true;
            }

            return message;
        }

        private static bool CheckValidURL(string url)
        {
            return Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute);
        }

        private static bool? IsUrlAvailable(string url)
        {
            HttpWebResponse response = null;
            Uri uri = new Uri(url, UriKind.RelativeOrAbsolute);
            if (!uri.IsAbsoluteUri)
                url = string.Format("http://{0}", url);

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "HEAD";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36";
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException)
            {
                return false;
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
