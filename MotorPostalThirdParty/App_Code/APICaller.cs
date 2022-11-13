using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;



    public class APICaller
    {
        public async Task<int> PostBulkDoc(DocumentEntryDTO Entry)
        {
            int returnObj = 0;
            log lg = new log();
            try
            {
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(Entry);
                HttpContent requestContent = new StringContent(json);
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue { NoCache = true };
                HttpResponseMessage response = new HttpResponseMessage();
               
                response = await client.PostAsync("http://192.168.101.21:10155/DocumentShareAPI/api/Document/RecordDocument", requestContent);
                Console.WriteLine(response);

                if (response.IsSuccessStatusCode)
                {
                    var ret = response.Content.ReadAsStringAsync();
                    returnObj = Convert.ToInt32(ret.Result.ToString());
                }
            }
            catch (Exception e)
            {
                lg.write_log("PostBulkDoc " + e.Message);
                Console.WriteLine(e);
            }

            return returnObj;

        }
    }
