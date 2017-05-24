using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace IoT_Core.Models
{
    public class DataContext : DbContext
    {
        public DbSet<SensorValue> Sensors { get; set; }

        public DbSet<WateringValue> Watering { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SensorValue>()
                .Property(s => s.Date)
                .HasDefaultValueSql("datetime('now','localtime')");

            modelBuilder.Entity<WateringValue>()
                .Property(w => w.Date)
                .HasDefaultValueSql("datetime('now','localtime')");

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=data.db");
        }
    }
}
