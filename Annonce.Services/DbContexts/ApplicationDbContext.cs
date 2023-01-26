
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
                AnnonceName = "trotinette",
                Price = 15,
                Desc= "nice",
                Premuim = false,
                UserId=1
            });
            modelBuilder.Entity<Annonces>().HasData(new Annonces
            {
                AnnonceId = 2,
                AnnonceName = "sendala",
                Price = 30,
                Desc = "nice",
                Premuim = false,
                UserId=2
            });
            modelBuilder.Entity<Annonces>().HasData(new Annonces
            {
                AnnonceId = 3,
                AnnonceName = "Audi A3",
                Price = 250000,
                Desc = "nice",
                Premuim = true,
                UserId=3
            });
        }

    }
}
