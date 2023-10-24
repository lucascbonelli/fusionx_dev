﻿using hackweek_backend.Models;

namespace hackweek_backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventDay> EventDays { get; set; }
        public DbSet<EventImage> EventImages { get; set; }
        public DbSet<EventTag> EventTags { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationTemplate> NotificationTemplates { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserTag> UserTags { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.EventDay).WithMany()
                .HasForeignKey(a => a.EventDayId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.User).WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.User).WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EventDay>()
                .HasOne(ed => ed.Event).WithMany(e => e.EventDays)
                .HasForeignKey(ed => ed.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EventDay>()
                .HasOne(ed => ed.Location).WithMany()
                .HasForeignKey(ed => ed.LocationId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<EventImage>()
                .HasOne(ei => ei.Event).WithMany(e => e.EventImages)
                .HasForeignKey(ei => ei.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EventTag>()
                .HasKey(et => new { et.TagId, et.EventId });

            modelBuilder.Entity<EventTag>()
                .HasOne(et => et.Tag).WithMany()
                .HasForeignKey(et => et.TagId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EventTag>()
                .HasOne(et => et.Event).WithMany(e => e.Tags)
                .HasForeignKey(et => et.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Notification).WithMany()
                .HasForeignKey(f => f.NotificationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.User).WithMany()
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Event).WithMany()
                .HasForeignKey(n => n.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Session>()
                .HasOne(s => s.EventDay).WithMany(e => e.Sessions)
                .HasForeignKey(s => s.EventDayId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<UserTag>()
                .HasKey(ut => new { ut.TagId, ut.UserId });

            modelBuilder.Entity<UserTag>()
                .HasOne(ut => ut.Tag).WithMany()
                .HasForeignKey(ut => ut.TagId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserTag>()
                .HasOne(ut => ut.User).WithMany(u => u.Tags)
                .HasForeignKey(ut => ut.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserToken>()
                .HasKey(ut => ut.UserId);

            modelBuilder.Entity<UserToken>()
                .HasOne(ut => ut.User).WithOne()
                .HasForeignKey<UserToken>(ut => ut.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

