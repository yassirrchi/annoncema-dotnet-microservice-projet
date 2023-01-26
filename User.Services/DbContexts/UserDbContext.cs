
using User.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace User.Services.DbContexts
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions options):base(options)
        {
                
        }
        public DbSet<Users> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Users>().HasData(new Users
            {
                UserId = 1,
                UserName = "hassan",
                email = "hassan@gmail.com",
                password= "1234",
                phone="0633445566"
            });
            modelBuilder.Entity<Users>().HasData(new Users
            {
                UserId = 2,
                UserName = "hamid",
                email = "hamid@gmail.com",
                password = "1234",
                phone = "0633445566"
            });
            modelBuilder.Entity<Users>().HasData(new Users
            {
                UserId = 3,
                UserName = "SAID",
                email = "SAID@gmail.com",
                password = "1234",
                phone = "0633445566"
            });
        }

    }
}
