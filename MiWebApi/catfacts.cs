namespace MiWebApi
{
    // Clase que representa un hecho sobre gatos obtenido de la API
    public class CatFact
    {
        // ID del hecho
        public string _id { get; set; }

        // Texto con el hecho del gato
        public string text { get; set; }

        // Tipo de dato (en este caso, siempre "cat")
        public string type { get; set; }
    }
}
