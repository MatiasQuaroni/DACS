using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Server.Application.ExternalAPIs
{
    //Classes to storage the data
    public partial class RootObject
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("licence")]
        public string Licence { get; set; }

        [JsonProperty("features")]
        public Feature[] Features { get; set; }
    }

    public partial class Feature
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("properties")]
        public Properties Properties { get; set; }

        [JsonProperty("bbox")]
        public double[] Bbox { get; set; }

        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }
    }

    public partial class Geometry
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public double[] Coordinates { get; set; }
    }

    public partial class Properties
    {
        [JsonProperty("place_id")]
        public long PlaceId { get; set; }

        [JsonProperty("osm_type")]
        public string OsmType { get; set; }

        [JsonProperty("osm_id")]
        public long OsmId { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("place_rank")]
        public long PlaceRank { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("importance")]
        public double Importance { get; set; }
    }

    // Main class
    public static class NominatimCoordinatesAPI
    {
        static HttpClient client = new HttpClient();
        public static async Task<RootObject> GetCoordinates(string path)
        {
            string format = "&format=geojson";
            client.BaseAddress = new Uri("https://nominatim.openstreetmap.org/search?q=");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", "Other");

            RootObject rootOb = null;
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress + path + format);
            if (response.IsSuccessStatusCode)
            {
                Stream dataStream = response.Content.ReadAsStream();
                StreamReader reader = new StreamReader(dataStream);
                string test = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                rootOb = JsonConvert.DeserializeObject<RootObject>(test);
            }
            return rootOb;
        }
    }
}

