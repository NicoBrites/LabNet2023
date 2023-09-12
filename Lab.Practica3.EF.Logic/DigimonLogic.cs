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
            // URL de la API pública que deseas consumir
            string apiUrl = "https://digimon-api.vercel.app/api/digimon";

            // Crea una instancia de HttpClient
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Realiza una solicitud GET a la API
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    // Verifica si la solicitud fue exitosa (código de estado 200)
                    if (response.IsSuccessStatusCode)
                    {
                        // Lee el contenido de la respuesta como una cadena JSON
                        string responseBody = await response.Content.ReadAsStringAsync();

                        // Deserializa la respuesta JSON a un objeto C# (clase que defines)
                        // En este ejemplo, asumimos que la respuesta es una lista de objetos
                        List<Digimon> data = JsonConvert.DeserializeObject<List<Digimon>>(responseBody);
                    
                        return data;
 
                    }
                    else
                    {
                        // Maneja errores de solicitud (código de estado no exitoso)
                        throw new Exception("Error ! " + response.StatusCode);
                    }
                }
                catch (HttpRequestException ex)
                {
                    // Maneja errores de solicitud HTTP
                    throw new Exception("Error en la solicitud GET mediante Http al url de la Api publica");
                }
            }
        }
    }
}
