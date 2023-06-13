using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Wiki_Hitler
{
    static  class WikiRandom
    {

        public static async Task<string> GetRandomTitleAsync()
        {
             HttpClient client = new HttpClient();

            string response = await client.GetStringAsync("https://en.wikipedia.org/api/rest_v1/page/random/title");



                ItemWikiRandom ParsedResponse = JsonConvert.DeserializeObject<ItemWikiRandom>(response);

               
                //Console.WriteLine(ParsedResponse.Items[0].Title);

                string WikiTitle = ParsedResponse.Items[0].Title;

            return WikiTitle;
            
        }

    }
}
