using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Reflection;


class Program
{
    static async Task Main()
    {
        using (HttpClient thermometer = new HttpClient())
        {
            // "Where The ISS At" API coordinates/[lat,lon] endpoint
            string url = "https://api.wheretheiss.at/v1/coordinates/38.256186,-85.744653";
            
            try
            {
                // Console.WriteLine("Requesting locale data…");

                HttpResponseMessage response = await thermometer.GetAsync(url);
                response.EnsureSuccessStatusCode();
                
                string responseBody = await response.Content.ReadAsStringAsync();

                /* Console.WriteLine("\n---- Where The ISS At? JSON Response ----");
                Console.WriteLine(responseBody); */

                var pretty = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                // Parse the JSON string into c# object
                LocaleFile somePlace = JsonSerializer.Deserialize<LocaleFile>(responseBody, pretty);

                Type type = typeof(LocaleFile);
                PropertyInfo[] properties = type.GetProperties();
                Console.WriteLine($"\nMystery Site detail ---");

                foreach (PropertyInfo place in properties)
                {
                    Console.WriteLine($"The {place.Name} is {place.GetValue(somePlace)}");
                }

                Console.WriteLine("\nHave you discovered the Mystery Site?");
            }

            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}.");
            }
        }
    }
    /* 
     * Taken from the "Where the ISS at?" REST API Documentation (http://wheretheiss.at/w/developer), 
     * the JSON response is expected to have the following structure:
     */

    // Root Wrapper Class
    public class LocaleFile
    {
        [JsonPropertyName("latitude")]
        public required string Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public required string Longitude { get; set; }

        [JsonPropertyName("timezone_id")]
        public required string Timezone_id { get; set; }

        [JsonPropertyName("offset")]
        public int Offset { get; set; }

        [JsonPropertyName("country_code")]
        public required string Country_code { get; set; }

        [JsonPropertyName("map_url")]
        public required string Map_url { get; set; }
    }
}