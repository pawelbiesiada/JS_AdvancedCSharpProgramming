using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;

namespace AdvancedCSharp.Samples.Web
{
    class WebRequest
    {
        static void Main()
        {
            var url = @"https://powerbi.microsoft.com/en-us/windows-license-terms/";


            var httpClient = new HttpClient();

            try
            {
                var httpResponse = httpClient.GetAsync(url).Result;

                if(httpResponse.IsSuccessStatusCode)
                {
                    var content = httpResponse.Content;                    
                }


                httpClient.DefaultRequestHeaders.Add("key", "value");
                var httpPost = httpClient.PostAsync(url, new FormUrlEncodedContent(new Dictionary<string, string>()));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
            Console.ReadKey();
        }


        private static void UseWebRequest(string url)
        {
            var request = System.Net.WebRequest.Create(url);

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                Console.WriteLine(response.StatusDescription);
                Console.WriteLine();
                var stream = response.GetResponseStream();
                var reader = new StreamReader(stream);

                string responseStr = reader.ReadToEnd();
                Console.WriteLine(responseStr);
                reader.Close();
                stream.Close();
            }
        }
    }
}
