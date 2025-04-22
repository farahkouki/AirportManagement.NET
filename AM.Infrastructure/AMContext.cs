using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class AMContext:DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog=AirportManagementDB;
                                        Integrated Security=true;
                                        MultipleActiveResultSets=true");
            //Activater LazyLoading
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        //Configurations Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.Entity<Plane>().HasKey(p => p.PlaneId);
            modelBuilder.Entity<Plane>().ToTable("MyPlanes");
            modelBuilder.Entity<Plane>().Property(p => p.Capacity)
                        .HasColumnName("PlaneCapacity");
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            //Type détenu
            modelBuilder.Entity<Passenger>().OwnsOne(p => p.FullName);
            //Héritage Table Per Hierarchy (TPH)
            //modelBuilder.Entity<Passenger>()
            //             .HasDiscriminator<int>("IsTraveller")
            //             .HasValue<Passenger>(0)
            //             .HasValue<Traveller>(1)
            //             .HasValue<Staff>(2);

            //Héritage table Per Type
            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Traveller>().ToTable("Travellers");
            //configurer cler primere
            modelBuilder.Entity<Ticket>()
                        .HasKey(t=>new {t.FlightFk,t.passengerFk});
            base.OnModelCreating(modelBuilder);
        }
        //Pré convention
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>()
                                .HaveColumnType("datetime");
            base.ConfigureConventions(configurationBuilder);
        }

    }
}
