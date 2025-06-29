using System.Net.Http;           // Para HttpClient y manejo de HTTP
using System.Text.Json;          // Para serialización y deserialización JSON
using DatosPersonales;           // Espacio de nombres donde está la clase Persona

namespace DatosPersonales
{
    public class UsuariosServer
    {
        // Instancia estática de HttpClient para reutilizar la conexión HTTP
        private static readonly HttpClient client = new HttpClient();

        // Método asíncrono que obtiene la lista de usuarios desde la API
        // No recibe parámetros y retorna una lista de objetos Persona (List<Persona>)
        public static async Task<List<Persona>> ObtenerUsuariosAsync()
        {
            var url = "https://jsonplaceholder.typicode.com/users"; // URL de la API REST
            HttpResponseMessage response = await client.GetAsync(url); // Enviar petición GET

            response.EnsureSuccessStatusCode(); // Lanza excepción si el código HTTP no es exitoso (ej: 200 OK)

            string responseBody = await response.Content.ReadAsStringAsync(); // Leer contenido JSON como string

            // Deserializar el string JSON a una lista de objetos Persona
            List<Persona> usuarios = JsonSerializer.Deserialize<List<Persona>>(responseBody)!;

            return usuarios; // Devolver la lista de usuarios
        }

        /*
         * Cambios si usás otra API:
         * - Cambiar la URL en la variable 'url' para apuntar a la nueva API.
         * - Cambiar el tipo genérico de Deserialize<List<Persona>> al tipo que corresponda para la nueva estructura JSON.
         * - Adaptar la clase Persona y sus propiedades según el nuevo JSON para que coincidan los nombres.
         */
    }
}
