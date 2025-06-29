using System.Net.Http;
using System.Text.Json;

namespace MiWebApi
{
    public class CatFactServer
    {
        // Se recomienda usar una sola instancia estática de HttpClient para toda la app
        private static readonly HttpClient client = new HttpClient();

        // Método asíncrono para obtener los hechos de gatos desde la API
        public static async Task<List<CatFact>> ObtenerCatFactsAsync()
        {
            var url = "https://cat-fact.herokuapp.com/facts/random?amount=5";

            // Realiza la solicitud GET a la URL
            HttpResponseMessage response = await client.GetAsync(url);

            // Verifica que la respuesta haya sido exitosa (código 200)
            response.EnsureSuccessStatusCode();

            // Lee el contenido de la respuesta como texto
            string responseBody = await response.Content.ReadAsStringAsync();

            // Convierte el texto JSON a una lista de objetos CatFact
            List<CatFact> catFacts = JsonSerializer.Deserialize<List<CatFact>>(responseBody)!;

            return catFacts;
        }

        // Método para guardar los hechos obtenidos en un archivo JSON local
        public static async Task GuardarCatFactsAsync(List<CatFact> catFacts)
        {
            // Serializa la lista como JSON con formato identado
            string json = JsonSerializer.Serialize(catFacts, new JsonSerializerOptions { WriteIndented = true });

            // Guarda el contenido en un archivo llamado catfacts.json
            await File.WriteAllTextAsync("catfacts.json", json);
        }
    }
}
