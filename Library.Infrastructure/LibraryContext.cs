using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure
{
    public class LibraryContext : DbContext
    {

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BorrowRecord> BorrowRecords { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var admin = new User
            {
                Id = 1,
                Email = "Admin@gmail.com",
                Name = "Admin",
                Role = "Admin",
                PasswordHash = "ODgfjsVRNG8C1ga0SWmuCA==:wTlq+7H0TP1r5zDZB4w+Y/UzgD6n/6QYvPQdx/qkb84=" // AdminPassword
            };

            modelBuilder.Entity<User>().HasData(admin);

            modelBuilder.Entity<Book>()
                .HasOne<Category>()
                .WithMany()
                .HasForeignKey(b => b.CategoryId);

            modelBuilder.Entity<BorrowRecord>()
                .HasOne<Book>()
                .WithMany()
                .HasForeignKey(br => br.BookId);

            modelBuilder.Entity<BorrowRecord>()
                .HasOne<Borrower>()
                .WithMany()
                .HasForeignKey(br => br.BorrowerId);
        }

    }

}

