﻿// <auto-generated />
using System;
using BlackJack.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlackJack.DataAccess.Migrations
{
    [DbContext(typeof(GameDbContext))]
    partial class GameDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlackJack.DataAccess.Entities.Card", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreationTime");

                    b.Property<int>("Rank");

                    b.Property<int>("Suit");

                    b.HasKey("Id");

                    b.HasIndex("Suit", "Rank")
                        .IsUnique();

                    b.ToTable("Cards");

                    b.HasData(
                        new { Id = 1L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 1, Suit = 1 },
                        new { Id = 2L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 2, Suit = 1 },
                        new { Id = 3L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 3, Suit = 1 },
                        new { Id = 4L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 4, Suit = 1 },
                        new { Id = 5L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 5, Suit = 1 },
                        new { Id = 6L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 6, Suit = 1 },
                        new { Id = 7L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 7, Suit = 1 },
                        new { Id = 8L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 8, Suit = 1 },
                        new { Id = 9L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 9, Suit = 1 },
                        new { Id = 10L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 10, Suit = 1 },
                        new { Id = 11L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 11, Suit = 1 },
                        new { Id = 12L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 12, Suit = 1 },
                        new { Id = 13L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 13, Suit = 1 },
                        new { Id = 14L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 1, Suit = 2 },
                        new { Id = 15L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 2, Suit = 2 },
                        new { Id = 16L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 3, Suit = 2 },
                        new { Id = 17L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 4, Suit = 2 },
                        new { Id = 18L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 5, Suit = 2 },
                        new { Id = 19L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 6, Suit = 2 },
                        new { Id = 20L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 7, Suit = 2 },
                        new { Id = 21L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 8, Suit = 2 },
                        new { Id = 22L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 9, Suit = 2 },
                        new { Id = 23L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 10, Suit = 2 },
                        new { Id = 24L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 11, Suit = 2 },
                        new { Id = 25L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 12, Suit = 2 },
                        new { Id = 26L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 13, Suit = 2 },
                        new { Id = 27L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 1, Suit = 3 },
                        new { Id = 28L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 2, Suit = 3 },
                        new { Id = 29L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 3, Suit = 3 },
                        new { Id = 30L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 4, Suit = 3 },
                        new { Id = 31L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 5, Suit = 3 },
                        new { Id = 32L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 6, Suit = 3 },
                        new { Id = 33L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 7, Suit = 3 },
                        new { Id = 34L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 8, Suit = 3 },
                        new { Id = 35L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 9, Suit = 3 },
                        new { Id = 36L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 10, Suit = 3 },
                        new { Id = 37L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 11, Suit = 3 },
                        new { Id = 38L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 12, Suit = 3 },
                        new { Id = 39L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 13, Suit = 3 },
                        new { Id = 40L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 1, Suit = 4 },
                        new { Id = 41L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 2, Suit = 4 },
                        new { Id = 42L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 3, Suit = 4 },
                        new { Id = 43L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 4, Suit = 4 },
                        new { Id = 44L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 5, Suit = 4 },
                        new { Id = 45L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 6, Suit = 4 },
                        new { Id = 46L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 7, Suit = 4 },
                        new { Id = 47L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 8, Suit = 4 },
                        new { Id = 48L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 9, Suit = 4 },
                        new { Id = 49L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 10, Suit = 4 },
                        new { Id = 50L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 11, Suit = 4 },
                        new { Id = 51L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 12, Suit = 4 },
                        new { Id = 52L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 162, DateTimeKind.Local), Rank = 13, Suit = 4 }
                    );
                });

            modelBuilder.Entity("BlackJack.DataAccess.Entities.Game", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreationTime");

                    b.Property<bool>("IsFinished");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("BlackJack.DataAccess.Entities.Player", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreationTime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Players");

                    b.HasData(
                        new { Id = 1L, CreationTime = new DateTime(2019, 5, 2, 16, 34, 25, 167, DateTimeKind.Local), Name = "Dealer", Type = 3 }
                    );
                });

            modelBuilder.Entity("BlackJack.DataAccess.Entities.RoundPlayer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreationTime");

                    b.Property<long>("GameId");

                    b.Property<long>("PlayerId");

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("RoundPlayers");
                });

            modelBuilder.Entity("BlackJack.DataAccess.Entities.RoundPlayerCard", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CardId");

                    b.Property<DateTime?>("CreationTime");

                    b.Property<long>("RoundPlayerId");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("RoundPlayerId");

                    b.ToTable("RoundPlayerCards");
                });

            modelBuilder.Entity("BlackJack.DataAccess.Entities.RoundPlayer", b =>
                {
                    b.HasOne("BlackJack.DataAccess.Entities.Game", "Game")
                        .WithMany("RoundPlayers")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlackJack.DataAccess.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlackJack.DataAccess.Entities.RoundPlayerCard", b =>
                {
                    b.HasOne("BlackJack.DataAccess.Entities.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlackJack.DataAccess.Entities.RoundPlayer", "RoundPlayer")
                        .WithMany("Cards")
                        .HasForeignKey("RoundPlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
