using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Wiki_Hitler
{
    static class HtmlGeter
    {

        public static async Task<string> HtmlStringGetAsync(string WikiTitle) 
        {
            HttpClient client = new HttpClient();

            string urlHttpString = "https://en.wikipedia.org/api/rest_v1/page/html/" + WikiTitle;

             string responsHttp = await client.GetStringAsync(urlHttpString);
            //Console.WriteLine(responsHttp);
            return responsHttp;
        }
    }
}
