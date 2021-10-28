using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace openstreetmapAPI
{
    public class Destination
    {
        public List<object> location { get; set; }
        public double snapped_distance { get; set; }
    }

    public class Source
    {
        public List<object> location { get; set; }
        public double snapped_distance { get; set; }
    }

    public class Root
    {
        public List<List<double>> distances { get; set; }
        public List<Destination> destinations { get; set; }
        public List<Source> sources { get; set; }
    }

    class Program
    {
        /*public static void WriteData(RootObject data)
        {
            Console.WriteLine($"type: {rootOb.Type}");
            Console.WriteLine($"licence: {rootOb.Licence}");
            Console.WriteLine($"Place ID: {rootOb.Features[0].Properties.PlaceId}");
            Console.WriteLine($"latitude: {rootOb.Features[0].Geometry.Coordinates[0]}");
            Console.WriteLine($"longitude: {rootOb.Features[0].Geometry.Coordinates[1]}");
        }*/



        static async Task Main()
        {
            var baseAddress = new Uri("https://api.openrouteservice.org");

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json, application/geo+json, application/gpx+xml, img/png; charset=utf-8");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", "5b3ce3597851110001cf6248af5a5299675f47c195e720d4bf06bfee");
                using (var content = new StringContent(
                    "{\"locations\":[[9.70093,48.477473],[9.207916,49.153868],[37.573242,55.801281],[115.663757,38.106467]],\"metrics\":[\"distance\"],\"resolve_locations\":\"false\", \"units\":\"km\"}", 
                    encoding:System.Text.Encoding.UTF8,"application/json"))
                {
                    using (var response = await httpClient.PostAsync("/v2/matrix/driving-car", content))
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        Root data = JsonConvert.DeserializeObject<Root>(responseData);
                        Console.WriteLine(data.distances[1][0]);
                    }
                }
            }
        }
    }
}
