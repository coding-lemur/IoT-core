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

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SensorValues>()
                .Property(s => s.Date)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<WateringValue>()
                .Property(w => w.Date)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            base.OnModelCreating(modelBuilder);
        }
    }
}
