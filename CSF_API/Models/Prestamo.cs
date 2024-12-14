namespace CSF_API.Models
{
    public class Prestamo
    {
        public int Id { get; set; } // ID único del préstamo (clave primaria)

        // Relación con el libro: Un préstamo está asociado a un libro
        public int LibroId { get; set; } // Clave foránea hacia Libro
        public Libro Libro { get; set; } // Propiedad de navegación hacia Libro

        public DateTime FechaPrestamo { get; set; } // Fecha en la que se prestó el libro
        public DateTime? FechaDevolucion { get; set; } // Fecha en la que se devolvió el libro (puede ser nula)
    }
}
