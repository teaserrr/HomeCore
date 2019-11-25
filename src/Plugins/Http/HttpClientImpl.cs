using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HC.Plugins.Http
{
  internal class HttpClientImpl
  {
    static private readonly HttpClient _httpClient;

    static HttpClientImpl()
    {     
      _httpClient = new HttpClient();
    }

    public async Task<string> Get(Uri requestUri)
    {
      var response = await _httpClient.GetAsync(requestUri);
      response.EnsureSuccessStatusCode();

      var content = await response.Content.ReadAsStringAsync();

      return content;
    }
  }
}
