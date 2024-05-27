using AppProxy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppProxy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SRLMBS007_S02Controller : ControllerBase
    {
        //[HttpGet]
        //public ActionResult<string> Index()
        //{
        //    return "value1";
        //}
        readonly IHttpClientFactory _clientFactory;
        public SRLMBS007_S02Controller(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
        }

        [HttpPost]
        [Route("test")]
        public async Task<ContentResult> Test([FromBody] S007_S02 request)
        {
            HttpClient client = _clientFactory.CreateClient("Dev_Client");

            // send request
            var builder = new UriBuilder(client.BaseAddress);
            var req = new HttpRequestMessage
            {
                RequestUri = new Uri("https://api-dev.hotaimotor.com.tw/service/SRLAPP/api/SRLAPP/SRLMBS007_S02"),//builder.Uri,
                Method = HttpMethod.Post,
                Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")
            };
            var response = await client.SendAsync(req);
            response.EnsureSuccessStatusCode();

            //Console.WriteLine(response.Content);
            var json = await response.Content.ReadAsStringAsync();
            return new ContentResult()
            {
                Content = json,
                ContentType = "application/json"
            };
        }

        [HttpPost]
        [Route("prod")]
        public async Task<ContentResult> Prod([FromBody] S007_S02 request)
        {
            HttpClient client = _clientFactory.CreateClient("Prod_Client");

            // send request
            var builder = new UriBuilder(client.BaseAddress);
            var req = new HttpRequestMessage
            {
                RequestUri = new Uri("https://api.hotaimotor.com.tw/service/SRLAPP/api/SRLAPP/SRLMBS007_S02"),//builder.Uri,
                Method = HttpMethod.Post,
                Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")
            };
            var response = await client.SendAsync(req);
            response.EnsureSuccessStatusCode();

            //Console.WriteLine(response.Content);
            var json = await response.Content.ReadAsStringAsync();
            return new ContentResult()
            {
                Content = json,
                ContentType = "application/json"
            };
        }


    }
}
