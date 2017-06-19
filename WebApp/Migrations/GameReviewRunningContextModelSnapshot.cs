using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApp.Models;

namespace WebApp.Migrations
{
    [DbContext(typeof(GameReviewRunningContext))]
    partial class GameReviewRunningContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApp.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Developer")
                        .IsRequired();

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("WorldRecord");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("WebApp.Models.GameRunner", b =>
                {
                    b.Property<int>("GameId");

                    b.Property<int>("RunnerId");

                    b.HasKey("GameId", "RunnerId");

                    b.HasIndex("RunnerId");

                    b.ToTable("GameRunner");
                });

            modelBuilder.Entity("WebApp.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("GameId");

                    b.Property<int>("Grade");

                    b.Property<string>("ReviewerName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("WebApp.Models.Runner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("RunnerName")
                        .IsRequired();

                    b.Property<int>("WorldRecords");

                    b.HasKey("Id");

                    b.ToTable("Runners");
                });

            modelBuilder.Entity("WebApp.Models.UserAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApp.Models.GameRunner", b =>
                {
                    b.HasOne("WebApp.Models.Game", "Game")
                        .WithMany("GameRunner")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApp.Models.Runner", "Runner")
                        .WithMany("GameRunner")
                        .HasForeignKey("RunnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApp.Models.Review", b =>
                {
                    b.HasOne("WebApp.Models.Game", "Game")
                        .WithMany("Reviews")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
