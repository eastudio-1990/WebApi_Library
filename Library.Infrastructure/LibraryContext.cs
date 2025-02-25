﻿using Library.Application.Interfaces;
using Library.Core.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

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

        }    

    }
}
