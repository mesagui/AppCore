using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public class Director
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<Pelicula> Peliculas { get; set; }
    }
}
