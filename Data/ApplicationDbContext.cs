﻿using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base (options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>();
        }
    }

   
}
