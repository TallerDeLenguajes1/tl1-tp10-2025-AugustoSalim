using System.Net.Http;
using System.Text.Json;
using DatosPersonales;

namespace DatosPersonales;

public class UsuariosServer
{
    private static readonly HttpClient client = new HttpClient();

    public static async Task<List<Usuario>> ObtenerUsuarioAsync()
    {
        var url = "https://jsonplaceholder.typicode.com/users";
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        List<Usuario> usuario = JsonSerializer.Deserialize<List<Usuario>>(responseBody)!;

        return usuario;
    }
}
