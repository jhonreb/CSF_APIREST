using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace CSF_API.Recursos
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoresController : ControllerBase
    {
        // Obtener todos los autores
        [HttpGet]
        public IActionResult ObtenerAutores()
        {
            string query = "SELECT * FROM Autores";
            DataTable tabla = DBDatos.EjecutarConsulta(query);

            var autores = new List<dynamic>();
            foreach (DataRow fila in tabla.Rows)
            {
                autores.Add(new
                {
                    Id = Convert.ToInt32(fila["Id"]),
                    Nombres = fila["Nombres"].ToString(),
                    Apellidos = fila["Apellidos"].ToString(),
                    FechaNacimiento = Convert.ToDateTime(fila["FechaNacimiento"]).ToString("yyyy-MM-dd")
                });
            }

            return Ok(new { Success = true, Data = autores });
        }

        // Crear un nuevo autor
        [HttpPost]
        public IActionResult CrearAutor([FromBody] dynamic autor)
        {
            string query = "INSERT INTO Autores (Nombres, Apellidos, FechaNacimiento) VALUES (@Nombres, @Apellidos, @FechaNacimiento)";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Nombres", autor.Nombres.ToString()),
                new SqlParameter("@Apellidos", autor.Apellidos.ToString()),
                new SqlParameter("@FechaNacimiento", DateTime.Parse(autor.FechaNacimiento.ToString()))
            };

            int filas = DBDatos.EjecutarComando(query, parametros);
            return Ok(new { Success = filas > 0 });
        }

        // Actualizar un autor
        [HttpPut("{id}")]
        public IActionResult ActualizarAutor(int id, [FromBody] dynamic autor)
        {
            string query = "UPDATE Autores SET Nombres = @Nombres, Apellidos = @Apellidos, FechaNacimiento = @FechaNacimiento WHERE Id = @Id";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@Nombres", autor.Nombres.ToString()),
                new SqlParameter("@Apellidos", autor.Apellidos.ToString()),
                new SqlParameter("@FechaNacimiento", DateTime.Parse(autor.FechaNacimiento.ToString()))
            };

            int filas = DBDatos.EjecutarComando(query, parametros);
            return Ok(new { Success = filas > 0 });
        }

        // Eliminar un autor
        [HttpDelete("{id}")]
        public IActionResult EliminarAutor(int id)
        {
            string query = "DELETE FROM Autores WHERE Id = @Id";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Id", id)
            };

            int filas = DBDatos.EjecutarComando(query, parametros);
            return Ok(new { Success = filas > 0 });
        }
    }
}
