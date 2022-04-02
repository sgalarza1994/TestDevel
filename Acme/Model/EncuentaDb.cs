using Microsoft.EntityFrameworkCore;

namespace Acme.Model
{
    public class EncuentaDb : DbContext
    {

        public DbSet<Encuesta> Encuestas { get; set; }
        public DbSet<EncuestaDetalle> EncuestaDetalles { get; set; }

        public DbSet<EncuestaRepuesta> EncuestaRepuestas { get; set; }
        public DbSet<EncuestaRespuestaDetalle> EncuestaRespuestaDetalles { get; set; }

        public EncuentaDb(DbContextOptions<EncuentaDb> options)
            :base(options)
        {

        }
    }
}
