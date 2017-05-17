using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using IoT_Core.Models;

namespace IoT_Core.Migrations
{
    [DbContext(typeof(SensorValueContext))]
    [Migration("20170517132838_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("IoT_Core.Models.SensorValues", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime>("DeviceTime");

                    b.Property<byte?>("Humidity")
                        .IsRequired();

                    b.Property<int?>("SoilMoisture")
                        .IsRequired();

                    b.Property<int?>("Temperature")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("SensorValues");
                });
        }
    }
}
