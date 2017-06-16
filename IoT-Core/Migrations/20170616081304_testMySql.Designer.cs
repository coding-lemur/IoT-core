using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using IoT_Core.Models;

namespace IoT_Core.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20170616081304_testMySql")]
    partial class testMySql
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("IoT_Core.Models.SensorValues", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<float>("Humidity");

                    b.Property<int>("SoilMoisture");

                    b.Property<float>("Temperature");

                    b.HasKey("Id");

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("IoT_Core.Models.WateringValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("Milliseconds");

                    b.Property<int?>("SensorsId");

                    b.HasKey("Id");

                    b.HasIndex("SensorsId");

                    b.ToTable("Watering");
                });

            modelBuilder.Entity("IoT_Core.Models.WateringValue", b =>
                {
                    b.HasOne("IoT_Core.Models.SensorValues", "Sensors")
                        .WithMany()
                        .HasForeignKey("SensorsId");
                });
        }
    }
}
