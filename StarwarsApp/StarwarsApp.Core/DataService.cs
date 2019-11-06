using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StarwarsApp.Core
{
    public class DataService
    {
        public static async Task<Starships> GetStarWarsStarships(string queryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(queryString);

            Starships data = null;
            if (response != null)
            {
                data = JsonConvert.DeserializeObject<Starships>(response);
            }


            return data;
        }

        public static async Task<Planets> GetStarWarsPlanets(string queryString)
            {
                HttpClient client = new HttpClient();
                var response = await client.GetStringAsync(queryString);

                Planets data = null;
                if (response != null)
                {
                    data = JsonConvert.DeserializeObject<Planets>(response);
                }


                return data;
            }
          

            public static async Task<People> GetStarWarsPeople(string queryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(queryString);

            People data = null;
            if (response != null)
            {
                data = JsonConvert.DeserializeObject<People>(response);
            }
            
               
            return data;
        
      
        }
    }
   
}
