using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PomonaTransit
{
    public class TransitContext : DbContext
    {
        public TransitContext(DbContextOptions<TransitContext> options)
            : base(options)
        { }

        public DbSet<Trip> trips { get; set; }
        public DbSet<TripOffering> tripOfferings { get; set; }
        public DbSet<Bus> buses { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Stop> Stops { get; set; }

        public DbSet<ActualTripStopInfo> ActualTripStopInfos { get; set; }
        public DbSet<TripStopInfo> TripStopInfos { get; set; }

        protected override void OnModelCreating( ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<TripOffering>().HasKey(t => new { t.Trip, t.Date, t.ScheduledStartTime });
            //modelBuilder.Entity<ActualTripStopInfo>().HasKey(a => new { a.Trip, a.date, a.ScheduledStartTime, a.stop });
            //modelBuilder.Entity<TripStopInfo>().HasKey(t => new { t.Trip, t.stop });
        }
    }
    public class Trip
    {
        [Key]
        public int TripNumber { get; set; }
        public string StartLocationName { get; set; }
        public string DestinationName { get; set; }

    }
    public class TripOffering
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("TripNumber")]
        public Trip Trip { get; set; }

        public DateTime Date { get; set; }

        public DateTime ScheduledStartTime { get; set; }

        public DateTime SecheduledArrivalTime { get; set; }

        [ForeignKey("DriverName")]
        public Driver Driver { get; set; }
    }
    public class Bus
    {
        [Key]
        public int BusID { get; set; }
        public string Model { get; set; }
        public DateTime Year { get; set; }
    }

    public class Driver
    {
        [Key]
        public string DriverName { get; set; }

        public string DriverTelepohneNumber { get; set; }

    }

    public class Stop
    {
        [Key]
        public int StopNumber { get; set; }
        public string StopAddress { get; set; }

    }

    public class ActualTripStopInfo
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("TripNumber")]
        public Trip Trip { get; set; }


        public DateTime Date { get; set; }
 

        public DateTime ScheduledStartTime { get; set; }
        [ForeignKey("StopNumber")]
        public Stop Stop { get; set; }
        public DateTime SecheduledArrivalTime { get; set; }
        public DateTime ActualStartTime { get; set; }
        public DateTime ActualArrivalTime { get; set; }
        public int NumberOfPassngerIn { get; set; }
        public int NumberOfPassengerOut { get; set; }
    }

    public class TripStopInfo
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("TripNumber")]
        public Trip Trip { get; set; }

        [ForeignKey("StopNumber")]
        public Stop Stop { get; set; }

        public int SequenceNumber { get; set; }

        public int DrivingTime { get; set; }
    } 
}
