﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class GameReviewRunningContext : DbContext
    {
        public DbSet<UserAccount> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Runner> Runners { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<GameRunner> GameRunner { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Server = (localdb)\\mssqllocaldb; Database = GameReviewAndSpeedRunning; Trusted_Connection = True; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameRunner>()
                .HasKey(t => new { t.GameId, t.RunnerId });

            modelBuilder.Entity<GameRunner>()
                .HasOne(gr => gr.Game)
                .WithMany(g => g.GameRunner)
                .HasForeignKey(gr => gr.GameId);

            modelBuilder.Entity<GameRunner>()
                .HasOne(gr => gr.Runner)
                .WithMany(g => g.GameRunner)
                .HasForeignKey(gr => gr.RunnerId);

            modelBuilder.Entity<Game>()
                .HasMany(g => g.Reviews)
                .WithOne(r => r.Game);
        }
    }
}
