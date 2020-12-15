using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Anio { get; set; }
        public string Imagen { get; set; }
        public string CodigoPelicula { get; set; }
        public int DirectorId { get; set; }

        public Director Director { get; set; }
    }
}
