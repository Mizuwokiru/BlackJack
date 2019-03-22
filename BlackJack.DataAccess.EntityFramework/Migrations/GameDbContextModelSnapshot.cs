﻿// <auto-generated />
using System;
using BlackJack.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlackJack.DataAccess.EntityFramework.Migrations
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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<int>("Rank");

                    b.Property<int>("Suit");

                    b.HasKey("Id");

                    b.ToTable("Cards");

                    b.HasData(
                        new { Id = 1, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 185, DateTimeKind.Local), Rank = 1, Suit = 1 },
                        new { Id = 2, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 2, Suit = 1 },
                        new { Id = 3, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 3, Suit = 1 },
                        new { Id = 4, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 4, Suit = 1 },
                        new { Id = 5, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 5, Suit = 1 },
                        new { Id = 6, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 6, Suit = 1 },
                        new { Id = 7, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 7, Suit = 1 },
                        new { Id = 8, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 8, Suit = 1 },
                        new { Id = 9, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 9, Suit = 1 },
                        new { Id = 10, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 10, Suit = 1 },
                        new { Id = 11, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 11, Suit = 1 },
                        new { Id = 12, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 12, Suit = 1 },
                        new { Id = 13, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 13, Suit = 1 },
                        new { Id = 14, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 1, Suit = 2 },
                        new { Id = 15, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 2, Suit = 2 },
                        new { Id = 16, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 3, Suit = 2 },
                        new { Id = 17, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 4, Suit = 2 },
                        new { Id = 18, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 5, Suit = 2 },
                        new { Id = 19, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 6, Suit = 2 },
                        new { Id = 20, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 7, Suit = 2 },
                        new { Id = 21, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 8, Suit = 2 },
                        new { Id = 22, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 9, Suit = 2 },
                        new { Id = 23, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 10, Suit = 2 },
                        new { Id = 24, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 11, Suit = 2 },
                        new { Id = 25, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 12, Suit = 2 },
                        new { Id = 26, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 13, Suit = 2 },
                        new { Id = 27, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 1, Suit = 3 },
                        new { Id = 28, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 2, Suit = 3 },
                        new { Id = 29, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 3, Suit = 3 },
                        new { Id = 30, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 4, Suit = 3 },
                        new { Id = 31, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 5, Suit = 3 },
                        new { Id = 32, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 6, Suit = 3 },
                        new { Id = 33, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 7, Suit = 3 },
                        new { Id = 34, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 8, Suit = 3 },
                        new { Id = 35, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 9, Suit = 3 },
                        new { Id = 36, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 10, Suit = 3 },
                        new { Id = 37, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 11, Suit = 3 },
                        new { Id = 38, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 12, Suit = 3 },
                        new { Id = 39, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 13, Suit = 3 },
                        new { Id = 40, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 1, Suit = 4 },
                        new { Id = 41, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 2, Suit = 4 },
                        new { Id = 42, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 3, Suit = 4 },
                        new { Id = 43, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 4, Suit = 4 },
                        new { Id = 44, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 5, Suit = 4 },
                        new { Id = 45, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 6, Suit = 4 },
                        new { Id = 46, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 7, Suit = 4 },
                        new { Id = 47, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 8, Suit = 4 },
                        new { Id = 48, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 9, Suit = 4 },
                        new { Id = 49, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 10, Suit = 4 },
                        new { Id = 50, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 11, Suit = 4 },
                        new { Id = 51, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 12, Suit = 4 },
                        new { Id = 52, CreationTime = new DateTime(2019, 3, 22, 16, 46, 32, 186, DateTimeKind.Local), Rank = 13, Suit = 4 }
                    );
                });

            modelBuilder.Entity("BlackJack.DataAccess.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("BlackJack.DataAccess.Entities.GamePlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<int>("GameId");

                    b.Property<int>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("GamePlayers");
                });

            modelBuilder.Entity("BlackJack.DataAccess.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<bool>("IsBot");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Players");
                });

            modelBuilder.Entity("BlackJack.DataAccess.Entities.Round", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<int>("GameId");

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("BlackJack.DataAccess.Entities.RoundPlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<bool>("IsWon");

                    b.Property<int>("PlayerId");

                    b.Property<int>("RoundId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("RoundId");

                    b.ToTable("RoundPlayers");
                });

            modelBuilder.Entity("BlackJack.DataAccess.Entities.RoundPlayerCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CardId");

                    b.Property<DateTime>("CreationTime");

                    b.Property<int>("RoundPlayerId");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("RoundPlayerId");

                    b.ToTable("RoundPlayerCards");
                });

            modelBuilder.Entity("BlackJack.DataAccess.Entities.GamePlayer", b =>
                {
                    b.HasOne("BlackJack.DataAccess.Entities.Game", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlackJack.DataAccess.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlackJack.DataAccess.Entities.Round", b =>
                {
                    b.HasOne("BlackJack.DataAccess.Entities.Game", "Game")
                        .WithMany("Rounds")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlackJack.DataAccess.Entities.RoundPlayer", b =>
                {
                    b.HasOne("BlackJack.DataAccess.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlackJack.DataAccess.Entities.Round", "Round")
                        .WithMany("Players")
                        .HasForeignKey("RoundId")
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
