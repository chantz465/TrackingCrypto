//using System;
//using System.Net.Http;
//using System.Threading.Tasks;
//using Newtonsoft.Json.Linq;
//using Nervos.Network;




//namespace TrackingCrypto
//{
//    public class CkbApi
//    {
//        private readonly HttpClient _httpClient;
//        private readonly string _rpcUrl;
//        private readonly NervosNetworkApi _nervosNetworkApi;

//        public CkbApi(string rpcUrl)
//        {
//            _httpClient = new HttpClient();
//            _rpcUrl = rpcUrl;
//            _nervosNetworkApi = new NervosNetworkApi(_rpcUrl);
//        }

//        public async Task<decimal> GetCkbBalance(string address)
//        {
//            var request = new JObject
//            {
//                ["id"] = "1",
//                ["jsonrpc"] = "2.0",
//                ["method"] = "get_capacity_by_address",
//                ["params"] = new JArray { address }
//            };

//            var response = await _httpClient.PostAsync(_rpcUrl, new StringContent(request.ToString()));
//            var responseJson = JObject.Parse(await response.Content.ReadAsStringAsync());

//            if (responseJson.ContainsKey("error"))
//            {
//                throw new Exception($"Error fetching CKB balance for address {address}: {responseJson["error"]}");
//            }

//            var capacity = responseJson["result"].ToObject<decimal>();

//            return capacity / 100_000_000m; // Convert from shannons to CKB
//        }
//    }
//}
