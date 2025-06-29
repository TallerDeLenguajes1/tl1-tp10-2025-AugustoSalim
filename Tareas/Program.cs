using System.Text.Json;             // Importa funcionalidades para trabajar con JSON
using TareasDeEmpleado;            // Usa las clases definidas en el namespace TareasDeEmpleado

class Program
{
    // Función principal asíncrona del programa
    static async Task Main()
    {
        // Mensaje informativo al usuario
        Console.WriteLine("Obteniendo tareas desde la API...");

        // Llamamos a la función ObtenerTareasAsync del archivo TareaServer.cs
        // Esta función retorna una lista de objetos Tareas que representa las tareas obtenidas desde la API
        List<Tareas> todasLasTareas = await TareaServer.ObtenerTareasAsync();

        // Mostramos primero las tareas que aún no están completadas (pendientes)
        Console.WriteLine("\n--- TAREAS PENDIENTES ---");
        foreach (var tarea in todasLasTareas)
        {
            if (!tarea.completed) // Si la tarea no está completada
            {
                // Se muestra por consola con el formato [Pendiente]
                Console.WriteLine($"[Pendiente] ID: {tarea.id} | Usuario: {tarea.userId} | Título: {tarea.title}");
            }
        }

        // Luego se muestran las tareas ya completadas
        Console.WriteLine("\n--- TAREAS COMPLETADAS ---");
        foreach (var tarea in todasLasTareas)
        {
            if (tarea.completed) // Si la tarea está completada
            {
                // Se muestra por consola con el formato [Completada]
                Console.WriteLine($"[Completada] ID: {tarea.id} | Usuario: {tarea.userId} | Título: {tarea.title}");
            }
        }

        // Serializamos todas las tareas (pendientes y completadas) a un string JSON con formato legible (indentado)
        string json = JsonSerializer.Serialize(
            todasLasTareas, 
            new JsonSerializerOptions { WriteIndented = true }
        );

        // Guardamos ese string JSON en un archivo llamado "tareas.json"
        // Si el archivo ya existe, se sobrescribe
        await File.WriteAllTextAsync("tareas.json", json);

        // Confirmación al usuario
        Console.WriteLine("\nTodas las tareas se han guardado en el archivo 'tareas.json'.");
    }
}
