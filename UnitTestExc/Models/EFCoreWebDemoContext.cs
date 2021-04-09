using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace UnitTestExc.Models
{
    public class EFCoreWebDemoContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-3S94LHJ\\SQLEXPRESS;Database=UnitTestExcDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}