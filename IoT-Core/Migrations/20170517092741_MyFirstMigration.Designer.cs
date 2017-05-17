using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using IoT_Core.Models;

namespace IoT_Core.Migrations
{
    [DbContext(typeof(SensorValueContext))]
    [Migration("20170517092741_MyFirstMigration")]
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

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("DeviceTime");

                    b.Property<byte>("Humidity");

                    b.Property<int>("SoilMoisture");

                    b.Property<int>("Temperature");

                    b.HasKey("Id");

                    b.ToTable("SensorValues");
                });
        }
    }
}
