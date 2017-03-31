using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AzureAppDemo
{
    public class GraphHelper
    {
        public async Task<dynamic> QueryGraph(string endpoint, string accessToken, HttpMethod method = null, StringContent content = null)
        {
            if (method == null)
                method = HttpMethod.Get;

            dynamic json = null;

            using (HttpClient client = new HttpClient())
            {
                Uri requestUri = new Uri(new Uri(Settings.GraphQueryUrl), endpoint);
                using (HttpRequestMessage request = new HttpRequestMessage(method, requestUri))
                {
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    if (content != null)
                    {
                        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        request.Content = content;
                    }

                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            json = JObject.Parse(await response.Content.ReadAsStringAsync());
                        }
                    }
                }
            }

            return json;
        }
        
    }
}
