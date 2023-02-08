
using Annonce.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Annonce.Services.DbContexts
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
                
        }
        public DbSet<Annonces> Annonces { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Annonces>().HasData(new Annonces
            {
                AnnonceId = 1,
                title = "nokia vintage",
                Price = 233,
                Desc= "telephone economique",
                Premuim = false,
                UserId=1,
                Image= new byte[0],
            });
            modelBuilder.Entity<Annonces>().HasData(new Annonces
            {
                AnnonceId = 2,
                title  = "pc gamer neuf",
                Price = 12000,
                Desc = "pc gamer neuf spec nvidia rtx ram 32g stockage 1tb",
                Premuim = false,
                UserId=1,
                Image = new byte[0],
            });
            modelBuilder.Entity<Annonces>().HasData(new Annonces
            {
                AnnonceId = 3,
                title = "trotinnete electrique xiaomi",
                Price = 3500,
                Desc = "trotinette electrique xiaomi 30h charge",
                Premuim = false,
                UserId=1,
                Image = new byte[1],
            }); 
            modelBuilder.Entity<Annonces>().HasData(new Annonces
            {
                AnnonceId = 4,
                title = "Golf8 importe",
                Price = 335000,
                Desc = "Golf8 importe de bern",
                Premuim = true,
                UserId = 1,
                Image = new byte[1],
            });

        }

    }
}
