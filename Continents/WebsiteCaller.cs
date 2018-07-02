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
                    //wc.DefaultRequestHeaders.Add("content-type", "application/json");
                    var response = await wc.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    json = await response.Content.ReadAsStringAsync();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    /*using (WebResponse response = e.Response)
                    {
                        HttpWebResponse httpResponse = (HttpWebResponse)response;
                        System.Diagnostics.Debug.WriteLine("Error code: {0}", httpResponse.StatusCode);
                        using (Stream data = response.GetResponseStream())
                        using (var reader = new StreamReader(data))
                        {
                            string text = reader.ReadToEnd();
                            System.Diagnostics.Debug.WriteLine(text);
                        }
                    }*/
                }

            }
            return json;
        }
    }
}
