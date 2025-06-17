using System.Text.Json;
using TareasDeEmpleado;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Obteniendo tareas desde la API...");

        List<Tareas> todasLasTareas = await TareaServer.ObtenerTareasAsync();

        // Ordenar: pendientes primero, luego completadas
    Console.WriteLine("\n--- TAREAS PENDIENTES ---");
    foreach (var tarea in todasLasTareas)
    {
        if (!tarea.completed)
        {
            Console.WriteLine($"[Pendiente] ID: {tarea.id} | Usuario: {tarea.userId} | Título: {tarea.title}");
        }
    }

    Console.WriteLine("\n--- TAREAS COMPLETADAS ---");
    foreach (var tarea in todasLasTareas)
    {
        if (tarea.completed)
        {
            Console.WriteLine($"[Completada] ID: {tarea.id} | Usuario: {tarea.userId} | Título: {tarea.title}");
        }
    }

        // Guardar todas las tareas en un archivo JSON
        string json = JsonSerializer.Serialize(todasLasTareas, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync("tareas.json", json);

        Console.WriteLine("\nTodas las tareas se han guardado en el archivo 'tareas.json'.");
    }
}
