using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace URL.Validation.Client.Business
{
    public class WSCaller<T>
    {
        /// <summary>
        /// Get elements by httpGet.
        /// </summary>
        /// <param name="hostApi">The host api</param>
        /// <param name="url">The url</param>
        /// <returns>The ResponseEncapsulation.</returns>
        public T Get(string hostApi, string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(hostApi);
                    client.Timeout = new TimeSpan(0, 0, 0, Constant.WS_TIMEOUT, 0);
                    client.DefaultRequestHeaders.Accept.Clear();

                    HttpResponseMessage response = client.GetAsync(url).Result;
                    T encapsulatedResult = default(T);
                    if (response != null && response.StatusCode== System.Net.HttpStatusCode.OK)
                    {
                        string result = response.Content.ReadAsStringAsync().Result;
                        encapsulatedResult = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(result);
                    }

                    return encapsulatedResult;
                }
            }
            catch (AggregateException ex)
            {
                return default(T);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}
