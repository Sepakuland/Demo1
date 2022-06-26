using Demo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Demo.InfraStructure.EF
{
    public class DemoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=NewsWebTagHelper;Data Source=.");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<News> News { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ads> Ads { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
