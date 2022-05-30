using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Two.Models;



namespace Two.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Issue> Issues { get; set; }
        public DbSet<TimeTrackingId> TimeTrackings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=223-6\\MSSQLSERVER99;Initial Catalog=issue-tracking-db;" + "Trusted_Connection=True;" + "MultipleActiveResultSets=False;" + "Connection Timeout=30;");
        }
        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<TimeTrackingId>()
                .HasOne(o => o.Issue)
                .WithMany(m => m.TimeTrackings)
                .OnDelete(DeleteBehavior.NoAction);
                }
    }

}
