using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace URL.Validation.Client.Common.Helper
{
    public static class UtilityHelper
    {
        public static bool VerifyCaptcha(string recaptchaResponse)
        {
            if (string.IsNullOrWhiteSpace(recaptchaResponse))
                return false;

            string responseFromServer = "";
            WebRequest request = WebRequest.Create($"https://www.google.com/recaptcha/api/siteverify?secret={ConfigurationManagerHelper.ReCaptchaSecretKey}&response=" + recaptchaResponse);
            request.Method = "GET";
            using (WebResponse response = request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    responseFromServer = reader.ReadToEnd();
                }
            }

            bool isSuccess = false;
            if (responseFromServer != "")
            {
                Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseFromServer);
                if (values != null && values.ContainsKey("success") && values["success"] == "True")
                {
                    isSuccess = true;
                }
            }

            return isSuccess;
        }
    }
}
