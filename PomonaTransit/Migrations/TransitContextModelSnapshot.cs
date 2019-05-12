﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PomonaTransit;

namespace PomonaTransit.Migrations
{
    [DbContext(typeof(TransitContext))]
    partial class TransitContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PomonaTransit.ActualTripStopInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ActualArrivalTime");

                    b.Property<DateTime>("ActualStartTime");

                    b.Property<DateTime>("Date");

                    b.Property<int>("NumberOfPassengerOut");

                    b.Property<int>("NumberOfPassngerIn");

                    b.Property<DateTime>("ScheduledStartTime");

                    b.Property<DateTime>("SecheduledArrivalTime");

                    b.Property<int?>("StopNumber");

                    b.Property<int?>("TripNumber");

                    b.HasKey("ID");

                    b.HasIndex("StopNumber");

                    b.HasIndex("TripNumber");

                    b.ToTable("ActualTripStopInfos");
                });

            modelBuilder.Entity("PomonaTransit.Bus", b =>
                {
                    b.Property<int>("BusID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Model");

                    b.Property<DateTime>("Year");

                    b.HasKey("BusID");

                    b.ToTable("buses");
                });

            modelBuilder.Entity("PomonaTransit.Driver", b =>
                {
                    b.Property<string>("DriverName")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DriverTelepohneNumber");

                    b.HasKey("DriverName");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("PomonaTransit.Stop", b =>
                {
                    b.Property<int>("StopNumber")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StopAddress");

                    b.HasKey("StopNumber");

                    b.ToTable("Stops");
                });

            modelBuilder.Entity("PomonaTransit.Trip", b =>
                {
                    b.Property<int>("TripNumber")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DestinationName");

                    b.Property<string>("StartLocationName");

                    b.HasKey("TripNumber");

                    b.ToTable("trips");
                });

            modelBuilder.Entity("PomonaTransit.TripOffering", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("DriverName");

                    b.Property<DateTime>("ScheduledStartTime");

                    b.Property<DateTime>("SecheduledArrivalTime");

                    b.Property<int?>("TripNumber");

                    b.HasKey("ID");

                    b.HasIndex("DriverName");

                    b.HasIndex("TripNumber");

                    b.ToTable("tripOfferings");
                });

            modelBuilder.Entity("PomonaTransit.TripStopInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrivingTime");

                    b.Property<int>("SequenceNumber");

                    b.Property<int?>("StopNumber");

                    b.Property<int?>("TripNumber");

                    b.HasKey("ID");

                    b.HasIndex("StopNumber");

                    b.HasIndex("TripNumber");

                    b.ToTable("TripStopInfos");
                });

            modelBuilder.Entity("PomonaTransit.ActualTripStopInfo", b =>
                {
                    b.HasOne("PomonaTransit.Stop", "Stop")
                        .WithMany()
                        .HasForeignKey("StopNumber");

                    b.HasOne("PomonaTransit.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripNumber");
                });

            modelBuilder.Entity("PomonaTransit.TripOffering", b =>
                {
                    b.HasOne("PomonaTransit.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverName");

                    b.HasOne("PomonaTransit.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripNumber");
                });

            modelBuilder.Entity("PomonaTransit.TripStopInfo", b =>
                {
                    b.HasOne("PomonaTransit.Stop", "Stop")
                        .WithMany()
                        .HasForeignKey("StopNumber");

                    b.HasOne("PomonaTransit.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripNumber");
                });
#pragma warning restore 612, 618
        }
    }
}
