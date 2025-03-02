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

            // تعریف رابطه بین Book و Category
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // جلوگیری از حذف cascade

            // تعریف رابطه بین BorrowRecord و Book
            modelBuilder.Entity<BorrowRecord>()
                .HasOne(br => br.Book)
                .WithMany()
                .HasForeignKey(br => br.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            // تعریف رابطه بین BorrowRecord و Borrower
            modelBuilder.Entity<BorrowRecord>()
                .HasOne(br => br.Borrower)
                .WithMany(b => b.BorrowRecords)
                .HasForeignKey(br => br.BorrowerId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }

}

