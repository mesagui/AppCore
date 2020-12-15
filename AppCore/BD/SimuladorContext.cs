using AppCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCore.BD
{
    public class SimuladorContext : DbContext
    {
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Director> Directors { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Server=MIPC\\SQLEXPRESS; DataBase=examen;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DirectorMap());
            modelBuilder.ApplyConfiguration(new PeliculaMap());
        }
    }
}
