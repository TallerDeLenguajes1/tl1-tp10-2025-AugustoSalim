using MiWebApi;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Obteniendo hechos de gatos desde la API...\n");

        // Obtenemos 5 hechos (se puede cambiar la cantidad)
        var catFacts = await CatFactServer.ObtenerCatFactsAsync(5);

        // Mostramos cada hecho en consola
        MostrarCatFacts(catFacts);

        // Guardamos la lista completa en un archivo JSON
        await CatFactServer.GuardarCatFactsAsync(catFacts);

        Console.WriteLine("\nLos datos fueron guardados en 'catfacts.json'.");
    }

    // Muestra los datos en consola con una separación clara
    static void MostrarCatFacts(List<CatFact> catFacts)
    {
        foreach (var fact in catFacts)
        {
            Console.WriteLine($"Hecho: {fact.fact}");
            Console.WriteLine($"Longitud: {fact.length} caracteres");
            Console.WriteLine(new string('-', 40)); // Línea separadora para mejor lectura
        }
    }
}
