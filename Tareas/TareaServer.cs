using System.Net.Http;
using System.Text.Json;
using TareasDeEmpleado;

namespace TareasDeEmpleado;

public class TareaServer
{
    private static readonly HttpClient client = new HttpClient();

    public static async Task<List<Tareas>> ObtenerTareasAsync()
    {
        var url = "https://jsonplaceholder.typicode.com/todos/";
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        List<Tareas> tareas = JsonSerializer.Deserialize<List<Tareas>>(responseBody)!;

        return tareas;
    }
}
