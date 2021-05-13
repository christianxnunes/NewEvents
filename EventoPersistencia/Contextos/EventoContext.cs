using Microsoft.EntityFrameworkCore;
using EventoDominio;

namespace EventoPersistencia.Contextos
{
    public class EventoContext : DbContext
    {
        public EventoContext(DbContextOptions<EventoContext> options) : base(options) { }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new {PE.EventoId, PE.PalestranteId});

            // Perminte deletar tudo sem nenhuma restrição
            modelBuilder.Entity<Evento>()
                .HasMany(e => e.RedesSociais)
                .WithOne(rs => rs.Evento)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrante>()
                .HasMany(e => e.RedesSociais)
                .WithOne(rs => rs.Palestrante)
                .OnDelete(DeleteBehavior.Cascade);

            // Many to Many
            modelBuilder.Entity<PalestranteEvento>()
                .HasOne(pe => pe.Evento)
                .WithMany(p => p.PalestrantesEventos)
                .HasForeignKey(pe => pe.EventoId);

            modelBuilder.Entity<PalestranteEvento>()
                .HasOne(pe => pe.Palestrante)
                .WithMany(p => p.PalestrantesEventos)
                .HasForeignKey(pe => pe.PalestranteId);
        }
    }
}