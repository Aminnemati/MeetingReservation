using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;

using MeetingReservation.Models;

namespace MeetingReservation.DAL
{
    public class MeetingContext : DbContext
    {
        public MeetingContext() : base("MeetingContext")
        {         
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Attend> Attends { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<CustomDateTime> CustomDateTimes { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<CustomDateTime>()
                .HasRequired(s => s.Meeting)
                .WithRequiredPrincipal(ad => ad.CustomDateTime);
            modelBuilder.Entity<User>().Map<Initiator>(m => m.Requires("Discriminator").HasValue("Ini"))
                .Map<Invitee>(m => m.Requires("Discriminator").HasValue("Inv"))
                .Map<Supervisor>(m => m.Requires("Discriminator").HasValue("Sup"))
                .Map<Admin>(m => m.Requires("Discriminator").HasValue("Adm"));

        }
    }
}