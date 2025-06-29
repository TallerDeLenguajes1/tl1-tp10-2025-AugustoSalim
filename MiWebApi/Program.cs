using MiWebApi;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Obteniendo datos de la API de Cat Facts...\n");

        // Llama al servidor para obtener los hechos sobre gatos
        List<CatFact> catFacts = await CatFactServer.ObtenerCatFactsAsync();

        // Muestra los primeros 5 hechos en consola
        MostrarCatFacts(catFacts);

        // Guarda los datos obtenidos en un archivo JSON local
        await CatFactServer.GuardarCatFactsAsync(catFacts);

        Console.WriteLine("\nLos datos se han guardado en 'catfacts.json'.");
    }

    // Muestra en pantalla los hechos obtenidos
    static void MostrarCatFacts(List<CatFact> catFacts)
    {
        foreach (var fact in catFacts)
        {
            Console.WriteLine($"ID: {fact._id}");
            Console.WriteLine($"Tipo: {fact.type}");
            Console.WriteLine($"Hecho: {fact.text}");

            // Línea separadora para mejor lectura visual
            Console.WriteLine(new string('-', 40));
        }
    }
}
