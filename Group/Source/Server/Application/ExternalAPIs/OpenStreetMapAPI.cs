using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace Server.Application.ExternalAPIs
{    public class Root
    {
        [JsonProperty("distances")]
        public List<List<double>> distances { get; set; }
    }


    public static class OpenStreetMapAPI
    {
        public static async Task<Root> GetMatrix(List<double[]> coordinates)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.openrouteservice.org");
            var esto = JsonConvert.SerializeObject(coordinates);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.TryAddWithoutValidation
                ("accept", "application/json, application/geo+json, application/gpx+xml, img/png; charset=utf-8");
            client.DefaultRequestHeaders.TryAddWithoutValidation
                ("Content-Type", "application/json; charset=utf-8");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", "5b3ce3597851110001cf6248af5a5299675f47c195e720d4bf06bfee");
            StringContent content = new StringContent("{\"locations\":"+ JsonConvert.SerializeObject(coordinates) +",\"metrics\":[\"distance\"],\"resolve_locations\":\"false\", \"units\":\"km\"}"
                , encoding: System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/v2/matrix/driving-car", content);
            Root data = JsonConvert.DeserializeObject<Root>(await response.Content.ReadAsStringAsync());
            return data;

        }
    }
}
