
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
                UserName = "Yassir rchi",
                email = "yassirrchiexemple@gmail.com",
                password= "123123",
                phone="0633445566"
            });
           
        }

    }
}
