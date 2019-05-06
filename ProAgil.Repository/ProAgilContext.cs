using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ProAgil.Domain.Identity;
using ProAgil.Domain;
using Microsoft.AspNetCore.Identity;

namespace ProAgil.Repository.Data
{
    public class ProAgilContext : IdentityDbContext<User, Role, int,
                    IdentityUserClaim<int>, UserRole,
                    IdentityUserLogin<int>,
                    IdentityRoleClaim<int>,
                    IdentityUserToken<int>>
    {
        public ProAgilContext(DbContextOptions<ProAgilContext> options)
                : base(options)  
        {    
            //Database.Log = sql => Debug.Write(sql);
        }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestranteEventos { get; set; }
        public DbSet<RedeSocial> RedeSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserRole>(userRole =>
                {
                    userRole.HasKey(ur => new { ur.UserId, ur.RoleId });
                    userRole.HasOne(ur => ur.Role)
                            .WithMany(r => r.UserRoles)
                            .HasForeignKey(ur => ur.RoleId)
                            .IsRequired();
                            
                    userRole.HasOne(ur => ur.User)
                            .WithMany(r => r.UserRoles)
                            .HasForeignKey(ur => ur.UserId)
                            .IsRequired();
                }
            );

            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(pe => new {pe.PalestranteId, pe.EventoId});
        }
    }
}