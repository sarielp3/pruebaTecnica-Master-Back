using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PruebaT_MasterGroup.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PruebaT_MasterGroup.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tienda> Tienda { get; set; }
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<ClienteArticulo> ClienteArticulo { get; set; }
        public DbSet<ArticuloTienda> ArticuloTienda { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ClienteArticulo>()
             .HasKey(ca => new { ca.ClienteId, ca.ArticuloId });

            builder.Entity<ArticuloTienda>()
            .HasKey(at => new { at.ArticuloId, at.TiendaId });
        }
    }
}
