using Microsoft.EntityFrameworkCore;
using WebApiHomework.DataAccessLayer.Models;

namespace WebApiHomework.DataAccessLayer
{
    public class BookDbContext : DbContext
    {
        public virtual DbSet<BookEntity> BookEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:assignmentserver.database.windows.net,1433;Initial Catalog=assignment-database;Persist Security Info=False;User ID=adminuser;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Insert dummy data - delete after testing
            modelBuilder.Entity<BookEntity>().HasData(
                new BookEntity()
                {
                    BookId = 1,
                    Name = "Ghoosebumps",
                    Author = "R.L. Stein"
                },
                new BookEntity()
                {
                    BookId = 2,
                    Name = "Game of thrones",
                    Author = "G.R. Martin"
                },
                new BookEntity()
                {
                    BookId = 3,
                    Name = "Iliada",
                    Author = "Homer"
                });
        }
    }
}
