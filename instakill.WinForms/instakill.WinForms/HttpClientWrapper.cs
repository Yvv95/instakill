using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using instakill.Model;

namespace instakill.WinForms
{
    public class HttpClientWrapper
    {
        private readonly string _connectionString;
        private readonly HttpClient _client;

        public HttpClientWrapper(string connectionString)
        {
            _connectionString = connectionString;
            _client = new HttpClient
            {
                BaseAddress = new Uri(connectionString)
            };
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Users GetUserById(Guid id)
        {
            var result = _client.GetAsync(string.Format("{0}/api/users/{1}", _connectionString, id)).Result;
            return result.Content.ReadAsAsync<Users>().Result;
        }
    }
}