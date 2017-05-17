using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace IoT_Core.Models
{
    public class SensorValueContext : DbContext
    {
        public DbSet<SensorValues> SensorValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SensorValues>()
                .Property(sv => sv.Created)
                .HasDefaultValueSql("datetime('now','localtime')");

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=values.db");
        }
    }
}
