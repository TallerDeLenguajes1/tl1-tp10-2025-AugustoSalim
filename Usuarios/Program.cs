using System.Text.Json;      // Para serializar a JSON
using DatosPersonales;       // Para usar las clases Persona y UsuariosServer

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Obteniendo usuarios desde la API...");

        // Llamada asíncrona para obtener la lista completa de usuarios desde la API
        List<Persona> usuarios = await UsuariosServer.ObtenerUsuariosAsync();

        Console.WriteLine("\n--- Primeros 5 usuarios ---");

        // Mostrar en consola los primeros 5 usuarios con nombre, email y domicilio completo
        for (int i = 0; i < 5 && i < usuarios.Count; i++)
        {
            var u = usuarios[i]; // Usuario actual

            // Mostrar información clara y legible en consola
            Console.WriteLine($"Nombre: {u.name}");
            Console.WriteLine($"Email: {u.email}");
            Console.WriteLine($"Domicilio: {u.address.street}, {u.address.suite}, {u.address.city}, {u.address.zipcode}");
            Console.WriteLine(('-', 40)); // Crea un string de 40 caracteres, todos con el símbolo - (guion medio).
        }

        // Serializar toda la lista de usuarios a JSON con formato indentado (legible)
        string json = JsonSerializer.Serialize(usuarios, new JsonSerializerOptions { WriteIndented = true });

        // Guardar el JSON resultante en un archivo llamado 'usuarios.json' en el directorio de ejecución
        await File.WriteAllTextAsync("usuarios.json", json);

        Console.WriteLine("\nLos usuarios se han guardado en el archivo 'usuarios.json'.");
    }
}
