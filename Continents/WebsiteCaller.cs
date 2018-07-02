using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace Continents
{
    public class WebsiteCaller
    {
        public WebsiteCaller()
        {
        }

        public static async Task<string> ExecuteCall(string url)
        {
            string json = null;
            using (var wc = new HttpClient())
            {
                try
                {
                    wc.DefaultRequestHeaders.Add("x-apikey", "aaeec424209317e1391ae874e96ff2cc90c26");
                    var response = await wc.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    json = await response.Content.ReadAsStringAsync();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }

            }
            return json;
        }
    }
}
