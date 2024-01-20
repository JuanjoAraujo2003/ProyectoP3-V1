using Proyecto_P3;
using Proyecto_P3.Utilidades;
using Microsoft.EntityFrameworkCore;
using Proyecto_P3.Models;
using Proyecto_P3.Models.Proyecto_P3.Models;

namespace Proyecto_P3.DataAccess
{
    public class ReservaDbContext : DbContext
    {
        public DbSet<Reserva> Reservas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conexionDB = $"Filename={ConexionDB.DevolverRuta("reservas.db")}";
            optionsBuilder.UseSqlite(conexionDB);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(col => col.IdReserva);
                entity.Property(col => col.IdReserva).IsRequired().ValueGeneratedOnAdd();
            });
        }
    }
}
