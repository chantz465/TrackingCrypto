using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using TrackingCrypto.Controllers;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;


namespace TrackingCrypto
{
    public class APICaller

    {
        public class DataObject
        {
            public string result { get; set; }
        }

        public class DataObject2
        {
            public string amount { get; set; }
        }


        private const string URL = "https://api.etherscan.io/api";
        //private string urlParameters = "?module=account&action=balance&address=0xdff723CCe14fF76ff65675B07C0E53081E85f350&tag=latest&apikey=PEWI1HU4AYZ89M2AHU5W2JDYYQGA36V8DS";

        public String APIwalletEth()
            {
                 string urlParameters = "?module=account&action=balance&address=0xdff723CCe14fF76ff65675B07C0E53081E85f350&tag=latest&apikey=PEWI1HU4AYZ89M2AHU5W2JDYYQGA36V8DS";


            HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URL);

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                // List data response.
                HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    var dataObjects = response.Content.ReadAsAsync<DataObject>().Result; //Make sure to add a reference to System.Net.Http.Formatting.dll
                                                                                                      //foreach (var d in dataObjects)
                                                                                                      //{
                                                                                                      //    Console.WriteLine("{0}", "I am here");
                                                                                                      //}
                        Console.WriteLine("we Did It");
                        return dataObjects.result;
                }
                else
                {
                        Console.WriteLine("we did not....");
                        return "failed";
                }

                //Make any other calls using HttpClient here.

                //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
                //client.Dispose();
            }


        private const string URLSOL = "https://public-api.solscan.io/account/tokens";
        //private string urlParameters = "?module=account&action=balance&address=0xdff723CCe14fF76ff65675B07C0E53081E85f350&tag=latest&apikey=PEWI1HU4AYZ89M2AHU5W2JDYYQGA36V8DS";

        public String APIwalletSOL()
        {
            string urlParameters = "?account=4t4rBu44DGxwTnpCYnUmbuibLPgho4s5CNhGNF24JaBv";



            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URLSOL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects = response.Content.ReadAsAsync<DataObject2>().Result; //Make sure to add a reference to System.Net.Http.Formatting.dll
                                                                                     //foreach (var d in dataObjects)
                                                                                     //{
                                                                                     //    Console.WriteLine("{0}", "I am here");
                                                                                     //}
                Console.WriteLine("we Did It");
                return dataObjects.amount;
            }
            else
            {
                Console.WriteLine("we did not....");
                return "failed";
            }

            //Make any other calls using HttpClient here.

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            //client.Dispose();
        }


    }
}
