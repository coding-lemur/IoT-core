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
        public DbSet<SensorValues> Sensors { get; set; }

        public DbSet<WateringValue> Watering { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"Server = localhost; database = iot; uid = iot; pwd = zdGCUS5Fy9eJYY8F;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SensorValues>()
                .Property(s => s.Date)
                .HasDefaultValueSql("datetime('now','localtime')");

            modelBuilder.Entity<WateringValue>()
                .Property(w => w.Date)
                .HasDefaultValueSql("datetime('now','localtime')");

            base.OnModelCreating(modelBuilder);
        }
    }
}
