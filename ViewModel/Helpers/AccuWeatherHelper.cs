using LPAWEATHERAPP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LPAWEATHERAPP.ViewModel.Helpers
{
    public class AccuWeatherHelper
    {
        //the class has to be made public because it obviously will be used from different namespaces.
        public const string BASE_URL = "http://dataservice.accuweather.com/";
        public const string AUTOCOMPLETE_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string CURRENT_CONDITIONS_ENDPOINT = "currentconditions/v1/{0}?apikey={1}";
        public const string API_KEY = "cgR1NRAcWK52h1rNVC2ARxGfgt7ADZ1X";

        /// <summary>
        /// This method below returns the list of cities corresponding to the user search
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static async Task<List<City>> GetCities(string query)
        {
            List<City> cities = new List<City>();

            string url = BASE_URL + string.Format(AUTOCOMPLETE_ENDPOINT, API_KEY, query);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                //the deserialize aspect is how we interpret the json file already received throught the API
                cities = JsonConvert.DeserializeObject<List<City>>(json);
            }

            return cities;
        }
        /// <summary>
        /// The method below returns the current conditions of each city in the returned list of the above cities.
        /// </summary>
        public static async Task<CurrentCondition> GetCurrentConditions(string citykey)
        { 
            CurrentCondition currentcondition = new CurrentCondition();
            //seems like the get request line of code in a REST API are actually synonymous
            string url = BASE_URL + string.Format(CURRENT_CONDITIONS_ENDPOINT, citykey, API_KEY);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync(); 

                currentcondition = (JsonConvert.DeserializeObject<List<CurrentCondition>>(json)).FirstOrDefault();
            }

            return currentcondition;
        }
    }
}
