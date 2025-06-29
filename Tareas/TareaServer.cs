using System.Net.Http;              // Necesario para trabajar con peticiones HTTP
using System.Text.Json;            // Para convertir JSON en objetos de C#
using TareasDeEmpleado;           // Usa la clase Tareas definida en el proyecto

namespace TareasDeEmpleado;

// Clase que se encarga de comunicarse con un servidor que ofrece tareas vía API REST
public class TareaServer
{
    // Cliente HTTP reutilizable para hacer peticiones (mejor práctica)
    private static readonly HttpClient client = new HttpClient();

    // Función asíncrona que obtiene la lista de tareas desde la API
    public static async Task<List<Tareas>> ObtenerTareasAsync()
    {
        // URL de la API a la que se hace la petición
        // ⚠️ Si usas otra API, este sería el primer cambio a realizar:
        var url = "https://jsonplaceholder.typicode.com/todos/";

        // Hace una petición GET a la API (forma asíncrona)
        HttpResponseMessage response = await client.GetAsync(url);

        // Lanza una excepción si el código de respuesta es error (404, 500, etc.)
        response.EnsureSuccessStatusCode();

        // Lee el cuerpo de la respuesta como string
        // ⚠️ Si la API devuelve XML o un formato diferente a JSON, aquí cambiaría el procesamiento
        string responseBody = await response.Content.ReadAsStringAsync();

        // Deserializa el JSON en una lista de objetos de la clase Tareas
        // ⚠️ Si la estructura de los datos JSON cambia (por ejemplo, si los campos se llaman distinto),
        // también deberías cambiar la clase Tareas para que coincida con la nueva estructura.
        List<Tareas> tareas = JsonSerializer.Deserialize<List<Tareas>>(responseBody)!;

        // Devuelve la lista de tareas al programa principal
        return tareas;
    }
}
