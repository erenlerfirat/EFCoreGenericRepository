﻿using EFCoreGenericRepository.Console.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreGenericRepository.Console.RepositoryBase
{
    public class CoreContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Todo>().HasKey(e => e.Id);
        }
        public CoreContext(DbContextOptions<CoreContext> options) : base(options)
        {

        }
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Todo> Todos { get; set; }
    }
}
