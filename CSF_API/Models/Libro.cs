namespace CSF_API.Models
{
    public class Libro
    {
        public int Id { get; set; } // ID único del libro (clave primaria)
        public string Titulo { get; set; } // Título del libro
        public string ISBN { get; set; } // Código ISBN del libro
        public int AñoPublicacion { get; set; } // Año de publicación del libro

        // Relación con el autor: Un libro tiene un solo autor
        public int AutorId { get; set; } // Clave foránea hacia Autor
        public Autor Autor { get; set; } // Propiedad de navegación hacia Autor
    }
}
