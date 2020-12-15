using AppCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AppCore.BD
{
    public class PeliculaMap  : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder) {
            
            builder.ToTable("Pelicula");
            builder.HasKey(x=>x.Id);

            builder.HasOne(o => o.Director)
                .WithMany(o=>o.Peliculas)                           
                .HasForeignKey(o=>o.DirectorId);
        }
    }
}
