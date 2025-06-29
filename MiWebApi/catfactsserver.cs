using System.Net.Http;
using System.Text.Json;

namespace MiWebApi
{
    public class CatFactServer
    {
        // Se crea una única instancia de HttpClient para toda la aplicación
        private static readonly HttpClient client = new HttpClient();

        // Método para obtener una lista de hechos de gatos desde la API
        public static async Task<List<CatFact>> ObtenerCatFactsAsync(int cantidad = 5)
        {
            var url = $"https://catfact.ninja/facts?limit={cantidad}"; // Endpoint con límite de hechos

            HttpResponseMessage response = await client.GetAsync(url); // Se hace la solicitud GET
            response.EnsureSuccessStatusCode(); // Lanza excepción si la respuesta no fue exitosa

            string responseBody = await response.Content.ReadAsStringAsync(); // Se obtiene el cuerpo de la respuesta como string

            // Usamos JsonDocument para acceder al arreglo 'data' dentro del JSON
            using JsonDocument doc = JsonDocument.Parse(responseBody);
            var root = doc.RootElement.GetProperty("data");

            // Deserializamos solo la parte del JSON que contiene los hechos
            var lista = JsonSerializer.Deserialize<List<CatFact>>(root.GetRawText())!;

            return lista;
        }

        // Método para guardar los hechos en un archivo JSON en formato legible
        public static async Task GuardarCatFactsAsync(List<CatFact> catFacts)
        {
            string json = JsonSerializer.Serialize(catFacts, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync("catfacts.json", json); // Guarda en el archivo 'catfacts.json'
        }
    }
}
