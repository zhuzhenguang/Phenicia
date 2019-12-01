using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Phoenicia.Test.Base
{
    public static class HttpClientExtension
    {
        public static async Task<HttpResponseMessage> PostAsync(this HttpClient httpClient, string uri, object postBody)
        {
            return await httpClient.PostAsync(uri, new StringContent(
                JsonConvert.SerializeObject(postBody),
                Encoding.UTF8,
                "application/json"));
        }
    }
}