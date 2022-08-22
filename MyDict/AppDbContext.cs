using Microsoft.EntityFrameworkCore;
using System;

namespace MyDict.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host=localhost;port=5432;database=mydict;username=postgres;password=postgres");
            //.LogTo(Console.WriteLine);
        }
            public DbSet<Word> words { get; set; }
    }
}
