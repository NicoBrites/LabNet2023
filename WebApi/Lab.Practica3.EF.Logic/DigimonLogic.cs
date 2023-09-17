using Lab.Practica3.EF.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lab.Practica3.EF.Logic
{
    public class DigimonLogic
    {
        public async Task<List<Digimon>> GetAll()
        {
            string apiUrl = "https://digimon-api.vercel.app/api/digimon";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        List<Digimon> data = JsonConvert.DeserializeObject<List<Digimon>>(responseBody);
                    
                        return data;
 
                    }
                    else
                    {
                        throw new Exception("Error ! " + response.StatusCode);
                    }
                }
                catch (HttpRequestException ex)
                {
                    throw new Exception("Error en la solicitud GET mediante Http al url de la Api publica");
                }
            }
        }
    }
}
