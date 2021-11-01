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
        [JsonProperty("features")]
        public Feature[] Features { get; set; }
    }

    public partial class Feature
    {
        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }
    }

    public partial class Geometry
    {
        [JsonProperty("coordinates")]
        public double[] Coordinates { get; set; }
    }


    // Main class
    public static class NominatimCoordinatesAPI
    {
        public static async Task<RootObject> GetCoordinates(string path)
        {
            HttpClient client = new HttpClient();
            string format = "&format=geojson";
            client.BaseAddress = new Uri("https://nominatim.openstreetmap.org/search?q=");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", "Other");

            RootObject rootOb = null;
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress + path + format);
            if (response.IsSuccessStatusCode)
            {
                /*Stream dataStream = response.Content.ReadAsStream();
                StreamReader reader = new StreamReader(dataStream);
                string test = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();*/
                rootOb = JsonConvert.DeserializeObject<RootObject>(await response.Content.ReadAsStringAsync());
            }
            return rootOb;
        }
    }
}

