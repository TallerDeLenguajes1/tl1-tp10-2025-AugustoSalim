namespace DatosPersonales
{
    // Clase para representar la ubicación geográfica dentro de la dirección
    public class Geo
    {
        public string lat { get; set; }   // Latitud en formato string
        public string lng { get; set; }   // Longitud en formato string
    }

    // Clase para representar la dirección completa del usuario
    public class Address
    {
        public string street { get; set; }  // Calle
        public string suite { get; set; }   // Departamento o suite
        public string city { get; set; }    // Ciudad
        public string zipcode { get; set; } // Código postal
        public Geo geo { get; set; }        // Objeto Geo con latitud y longitud
    }

    // Clase para representar la empresa donde trabaja el usuario
    public class Company
    {
        public string name { get; set; }        // Nombre de la empresa
        public string catchPhrase { get; set; } // Eslogan o frase de la empresa
        public string bs { get; set; }          // Descripción corta (business slogan)
    }

    // Clase principal que representa al usuario (persona)
    public class Persona
    {
        public int id { get; set; }          // ID del usuario
        public string name { get; set; }     // Nombre completo
        public string username { get; set; } // Nombre de usuario (login)
        public string email { get; set; }    // Correo electrónico
        public Address address { get; set; } // Dirección (objeto Address)
        public string phone { get; set; }    // Teléfono
        public string website { get; set; }  // Sitio web
        public Company company { get; set; } // Empresa (objeto Company)
    }
}
