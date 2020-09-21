using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDataService.Data.Interfaces;
using WebApiDataService.Data.Models;
using WebApiGuideService.Data.Models;
using WebApiGuideService.ViewModels;

namespace WebApiDataService
{
    /*класс реализации IDataRequest*/
    /*
     * принцип такой же как и в сервсисе данных
     */
    public class DataRequest : IDataRequest
    {
        public async Task<List<ConstructionObjects>> getConstructions()
        {
            var client = new RestClient($"https://localhost:44386/api/guides/constructions");
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<List<ConstructionObjects>>(response.Content);
                return content;
            }
            return null;
        }

       
        public async Task<List<DataVersions>> getVersions()
        {
            var client = new RestClient($"https://localhost:44386/api/guides/versions");
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<List<DataVersions>>(response.Content);
                return content;
            }
            return null;
        }

        public async Task<List<DataIntersection>> getIntersections(string key, int value)
        {
            var client = new RestClient($"https://localhost:44339/api/data/{key}={value}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<List<DataIntersection>>(response.Content);
                return content;
            }
            return null;
        }

        public async Task<GuideMetaData> getGuideMetaData(int id)
        {
            var client = new RestClient($"https://localhost:44386/api/guides/metadata={id}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<GuideMetaData>(response.Content);
                return content;
            }
            return null;
        }
    }
}
