using ChangeTrackerIssue.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeTrackerIssue
{
    public class AppDbContext : DbContext
    {
        public DbSet<MainEntity> MainEntities { get; set; }
        public DbSet<TimeUnit> TimeUnits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ChangeTrackerDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public void AddTrackingEvents()
        {
            ChangeTracker.Tracked += ChangeTracker_Tracked;
            ChangeTracker.StateChanged += ChangeTracker_StateChanged;
        }
        public void ClearTrackingEvents()
        {
            ChangeTracker.Tracked -= ChangeTracker_Tracked;
            ChangeTracker.StateChanged -= ChangeTracker_StateChanged;
        }
        private void ChangeTracker_Tracked(object sender, Microsoft.EntityFrameworkCore.ChangeTracking.EntityTrackedEventArgs entityEvent)
        {
            if (typeof(TimeUnit).IsAssignableFrom(entityEvent.Entry.Entity.GetType()))
                entityEvent.Entry.State = EntityState.Detached;
        }
        private void ChangeTracker_StateChanged(object sender, Microsoft.EntityFrameworkCore.ChangeTracking.EntityStateChangedEventArgs entityEvent)
        {
            if (typeof(TimeUnit).IsAssignableFrom(entityEvent.Entry.Entity.GetType()))
                entityEvent.Entry.State = EntityState.Detached;
        }
    }
}
